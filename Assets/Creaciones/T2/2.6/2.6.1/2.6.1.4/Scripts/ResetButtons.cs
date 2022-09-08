using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace I2614
{
    public class ResetButtons : MonoBehaviour
    {
        public I2614.QuizManagerMultipleAnswers m_zquizManager;

        private void Update()
        {
            if (m_zquizManager.Reset == true)
            {
                ResetButt();

            }
        }
        public void ResetButt()
        {

            if (m_zquizManager.multipleRespuestas)
            {
                for (int i = 0; i <m_zquizManager.Opcciones.Length ; i++)
                {
                    m_zquizManager.Opcciones[i].GetComponent<Button>().interactable = true;
                }
            }
            m_zquizManager.Reset = false;
            
        }
       
    }
}
