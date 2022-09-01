using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace v1
{
    public class EraserControl : MonoBehaviour
    {
        public static bool eraser;
        // Start is called before the first frame update
        void Start()
        {
            eraser = true;
        }


        public void eras(bool borrar)
        {
            eraser = borrar;
        }
        // Update is called once per frame
        void Update()
        {

        }
    }

}

