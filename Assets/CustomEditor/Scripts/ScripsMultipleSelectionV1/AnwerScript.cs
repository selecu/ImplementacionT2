using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace v1
{
    public class AnwerScript : MonoBehaviour
    {
        public bool iscorrect;
        public QuizManager quizManager;



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

