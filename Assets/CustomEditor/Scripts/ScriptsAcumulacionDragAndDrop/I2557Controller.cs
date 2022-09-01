using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace v1
{
    public class I2557Controller : MonoBehaviour
    {
        [Header("Range")]
        [SerializeField] private int minRange;
        [SerializeField] private int maxRange;

        [Header("Buttons")]
        [SerializeField] private GameObject buttonCheck;
        [SerializeField] private GameObject buttonIntegrador;

        [Header("UI Elements")]
        [SerializeField] private TMP_Text UIText;
        [SerializeField] private Image sliderImage;

        [Header("Booleans")]
        [SerializeField] private bool decenaCompleta;

        [SerializeField] private float correctValue;
        [SerializeField] private float currentValue;
        public GameObject[] ventanas;

        private void Start()
        {
            SetCorrectValue();
            UpdateUI();
            SetSliderImageValue();
        }

        private void Update()
        {
            if(sliderImage.fillAmount <= currentValue / correctValue)
                sliderImage.fillAmount += Time.deltaTime;
        }

        public void SetSliderImageValue() =>
            sliderImage.fillAmount = currentValue / correctValue;

        public void IncrementCurrentValue(int value) =>
            currentValue += value;
        public void SetCorrectValue()
        {
            if (decenaCompleta)
            {
                do
                {
                    correctValue = Random.Range(minRange, maxRange);
                } while (correctValue % 10 != 0);
            }
            else correctValue = Random.Range(minRange, maxRange);

        }
            

        public void UpdateUI() =>
            UIText.text = correctValue.ToString();


        public void Check()
        {
            if (correctValue == currentValue)
            {
                buttonCheck.SetActive(false);
                buttonIntegrador.SetActive(true);
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.correcto.Play();
                ventanas[0].SetActive(true);
            }
            else
            {
                currentValue = 0;
                SetCorrectValue();
                UpdateUI();
                SetSliderImageValue();
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.incorrecto.Play();
                ventanas[1].SetActive(true);
                StartCoroutine(Waiting());
            }
        }

        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(5);
            ventanas[1].SetActive(false);
            StopCoroutine(Waiting());
        }
    }
}
