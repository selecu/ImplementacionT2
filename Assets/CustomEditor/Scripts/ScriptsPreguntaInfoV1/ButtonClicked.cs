using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace v1
{
    public class ButtonClicked : MonoBehaviour
    {
        public static int value = -1;

        public void ClickedButton()
        {
            value = int.Parse(name) - 1;
        }
    }
}


