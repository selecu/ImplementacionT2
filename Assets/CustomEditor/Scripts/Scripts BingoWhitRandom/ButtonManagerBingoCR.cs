using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




namespace BingoCR
{ 
    public class ButtonManagerBingoCR : MonoBehaviour
    {
        public static int value = 1;
        public static int counter = 0;
     
        public void Compare()
        {

            GameManagerBingoCR.nameButton = transform.GetComponentInChildren<TMP_Text>().text;
            value = int.Parse(name);
            GameManagerBingoCR.FindObjectOfType<GameManagerBingoCR>().Verify(this.gameObject.GetComponent<Button>());
        }

        public void ClickCounter()
        {
            counter++;
        }
    }

}
