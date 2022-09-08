using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace I2614
{
    public class AnwerScriptMulti : MonoBehaviour
    {
        public bool iscorrect;
        public I2614.QuizManagerMultipleAnswers m_zquizManager;
       

        public void Answer()
        {
            if (iscorrect )
            {

                Debug.Log("corecto");
                m_zquizManager.Correct();

            }
            else
            {
                Debug.Log("incorecto");
                m_zquizManager.InCorret();
            }
        }
    }
}

