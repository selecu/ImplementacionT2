using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

[System.Serializable]
public class Question
{
    public string Pregunta;
    public List<Answers> Respuestas;
}

[System.Serializable]
public class Answers
{
    [TextArea]
    public string solucion;
    public  bool correcta ;
    
}

namespace v1
{
    public class QuizManager : MonoBehaviour
    {
        public List<Question> Preguntas;
        public GameObject[] Opcciones;
        public int Pregunta_Actual;



        public TMP_Text Text_Pregunta;
        public GameObject Buttoncheck;

        public GameObject[] ventana;


        private void Awake()
        {
            Shuffle(Preguntas[Pregunta_Actual].Respuestas);
        }


        private void Start()
        {

            GenerateQuestion();
            Buttoncheck.SetActive(false);
            

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
            Preguntas.RemoveAt(Pregunta_Actual);
            GenerateQuestion();

            


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
                Opcciones[i].GetComponent<AnwerScript>().iscorrect = false;
                Opcciones[i].transform.GetChild(0).GetComponent<TMP_Text>().text = Preguntas[Pregunta_Actual].Respuestas[i].solucion;


                if (Preguntas[Pregunta_Actual].Respuestas[i].correcta == true)
                {

                    Opcciones[i].GetComponent<AnwerScript>().iscorrect = true;
                   


                }

            }

        }

        void GenerateQuestion()
        {
            if (Preguntas.Count > 0)
            {

                Shuffle(Preguntas[Pregunta_Actual].Respuestas);
                Text_Pregunta.text = Preguntas[Pregunta_Actual].Pregunta;
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

