using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace v1
{
    public class AnswerScript : MonoBehaviour
    {
        public bool isCorret = false;
        public Quizmanager quizmanager;
        public QuestionAndAnswers qna;

        public void Answer()
        {
            if (isCorret == true)
            {

                Debug.Log("correta");
                quizmanager.correcto();

            }
            else
            {

                Debug.Log("No es correta");
                quizmanager.incorrecto();

            }



        }


    }
}


