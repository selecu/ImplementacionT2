using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace v1
{
    public class DragController : MonoBehaviour
    {
        [Header("Scripts")]
        [SerializeField] private v1.I2557Controller controller;

        [Header("Values")]
        [SerializeField] private int valueDrop;

        public void OnDropElement()
        {
            controller.IncrementCurrentValue(valueDrop);
        }
            

    }
}
