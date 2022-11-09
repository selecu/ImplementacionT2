using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace T2.implementation.buttons
{
    public enum ComponentToAffect
    {
        GameObject,
        Button
    }
    public class ActiveWithButtonCount : MonoBehaviour
    {
        [Header("Componen referenced.")]
        public ComponentToAffect componentAffected = ComponentToAffect.GameObject;

        [SerializeField, Space(15)]
        [Tooltip("Number of click needed to show the object referenced.")] private int numberOfClicks = 1;
        [HideInInspector] public int currentClicks = 0;
        [SerializeField, Space(5)]
        [Tooltip("Referenced object to show after last-click.")] private GameObject objectToShow;

        public int NumberOfClicks { get => numberOfClicks; set => numberOfClicks = value; }
        public GameObject ObjectToShow { get => objectToShow; set => objectToShow = value; }

        private void Start()
        {
            if (componentAffected == ComponentToAffect.GameObject)
                ObjectToShow.SetActive(false);
            else if (componentAffected == ComponentToAffect.Button)
                ObjectToShow.GetComponent<Button>().interactable = false;
        }

        public void ComprobationToShow(bool state)
        {
            if (currentClicks == NumberOfClicks && componentAffected == ComponentToAffect.GameObject)
                ObjectToShow.SetActive(state);
            else if (currentClicks == NumberOfClicks && componentAffected == ComponentToAffect.Button)
                ObjectToShow.GetComponent<Button>().interactable = state;
        }

        public void IncrementCurrentClicks() =>
            currentClicks++;

        public void ResetShowAfterPress() =>
            NumberOfClicks = 0;
    }
}
