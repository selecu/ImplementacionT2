using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using System.Text;
using UnityEngine.iOS;

[System.Serializable]
public class QuestionPn
{
    public string Pregunta;
    public List<AnswersPn> Respuestas;
}

[System.Serializable]
public class AnswersPn
{
    [TextArea]
    public string solucion;
    public bool correcta;

}

namespace v1
{
    public class QuizManagerPn : MonoBehaviour
    {
        public List<QuestionPn> Preguntas;
        public GameObject[] Opcciones;
        public int Pregunta_Actual;



        public TMP_Text Text_Pregunta;
        public GameObject Buttoncheck;

        public string Pregunta;





        private void Awake()
        {
            Shuffle(Preguntas[Pregunta_Actual].Respuestas);

        }


        private void Start()
        {

            GenerateQuestion();
            Buttoncheck.SetActive(false);
            Pregunta = Text_Pregunta.text = Preguntas[Pregunta_Actual].Pregunta;


        }

        private void Update()
        {
            if (Preguntas.Count != 0)
                Pregunta = Text_Pregunta.text = Preguntas[Pregunta_Actual].Pregunta;
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
            try
            {
                Preguntas.RemoveAt(Pregunta_Actual);
                GenerateQuestion();
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e);
            }
        }

        public void InCorret()
        {
            try
            {
                Preguntas.RemoveAt(Pregunta_Actual);
                GenerateQuestion();
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e);
            }
        }

        void SetAnswers()
        {


            for (int i = 0; i < Opcciones.Length; i++)
            {
                Opcciones[i].GetComponent<AnwerScriptPn>().iscorrect = false;
                Opcciones[i].transform.GetChild(0).GetComponent<TMP_Text>().text = Preguntas[Pregunta_Actual].Respuestas[i].solucion;


                if (Preguntas[Pregunta_Actual].Respuestas[i].correcta == true)
                {

                    Opcciones[i].GetComponent<AnwerScriptPn>().iscorrect = true;



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
            }

        }






    }
}
