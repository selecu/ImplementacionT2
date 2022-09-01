using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace v1
{
    public class Color_Controller : MonoBehaviour
    {
        // private GameObject pen;
        public GameObject CanvasColor;

        public static bool ColorState;
        public static string colorInList;
        public string[] colors;

        void Start()
        {
            ColorState = false;
            CanvasColor.SetActive(ColorState);
            colorInList = colors[0];
        }

        public void ColorPicker(int position)
        {

            colorInList = colors[position];
            CanvasColor.SetActive(false);
            // pen.SetActive(true);
        }

        public void ActivarColor()
        {
            //pen.SetActive(false);
            ColorState = !ColorState;
            CanvasColor.SetActive(ColorState);
        }

    }

}
