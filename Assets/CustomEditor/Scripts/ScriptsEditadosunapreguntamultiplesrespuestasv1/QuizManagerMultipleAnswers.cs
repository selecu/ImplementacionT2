using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

[System.Serializable]
public class MultipleAnswersQuestion
{
    public string Pregunta;
    public List<Answers> Respuestas;
}

[System.Serializable]
public class MultipleAnswers
{
    [TextArea]
    public string solucion;
    public  bool correcta ;
    
}

namespace v1
{
    public class QuizManagerMultipleAnswers : MonoBehaviour
    {
        public List<Question> Preguntas;
        public GameObject[] Opcciones;
        public int Pregunta_Actual;
      

        public TMP_Text Text_Pregunta;
        public GameObject Buttoncheck;

        public TMP_Text Text_Intento;
        public GameObject[] ventana;


        //varables que modifique
        
        public int caltidadDerespuestasCorrectas;
            
        private int Cuantasrespuestascorrectastengo;

        public bool multipleRespuestas;

        private void Awake()
        {
            Shuffle(Preguntas[Pregunta_Actual].Respuestas);
        }


        private void Start()
        {

            GenerateQuestion();
            Buttoncheck.SetActive(false);
            Text_Intento.enabled = false;

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
            

            if (multipleRespuestas == true)
            {
                Cuantasrespuestascorrectastengo += 1;

                if (Cuantasrespuestascorrectastengo >= caltidadDerespuestasCorrectas)
                {
                    Esmultiplerespuestas();
                    Cuantasrespuestascorrectastengo = 0;
                }
            }        
            else
            {
                Esmultiplerespuestas();
            }

            


        }
        public void Esmultiplerespuestas()
        {
            Reset = true;
            Preguntas.RemoveAt(Pregunta_Actual);
            GenerateQuestion();

            Text_Intento.enabled = false;
        }

        //modificación
        [HideInInspector]
        public bool Reset;

        public void InCorret()
        {
            //modificación 
            Reset = true;
            Cuantasrespuestascorrectastengo = 0;

            Buttoncheck.SetActive(false);
            GenerateQuestion();
            // Text_Intento.enabled = true;
            StartCoroutine(Wait());

        }

        void SetAnswers()
        {


            for (int i = 0; i < Opcciones.Length; i++)
            {
                Opcciones[i].GetComponent<AnwerScriptMulti>().iscorrect = false;
                Opcciones[i].transform.GetChild(0).GetComponent<TMP_Text>().text = Preguntas[Pregunta_Actual].Respuestas[i].solucion;



                if (Preguntas[Pregunta_Actual].Respuestas[i].correcta == true)
                {

                    Opcciones[i].GetComponent<AnwerScriptMulti>().iscorrect = true;


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
            if (Preguntas.Count <= 0 )
            {
                Buttoncheck.SetActive(true);
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.correcto.Play();
                ventana[0].SetActive(true);
            }

        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(3f);
            Text_Intento.enabled = false;
            StopAllCoroutines();
        }




    }
}

