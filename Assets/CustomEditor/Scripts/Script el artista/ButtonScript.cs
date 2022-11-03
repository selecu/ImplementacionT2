using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonScript : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] private ScrollRecScript scrollRecScript;

    [SerializeField] private bool isDownButton;
    [SerializeField] private bool isRightAndLeft;

    public void OnPointerDown (PointerEventData eventData)
    {
        if (!isRightAndLeft)
        {
            if (isDownButton)
            {
                scrollRecScript.ButtonDownIsPressed();
            }
            else
            {
                scrollRecScript.ButtonUpIspressed();
            }

        }
        else
        {
            
            if (isDownButton)
            {
               
                scrollRecScript.ButtonRightIspressend();             
            }
            else 
            {
                
                scrollRecScript.ButtonLeftIspressed();
            }
        }
    }
}
