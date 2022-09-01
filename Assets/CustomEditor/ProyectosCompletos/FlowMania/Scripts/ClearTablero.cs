using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace FloMania_vol1
{
    public class ClearTablero : MonoBehaviour
    {

        public DD_item_Drop[] Allchildren;


        private void Awake()
        {
            StartCoroutine(ASG());
        }

        // Start is called before the first frame update
        void Start()
        {


        }

        // Update is called once per frame

        void Update()
        {







        }

        public void eliminar()
        {
            GameObject[] hijos = GameObject.FindGameObjectsWithTag("casilla");
            foreach (var item in hijos)
            {
                item.SetActive(false);

            }



            StartCoroutine(ASG());

        }

        IEnumerator ASG()
        {
            yield return new WaitForSeconds(1);
            Allchildren = FindObjectsOfType<DD_item_Drop>();
            foreach (var item in Allchildren)
            {
                item.Start();
            }
        }
    }
    
    
}

