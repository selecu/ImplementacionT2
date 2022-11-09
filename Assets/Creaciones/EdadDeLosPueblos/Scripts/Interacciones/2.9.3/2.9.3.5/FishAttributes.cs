using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace I2935
{
    [RequireComponent(typeof(Animator))]
    public class FishAttributes : MonoBehaviour
    {
        private FishController controller;
        public int fishValue;

        private void Awake()
        {
            controller = FindObjectOfType<FishController>();
        }

        public void OnSelect() =>
            controller.fishes[fishValue].OnSelectFish.Invoke();
    }
}
