using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using JetBrains.Annotations;
using Doozy.Engine.UI;

namespace I2633
{
    public class ControllerButtons : MonoBehaviour
    {
        [Header("Settings.")]
        [SerializeField, Tooltip("Define the number of buttons to press."), Space(15)] 
        private int totalButtons;

        [SerializeField, Tooltip("Object to show after press the value on 'totalButtons'."), Space(5)]
        private GameObject objectToActive;

        [HideInInspector]
        public int buttonsActivated;

        public GameObject ObjectToActive { get => objectToActive; set => objectToActive = value; }
        public int TotalButtons { get => totalButtons; set => totalButtons = value; }

        public void CheckingParameters()
        {
            if (TotalButtons == buttonsActivated)
            {
                ObjectToActive?.SetActive(true);
            }
        }

        public void IncrementInternalButtonsActivated() =>
            buttonsActivated++;
    }
}
