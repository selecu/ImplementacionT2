using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace v1
{
    public class SandTimer_StartScript : MonoBehaviour
    {
        // Start is called before the first frame update
        public Text[] cantidades;
        public int minLimit;
        public int maxLimit;

        void Start()
        {
            LimitAG();
        }

        // Update is called once per frame
        void Update()
        {

        }


        public void LimitAG()
        {
            for (int i = 0; i < cantidades.Length; i++)
            {
                int Randomindex = UnityEngine.Random.Range(minLimit, maxLimit);
                cantidades[i].text = Randomindex.ToString();
            }
        }
    }
}

