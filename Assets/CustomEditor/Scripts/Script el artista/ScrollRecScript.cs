using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRecScript : MonoBehaviour
{
    private ScrollRect m_scrollRect;
    private bool moseDown, buttonDow, buttonUp,buttonRight,buttonLeft;
    [SerializeField]private float speedUp;
    [SerializeField]private float SpeedDown;

    [SerializeField] private int CountRight;
    [SerializeField] private int CountLeft;
    private int Index;


    void Start()=> 
        m_scrollRect = GetComponent<ScrollRect>();
    

    // Update is called once per frame
    void Update()
    {
        if (moseDown)
        {
            if (buttonDow)
            {
                ScrollDown();
            }
            else if(buttonUp)
            {
                ScrollUp();
            }
            else if (buttonRight)
            {
                ScrollRight();
            }
            else if (buttonLeft)
            {
                ScrollLeft();
            }
        }
    }
    public void ButtonDownIsPressed()
    {
        moseDown = true;
        buttonDow = true;
    }
    public void ButtonUpIspressed()
    {
        moseDown = true;
        buttonUp = true;
    }
    public void ButtonRightIspressend()
    {
        moseDown = true;
        buttonRight = true;
    }
    public void ButtonLeftIspressed()
    {
        moseDown = true;
        buttonLeft = true;
    }
    private void ScrollDown()
    {
        if ( Input.GetMouseButtonUp(0))
        {
            moseDown = false;
            buttonDow = false;
        }
        else
        {
            m_scrollRect.verticalNormalizedPosition -= speedUp;
        }
    }
    private void ScrollUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            moseDown = false;
            buttonUp = false;
        }
        else
        {
            m_scrollRect.verticalNormalizedPosition += SpeedDown;
        }
    }
    private void ScrollRight()
    {
        
        if (Input.GetMouseButtonDown(0) && Index < CountRight)
        {

            Index ++;
            print(Index);
            m_scrollRect.horizontalNormalizedPosition += SpeedDown;
            moseDown = false;
            buttonRight = false;
           
        }
        else
        {
            moseDown = false;
            buttonRight = false;
        }

       
    }
    private void ScrollLeft()
    {
       
        if (Input.GetMouseButtonDown(0) && Index > CountLeft)
        {
           
            Index--;
            print(Index);
            m_scrollRect.horizontalNormalizedPosition -= speedUp;
            moseDown = false;
            buttonLeft = false;
        }
        else
        {
            moseDown = false;
            buttonLeft = false;
        }
       
        

      
    }
}
