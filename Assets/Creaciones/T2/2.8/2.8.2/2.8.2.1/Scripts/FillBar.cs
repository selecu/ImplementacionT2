using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace I2821
{
    [RequireComponent(typeof(v1.SeleccionController))]
    public class FillBar : MonoBehaviour
    {
        public int currentButtonClicked = 0;
        public int maxButtonClicked = 3;

        public v1.SeleccionController seleccionController;
        [SerializeField] private Image imageToFill;
        [SerializeField] private int totalFillValue;

        private void Start()
        {
            currentButtonClicked = 0;
        }
        private void OnValidate()
        {
            if (!seleccionController)
                seleccionController = GetComponent<v1.SeleccionController>();
        }

        public void ResetCurrentButtonClicked() =>
            currentButtonClicked = 0;
        public void IncrementCurrentButtonClicked()
        {
            currentButtonClicked++;

            if (currentButtonClicked == maxButtonClicked + 1)
            {
                currentButtonClicked = 0;

                ResetFill();

                seleccionController.SetAndPlayAudioSource(seleccionController.incorrectAudioClip);

                foreach (GameObject item in seleccionController.currentSelection)
                {
                    item.GetComponent<Button>().interactable = true;
                }
                seleccionController.currentSelection.Clear();
            }
        }
        public void FillOnButton(int value) =>
            imageToFill.fillAmount += (float)value / (float)totalFillValue;

        public void ResetFill() =>
            imageToFill.fillAmount = 0;
        public void Check()
        {
            bool isCorrect = false;

            isCorrect = ComprobationInDisorder();

            if (!isCorrect) ResetFill();
        }
        protected bool ComprobationInDisorder()
        {
            bool flag = false;
            if (seleccionController.currentSelection.Count != seleccionController.correctSelection.Count) return false;
            foreach (GameObject item1 in seleccionController.correctSelection)
            {
                foreach (GameObject item2 in seleccionController.currentSelection)
                {
                    if (item1 == item2) { flag = true; break; }
                    flag = false;
                }
                if (flag == false) break;
            }
            return flag;
        }
    }

}