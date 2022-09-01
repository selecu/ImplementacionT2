using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace v1
{
    public class AnwerScriptImagen : MonoBehaviour
    {
        public bool iscorrect;
        public QuizManagerImagen quizManager;



        public void Answer()
        {
            if (iscorrect)
            {

                Debug.Log("corecto");
                quizManager.Correct();

            }
            else
            {
                Debug.Log("incorecto");
                quizManager.InCorret();
            }
        }
    }
}



