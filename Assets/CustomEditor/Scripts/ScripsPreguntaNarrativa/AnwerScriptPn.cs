using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace v1
{
    public class AnwerScriptPn : MonoBehaviour
    {
        public bool iscorrect;
        public QuizManagerPn quizManager;
        public string respuesta;
        



        private void Start()
        {
            respuesta = GetComponentInChildren<TMP_Text>().text;
        }


        public void Answer()
        {
            if (iscorrect)
            {

                Debug.Log(quizManager.Pregunta + " "+ respuesta + " " + "es correcto");
                quizManager.Correct();

            }
            else
            {
                Debug.Log(quizManager.Pregunta + " " + respuesta + " "+ "es incorrecto");
                quizManager.InCorret();
            }
        }
        
    }
}

