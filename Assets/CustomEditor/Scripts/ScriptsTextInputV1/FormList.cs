using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



namespace v1
{
    public class FormList : MonoBehaviour
    {
        public Form formAlone;
        public GameObject Cehck1;
        public GameObject Check_Salida;
        public GameObject[] ventana;

        void Start()
        {
            
            Check_Salida.SetActive(false);
        }


        public void calificar()
        {
            bool buena = true;
            foreach (var item in formAlone.inputsRespuesta)
            {
                if (string.IsNullOrEmpty(item.input.text))
                {
                    buena = false;
                }
                else if (item.input.text.ToLower() != item.respuesta.ToLower())
                {
                    buena = false;
                }


                if ( item.TextoLibre == true && !string.IsNullOrEmpty(item.input.text))
                {
                    buena = true;
                }
                

            }
            if (buena)
            {
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.correcto.Play();
                ventana[0].SetActive(true);
                Cehck1.SetActive(false);
                Check_Salida.SetActive(true);
                Debug.Log("Esta buena");
            }
            else
            {
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.incorrecto.Play();
                ventana[1].SetActive(true);
                StartCoroutine(Wait());
                Debug.Log("esta mala");
            }
        }



        IEnumerator Wait()
        {
            yield return new WaitForSeconds(5);
            ventana[1].SetActive(false);
            StopAllCoroutines();
        }
    }

    [System.Serializable]
    public class Form
    {
        public List<Inputs> inputsRespuesta;
    }

    [System.Serializable]
    public class Inputs
    {
        public TMP_InputField input;
        public string respuesta;
        public bool TextoLibre;
    }
}
