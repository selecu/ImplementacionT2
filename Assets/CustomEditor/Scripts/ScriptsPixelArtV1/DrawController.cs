using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using v1;

namespace v1
{
    public class DrawController : MonoBehaviour
    {

        private Image ImageRenderer;
        Color colorchoose;
        public bool erase;


        void Start()
        {
            //ColorController = Colorpicker.GetComponent<Color_Controller>();
            erase = EraserControl.eraser;
            ImageRenderer = GetComponent<Image>();
            colorchoose = Color.black;
        }

        void Update()
        {
            erase = EraserControl.eraser;

        }

        /* void OnTriggerStay2D (Collider2D other)
        {
            // print (other.name);

            ColorUtility.TryParseHtmlString(Color_Controller.colorInList, out colorchoose);

            if (other.gameObject.tag =="pen" && Input.GetMouseButton(0) && erase == true )
            {
               //Debug.Log("collision");

               colorchoose.a = 1f;
               ImageRenderer.color = colorchoose;
            }else if (other.gameObject.tag =="pen" && Input.GetMouseButton(0) && erase == false )
            {
               colorchoose.a = 0f;
               ImageRenderer.color = colorchoose;
               //Debug.Log(colorchoose.a);
            }

        }*/

        public void draw()
        {
            ColorUtility.TryParseHtmlString(Color_Controller.colorInList, out colorchoose);

            if (Input.GetMouseButton(0) && erase == true)
            {
                colorchoose.a = 1f;
                ImageRenderer.color = colorchoose;

            }
            else if (Input.GetMouseButton(0) && erase == false)
            {
                colorchoose.a = 0f;
                ImageRenderer.color = colorchoose;
                //Debug.Log(colorchoose.a);
            }
        }

    }

}
