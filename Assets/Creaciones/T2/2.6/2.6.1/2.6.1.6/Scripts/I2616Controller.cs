using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace I2616
{
    public class I2616Controller : MonoBehaviour
    {
        public enum GameCheckComprobation
        {
            InOrder,
            InDisorder
        }
        [Header("Game State"), Tooltip("Define si la comprobación se hará en orden o en desorden.")]
        public GameCheckComprobation gameCheckState = GameCheckComprobation.InDisorder;

        [Header("GameObjects References"), Space(20)]
        [SerializeField] private GameObject buttonCheck;
        [SerializeField] private GameObject buttonIntegrador;

        [Header("Sounds References"), Space(20)]
        public AudioSource audioSource;
        public AudioClip correctAudioClip;
        public AudioClip incorrectAudioClip;

        [Header("Lists"), Space(20)]
        public List<GameObject> correctSelection;
        [HideInInspector] public List<GameObject> currentSelection;

        /// ////////////////////Properties//////////////////////
        public GameObject ButtonCheck { get => buttonCheck; set => buttonCheck = value; }
        public GameObject ButtonIntegrador { get => buttonIntegrador; set => buttonIntegrador = value; }
        /// ///////////////////////////////////////////////////

        private void Start()
        {
            ButtonCheck.SetActive(true);
            ButtonIntegrador.SetActive(false);
        }

        public void SetAndPlayAudioSource(AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        public void AddObjectToCurrentSelection(GameObject obj) =>
            currentSelection.Add(obj);

        /// //////////////////////////////////////////////////////////////////
        public void OnButtonClick(Button thisButton)
        {
            thisButton.interactable = false;
            AddObjectToCurrentSelection(thisButton.gameObject);
        }
        /// //////////////////////////////////////////////////////////////////
        public void CheckInteraction()
        {
            bool isCorrect = false;

            if (gameCheckState == GameCheckComprobation.InOrder) isCorrect = ComprobationInOrder();
            else if (gameCheckState == GameCheckComprobation.InDisorder) isCorrect = ComprobationInDisorder();

            if (isCorrect) OnCorrect();
            else OnIncorrect();
        }
        protected bool ComprobationInOrder()
        {
            if (currentSelection.Count != correctSelection.Count) return false;
            for (int i = 0; i < currentSelection.Count; i++)
            {
                if (currentSelection[i] == correctSelection[i]) continue;
                return false;
            }
            return true;
        }
        protected bool ComprobationInDisorder()
        {
            bool flag = false;
            if (currentSelection.Count != correctSelection.Count) return false;
            foreach (GameObject item1 in correctSelection)
            {
                foreach (GameObject item2 in currentSelection)
                {
                    if (item1 == item2) { flag = true; break; }
                    flag = false;
                }
                if (flag == false) break;
            }
            return flag;
        }
        /// //////////////////////////////////////////////////////////////////
        private void OnCorrect()
        {
            SetAndPlayAudioSource(correctAudioClip);
            ButtonCheck.SetActive(false);
            ButtonIntegrador.SetActive(true);
        }
        private void OnIncorrect()
        {
            SetAndPlayAudioSource(incorrectAudioClip);
            ButtonCheck.SetActive(true);
            ButtonIntegrador.SetActive(false);
            ResetAllParameters();
        }
        private void ResetAllParameters()
        {
            foreach (GameObject item in currentSelection)
            {
                item.GetComponent<Button>().interactable = true;
            }
            currentSelection.Clear();
        }
    }
}
