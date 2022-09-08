using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using v1;

namespace I2654
{
    public class I2654Controller : MonoBehaviour
    {
        [HideInInspector]
        public AnswerCreator answerCreator;

        [HideInInspector]
        public QuezCreator quezCreator;

        [SerializeField] private int minRange = 1;
        [SerializeField] private int maxRange = 100;

        private void Awake()
        {
            answerCreator = FindObjectOfType<AnswerCreator>();
            quezCreator = FindObjectOfType<QuezCreator>();

            SetAllValues();
        }

        public void SetAllValues()
        {
            for (int i = 0; i < quezCreator.AllPreguntas.Count; i++)
            {
                int num1 = 0;
                int num2 = 0;

                do
                {
                    num1 = Random.Range(minRange, maxRange);
                    num2 = Random.Range(minRange, maxRange);
                } while (CheckConditions(num1, num2));

                quezCreator.AllPreguntas[i].Info = $"{num1} + {num2}";
                quezCreator.AllPreguntas[i].id1 = (num1 + num2).ToString();

                answerCreator.AllRespuestas[i].Info = (num1 + num2).ToString();
                answerCreator.AllRespuestas[i].id2 = (num1 + num2).ToString();
            }
        }

        public bool CheckConditions(int num1, int num2)
        {
            if ((num1 + num2) % 10 != 0) return true;
            return false;
        }
    }
}
