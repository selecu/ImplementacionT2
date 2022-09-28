using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;


namespace v1
{
    public class Quizmanager : MonoBehaviour
    {

        public int currentquestion;
        [SerializeField]
        int preguntaactual;
        public List<QuestionAndAnswers> QnA;
        public GameObject[] options;


        public TMP_Text QuestionTxt;


        public GameObject[] ventana;

        private void Start()
        {
            preguntaactual = QnA.Count -1;
            GenerateQuestions();
           
        }

        public void correcto()
        {
            QnA.RemoveAt(currentquestion);
            
            GenerateQuestions();
        }

        public void incorrecto()
        {
            //GenerateQuestions();
        }

        void SetAnswers()
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].GetComponent<AnswerScript>().isCorret = false;
                options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentquestion].respuestas[i].solucion;
                if (QnA[currentquestion].respuestas[i].correcta == true)
                {
                    options[i].GetComponent<AnswerScript>().isCorret = true;

                }
            }


        }

        void GenerateQuestions()
        {
            if(QnA.Count > 0)
            {
                currentquestion = Random.Range(0, QnA.Count);
                QuestionTxt.text = QnA[currentquestion].Pregunta;
                SetAnswers();
                
            }
            else
            {
                print("a");
            }

               
           
           





        }
    }

}
