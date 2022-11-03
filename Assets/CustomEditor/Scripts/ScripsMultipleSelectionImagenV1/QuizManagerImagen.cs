using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class Quest
{
    public Sprite Pregunta;
    public List<Answer> Respuestas;
}

[System.Serializable]
public class Answer
{

    public Sprite solucion;
    public bool correcta;
}


namespace v1
{

    public class QuizManagerImagen : MonoBehaviour
    {
        public List<Quest> Preguntas;
        public GameObject[] Opcciones;
        public int Pregunta_Actual;


        public Image Text_Pregunta;
        public GameObject Buttoncheck;
        public GameObject ButtoncheckIntregrador;

        public GameObject[] ventana;


        private void Awake()
        {
            Shuffle(Preguntas[Pregunta_Actual].Respuestas);
        }


        private void Start()
        {

            GenerateQuestion();
            Buttoncheck.SetActive(false);
            ButtoncheckIntregrador.SetActive(false);
           

        }

        private void Shuffle<T>(List<T> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                T temp = list[i];
                int rnd = Random.Range(i, list.Count);
                list[i] = list[rnd];
                list[rnd] = temp;
            }
        }

        public void Correct()
        {
            if (Preguntas.Count > 0)
            {
                Preguntas.RemoveAt(Pregunta_Actual);
            }
            GenerateQuestion();
            ButtoncheckIntregrador.SetActive(true);
            
            

        }

        public void InCorret()
        {
            Buttoncheck.SetActive(false);
            GenerateQuestion();
            v1.Managersound item = FindObjectOfType<Managersound>();
            item.incorrecto.Play();
            ventana[1].SetActive(true);
            StartCoroutine(Waiting());

        }

        void SetAnswers()
        {


            for (int i = 0; i < Opcciones.Length; i++)
            {
                Opcciones[i].GetComponent<AnwerScriptImagen>().iscorrect = false;

                Opcciones[i].transform.GetComponent<Image>().sprite = Preguntas[Pregunta_Actual].Respuestas[i].solucion;


                if (Preguntas[Pregunta_Actual].Respuestas[i].correcta == true)
                {
                    Opcciones[i].GetComponent<AnwerScriptImagen>().iscorrect = true;
                    Pregunta_Actual++;
                }

            }

        }

        void GenerateQuestion()
        {
            if (Preguntas.Count > 0)
            {
                //Pregunta_Actual = Random.Range(0, Preguntas.Count);
                Shuffle(Preguntas[Pregunta_Actual].Respuestas);
                Text_Pregunta.sprite = Preguntas[Pregunta_Actual].Pregunta;
                SetAnswers();

            }
            if (Preguntas.Count <= 0)
            {
                Buttoncheck.SetActive(true);
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

