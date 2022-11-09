using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace I2935
{
    public class DesactiveOnEnable : MonoBehaviour
    {
        public GameObject target;
        public bool state;

        private void OnEnable()
        {
            target.SetActive(state);
        }
    }
}
