using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace v1
{
    public class ButtonManagerdigital : MonoBehaviour
    {
        Image img;
        public int id;
        public GameManagerdigital set;

        void Start()
        {
            img = gameObject.GetComponent<Image>();
        }

        void Update()
        {
            try 
            {
                if(GameManagerdigital.done[id] == 1)
                {
                    img.color = new Color(0.2f,0.36f,0.36f,1f);
                    
                }
                if(GameManagerdigital.done[id] == 0){
                    img.color = new Color(255,255,255,255);
                }
            } catch (Exception e){
                Debug.Log(e);
            }

            

        }

        public void click()
        {
            GameManagerdigital.done[id] = GameManagerdigital.done[id] == 0 ? 1 : 0;
            set.intentos++;
        }

        public void ResetImg()
        {
            GameManagerdigital.done[id] = GameManagerdigital.done[id] == 0 ? 0 : 0;
            Debug.Log("fddf");
        }
    }
}

