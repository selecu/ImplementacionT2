using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace v1
{
    public class cursorControl : MonoBehaviour
    {
        // Start is called before the first frame update
        //private GameObject pen;
        //public Texture2D cursorTexture;
        public CursorMode cursorMode = CursorMode.Auto;
        public Vector2 hotSpot = Vector2.zero;


        void Start()
        {
            //Cursor.visible = false; 
            // pen = GameObject.FindGameObjectWithTag("pen");
            // pen.SetActive(false);
        }

        void OnMouseOver()
        {
            // Vector2 cursorpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // pen.transform.position = cursorpos;
        }
        void OnMouseEnter()
        {
            // Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            // pen.SetActive(true);

        }

        void OnMouseExit()
        {
            //pen.SetActive(false);
        }

        void Update()
        {
            // Vector2 cursorpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // pen.transform.position = cursorpos;
        }
    }

}
