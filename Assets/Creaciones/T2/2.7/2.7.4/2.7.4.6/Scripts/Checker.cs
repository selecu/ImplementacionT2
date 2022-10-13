using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Checker : MonoBehaviour
{
    public UnityEvent OnCorrect;
    public UnityEvent OnIncorrect;

    [SerializeField]
    private DropController[] dropControllers;
    void Start()
    {
        dropControllers = FindObjectsOfType<DropController>();
    }

    public void Check()
    {
        bool isCorrect = false;

        foreach (var item in dropControllers)
        {
            if (!item.CheckingInternalValues())
            {
                isCorrect = false;
                break;
            }
            else 
                isCorrect = true;
        }

        if (isCorrect)
            OnCorrect.Invoke();
        else
            OnIncorrect.Invoke();
    }
}
