using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace v1
{
    public class GasolinaController : MonoBehaviour
    {
        public Slider gasolinaSlider;
        public static GasolinaController instance;
        float maxGasolina;
        // Start is called before the first frame update
        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            maxGasolina = 100;
            gasolinaSlider.maxValue = maxGasolina;
            gasolinaSlider.value = Random.Range(10, 20);
        }
        public void GasolinaValue(float num, float den)
        {
            float val = (num / den) * 100;


            gasolinaSlider.value += val;
        }

        void Update()
        {

        }
    }

}
