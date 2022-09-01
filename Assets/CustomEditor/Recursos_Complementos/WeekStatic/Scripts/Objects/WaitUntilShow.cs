using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PersonalInterface
{
    public class WaitUntilShow : MonoBehaviour
    {
        [SerializeField] private GameObject objectToShow;
        [SerializeField] private float waitTime;
        [SerializeField] private bool enabledState;

        private void Start()
        {
            StartCoroutine(ShowElementAfter(objectToShow, waitTime, enabledState));
        }

        IEnumerator ShowElementAfter(GameObject obj, float waitToShow, bool enabled)
        {
            yield return new WaitForSeconds(waitToShow);
            obj.SetActive(enabled);
        }
    }
}
