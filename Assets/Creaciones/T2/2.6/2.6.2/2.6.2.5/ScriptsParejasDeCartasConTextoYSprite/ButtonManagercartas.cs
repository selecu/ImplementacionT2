using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace I2625
{
    public class ButtonManagercartas : MonoBehaviour
    {
        public static int idZero = -1;
        public static int idOne = -1;
        public static int state = 1;

        public void Click()
        {
            state = (state + 1) % 2;
            var id = int.Parse(name);
            if (state == 0)
            {
                idZero = id;
            }
            else
            {
                idOne = id;
            }
            transform.GetComponent<Button>().enabled = false;
        }
    }
}
