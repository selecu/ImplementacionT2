using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using v1;



namespace v1
{
    public class ButtonManagerBingo : MonoBehaviour
    {
        public static int value = 1;
        public static int counter = 0;

        public void Compare()
        {
            value = int.Parse(name);
        }

        public void ClickCounter()
        {
            counter++;
        }
    }

}
