using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

namespace FloMania_vol1
{
    public class DD_pool : MonoBehaviour
    {

        public string ID_pool;
        public int limit_item;
        public bool start_pool;

        private GameObject item;
        // Start is called before the first frame update
        void Start()
        {
            LayerMask layer = LayerMask.GetMask("DD_Raycats");
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnMouseEnter()
        {
            //Debug.Log("esto es un pool");
        }

        private void OnMouseUp()
        {
            //Debug.Log("casi cae por aqui");
        }
    }
}

