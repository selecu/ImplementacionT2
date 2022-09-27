using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackmanager : MonoBehaviour
{

    public enum Feedback
    {
        T2, T3, T4, T5, T8, T9
    }

    public Feedback FeedbackTemp;

    public GameObject retroalm;
    public GameObject[] FeedbackObj;

    // Start is called before the first frame update
    void Start()
    {
        
        if (FeedbackTemp == Feedback.T2)
        {
            retroalm = FeedbackObj[0];
            FeedbackObj[0].SetActive(true);
        }

        if (FeedbackTemp == Feedback.T3)
        {
            retroalm = FeedbackObj[1];
            FeedbackObj[1].SetActive(true);
        }

        if (FeedbackTemp == Feedback.T4)
        {
            retroalm = FeedbackObj[2];
            FeedbackObj[2].SetActive(true);
        }

        if (FeedbackTemp == Feedback.T5)
        {
            retroalm = FeedbackObj[3];
            FeedbackObj[3].SetActive(true);
        }

        if (FeedbackTemp == Feedback.T8)
        {
            retroalm = FeedbackObj[4];
            FeedbackObj[4].SetActive(true);
        }

        if (FeedbackTemp == Feedback.T9)
        {
            retroalm = FeedbackObj[5];
            FeedbackObj[5].SetActive(true);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
