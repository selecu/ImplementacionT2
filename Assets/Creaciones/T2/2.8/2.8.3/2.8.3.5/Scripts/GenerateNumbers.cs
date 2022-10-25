using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace I2835
{
    public class GenerateNumbers : MonoBehaviour
    {
        public v1.PreguntaManagerR preguntasValues;
        public v1.RespuestasManagerR respuestasValues;

        public int minRange = 1;
        public int maxRange = 100;

        private void Awake()
        {
            SetValues(preguntasValues.AllPiezas.Count);
        }
        public void SetValues(int lenth)
        {
            for (int i = 0; i < lenth; i++)
            {
                int random1 = 0;

                do
                    random1 = Random.Range(minRange, maxRange);
                while 
                    (!MatchConditions(random1));

                respuestasValues.AllSlots[i].Info = (random1/2).ToString();
                preguntasValues.AllPiezas[i].Info = random1.ToString();
            }
        }

        bool MatchConditions(int evaluation)
        {
            if (evaluation % 2 != 0) return false;
            return true;
        }
    }
}
