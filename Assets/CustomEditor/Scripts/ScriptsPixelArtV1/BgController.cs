using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace v1
{
    public class BgController : MonoBehaviour
    {
        GameObject Draw_Canvas;
        Image Draw_Canvas_Image;
        public Sprite m_Sprite;
        bool Canvas_Trigger;
        // Start is called before the first frame update
        void Start()
        {
            Draw_Canvas = GameObject.Find("DrawCanvas");
            Draw_Canvas_Image = Draw_Canvas.GetComponent<Image>();
            Draw_Canvas_Image.sprite = m_Sprite;
            Canvas_Trigger = false;

        }

        public void clearBG()
        {
            Canvas_Trigger = !Canvas_Trigger;
            if (Canvas_Trigger == true)
                Draw_Canvas_Image.sprite = null;
            else
                Draw_Canvas_Image.sprite = m_Sprite;

        }

    }

}
