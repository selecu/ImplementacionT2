using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace v1
{
    public class ConectarPointDraw_ButtonController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SendPoint()
        {
            Transform point = gameObject.transform.GetChild(0).GetComponent<Transform>();
            ConectarConectarPointDraw_LrTestigScript.instance.NewPoint(point);
            QuestionGenerator_PointDraw.instance.ActivateQuestion(gameObject.name);
            if (gameObject.name != "Button (24)")
            {
                gameObject.GetComponent<Button>().interactable = false;
            }
        }
    }
}


