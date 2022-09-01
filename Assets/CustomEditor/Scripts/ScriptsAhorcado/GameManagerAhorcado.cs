using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

namespace v1
{
    public class GameManagerAhorcado : MonoBehaviour
    {
        [SerializeField] private string word;
        [SerializeField] private bool randomStart;

        [SerializeField] private TMP_InputField inputField;

        [SerializeField] private int intentos;

        [SerializeField] int showLetters;
        [SerializeField] private int remainingLetters;
        char[] wordSplit;
        int[] wordPositionArray;

        //[SerializeField] private int minRange;
        //[SerializeField] private int maxRange;

        [SerializeField] GameObject barraLetras;

        [SerializeField] private GameObject buttonCheck;
        [SerializeField] private GameObject buttonIntegrador;
        [SerializeField] int minleter;


        [SerializeField] GameObject[] Imagenesahorcado;

        [SerializeField] GameObject[] ventana;

        private void Start()
        {
            intentos = 0;

            buttonCheck.SetActive(true);
            buttonIntegrador.SetActive(false);
            //namescene = SceneManager.GetActiveScene().name;

            showLetters = UnityEngine.Random.Range(minleter, word.Length/2);

            SetWordIntArray();

            SetBarraLetras();
        }

        public void SetBarraLetras()
        {
            SplitWord(word);



            for (int i = 0; i < barraLetras.transform.childCount; i++)
            {
                barraLetras.transform.GetChild(i).GetComponentInChildren<TMP_Text>().text = wordSplit[i].ToString();
                barraLetras.transform.GetChild(i).GetComponentInChildren<TMP_Text>().enabled = false;
            }

            for (int i = 0; i < showLetters; i++)
            {
                barraLetras.transform.GetChild(wordPositionArray[i]).GetComponentInChildren<TMP_Text>().enabled = true;
            }
            remainingLetters = barraLetras.transform.childCount - showLetters;

        }

        public void SplitWord(string inputWord)
        {
            wordSplit = new char[inputWord.Length];

            for (int i = 0; i < wordSplit.Length; i++)
            {
                wordSplit[i] = inputWord[i];
            }
        }

        public void SetWordIntArray()
        {
            wordPositionArray = new int[showLetters];

            
            for (int i = 0; i < wordPositionArray.Length; i++)
            {
                int rand = UnityEngine.Random.Range(0, word.Length);

                while (RepeatNumber(rand, i, wordPositionArray))
                    rand = UnityEngine.Random.Range(0, word.Length);

                wordPositionArray[i] = rand;
            }
        }

        public bool RepeatNumber(int number, int iteration, int[] array)
        {
            for (int j = 0; j < iteration; j++)
            {
                if (number == array[j])
                {
                    return true;
                }
            }
            return false;
        }

        public void CheckOnInput()
        {
            if (remainingLetters > 0)
            {
                bool letterExist = false;
                for (int i = 0; i < barraLetras.transform.childCount; i++)
                {
                    if (barraLetras.transform.GetChild(i).GetComponentInChildren<TMP_Text>().text == inputField.text)
                    {
                        letterExist = true;
                        v1.Managersound item = FindObjectOfType<Managersound>();
                        item.correcto.Play();
                        
                        break;
                    }
                    else
                        letterExist = false;
                }

                if (letterExist)
                {
                    for (int i = 0; i < barraLetras.transform.childCount; i++)
                    {
                        if (barraLetras.transform.GetChild(i).GetComponentInChildren<TMP_Text>().text == inputField.text && 
                            barraLetras.transform.GetChild(i).GetComponentInChildren<TMP_Text>().enabled == false)
                        {
                            barraLetras.transform.GetChild(i).GetComponentInChildren<TMP_Text>().enabled = true;
                            remainingLetters--;
                        }
                    }
                }
                else
                {
                    intentos++;
                    MetodoAhorcado();
                }
            }
        }

        public void MetodoAhorcado()
        {
            int g = intentos -1;
            //int  imagenactiva = Imagenesahorcado.Length -1;
            for (int i = 0; i < Imagenesahorcado.Length; i++)
            {

                Imagenesahorcado[g].SetActive(true);
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.incorrecto.Play();
                    
            }

            if (  intentos == Imagenesahorcado.Length)
            {
                intentos = 0;

                buttonCheck.SetActive(true);
                buttonIntegrador.SetActive(false);
                showLetters = UnityEngine.Random.Range(minleter, word.Length / 2);

                SetWordIntArray();

                SetBarraLetras();
                for (int i = 0; i < Imagenesahorcado.Length; i++)
                {

                    Imagenesahorcado[g].SetActive(false);
                    g--;

                }
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.incorrecto.Play();
                ventana[1].SetActive(true);
                StartCoroutine(Waiting());
                

            }
           


            print("Aquí se ejecutaría la acción correspondiente del ahorcado.");
        }

        public void CheckInteraction()
        {
            bool isCorrect = true;
            for (int i = 0; i < barraLetras.transform.childCount; i++)
            {
                if (!barraLetras.transform.GetChild(i).GetComponentInChildren<TMP_Text>().enabled)
                {
                    isCorrect = false;
                    break;
                }
            }

            if (isCorrect)
            {
                buttonCheck.SetActive(false);
                buttonIntegrador.SetActive(true);
                inputField.interactable = false;
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.correcto.Play();
                ventana[0].SetActive(true);
            }
        }

        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(5);
            ventana[1].SetActive(false);
            StopCoroutine(Waiting());
        }
    }
}
