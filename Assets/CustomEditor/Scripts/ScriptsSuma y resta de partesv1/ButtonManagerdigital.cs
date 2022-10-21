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
        public Color defaultColor;
        public Color colorActive ;

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
                    img.color = colorActive;
                    
                }
                if(GameManagerdigital.done[id] == 0){
                    img.color = defaultColor;
                }
            } catch (Exception e)
            {
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

