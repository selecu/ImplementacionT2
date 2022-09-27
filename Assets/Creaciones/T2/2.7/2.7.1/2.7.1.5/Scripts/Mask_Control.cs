using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace I2715
{
    public class Mask_Control : MonoBehaviour
    {
        public GameObject frontObject;
        public GameObject backObject;

        Vector3 posFrontObject;

        void Awake()
        {
            posFrontObject = frontObject.transform.position;
        }

        void Update()
        {
            backObject.transform.position = posFrontObject;
        }
    }
}

