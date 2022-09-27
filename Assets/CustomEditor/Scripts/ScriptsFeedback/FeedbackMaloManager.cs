using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackMaloManager : MonoBehaviour
{
    public GameObject ventana;
    public GameObject button;
    public GameObject feedback;

    public Sprite[] cartel;
    public Sprite[] buttons;
    public Sprite[] feedbacks;

    int butonrange;
    int feedbackrange;



    // Start is called before the first frame update
    void Start()
    {

        butonrange = Random.Range(0, 1);
        feedbackrange = Random.Range(0, 5);
        ventana.GetComponentInChildren<Image>().sprite = cartel[0];
        button.GetComponentInChildren<Image>().sprite = buttons[butonrange];
        feedback.GetComponentInChildren<Image>().sprite = feedbacks[feedbackrange];


    }

    // Update is called once per frame
    void Update()
    {

    }
}
