using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace v1
{
    public class Linterna_StartScript : MonoBehaviour
    {
        // Start is called before the first frame update
        float time;
        public float gameTime;
        //bool stoptimer;
        public GameObject CheckButton;
        public GameObject ventana;

        // Start is called before the first frame update
        void Start()
        {
            //stoptimer = false;
            //CheckButton = GameObject.Find("CheckButton");
            CheckButton.SetActive(false);

        }

        // Update is called once per frame
        void Update()
        {
            time = gameTime - Time.timeSinceLevelLoad;
            if (time <= 0)
            {
                //stoptimer = true;
                CheckButton.SetActive(true);
                ventana.SetActive(true);
               
            }

        }

       
    }

}

