using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace I2612
{
    public class I2612Controller : MonoBehaviour
    {
        [Header("SUMAS QUE TERMINAN EN MULTIPLOS DE 10")]
        [SerializeField] private v1.RespuestasManagerR respuestaScript;
        [SerializeField] private v1.PreguntaManagerR preguntaScript;

        [Header("Ranges"), Space(40)]
        [SerializeField, Tooltip("Rango mínimo para las operaciones")] private int minRange;
        [SerializeField, Tooltip("Rango máximo para las operaciones")] private int maxRange;

        public int MinRange
        {
            get { return minRange; }
            set
            {
                if (minRange == 0)
                    Debug.LogWarning("Assign a value for minRange");

                minRange = value;
            }
        }
        public int MaxRange
        {
            get { return maxRange; }
            set
            {
                if (maxRange == 0)
                    Debug.LogWarning("Assign a value for maxRange");

                maxRange = value;
            }
        }

        private void Awake()
        {
            MinRange = this.minRange;
            MaxRange = this.maxRange;

            SetNumbers(MinRange, MaxRange);
        }

        public void SetNumbers(int min, int max)
        {
            for (int i = 0; i < respuestaScript.AllSlots.Count; i++)
            {
                int num1 = 0;
                int num2 = 0;

                do
                {
                    num1 = Random.Range(min, max);
                    num2 = Random.Range(min, max);
                } while (!Condition(num1 + num2));

                respuestaScript.AllSlots[i].Info = (num1 + num2).ToString();
                preguntaScript.AllPiezas[i].Info = $"{num1} + {num2}";
            }
        }

        public bool Condition(int input)
        {
            if (input % 10 == 0) return true; //multiplo de 10
            return false;
        }
    }
}

