using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace v1
{
    public class RandomFraction : MonoBehaviour
    {
        public GameObject[] Gasolinas;
        public List<int> numeradores;
        public List<int> denominadores;

        [SerializeField]
        int numeradormin;
        [SerializeField]
        int numeradormax;

        [Space(10)]

        [SerializeField]
        int denominadormin;
        [SerializeField]
        int denominadormax;


        void Start()
        {
            for (int i = 0; i < Gasolinas.Length; i++)
            {
                int value1 = Random.Range(numeradormin, numeradormax);
                int value2 = Random.Range(value1 + denominadormin, denominadormax);

                Gasolinas[i].transform.GetChild(0).GetComponent<Text>().text = value1.ToString();
                Gasolinas[i].transform.GetChild(1).GetComponent<Text>().text = value2.ToString();
                numeradores.Add(value1);
                denominadores.Add(value2);
            }
        }
    }

}

