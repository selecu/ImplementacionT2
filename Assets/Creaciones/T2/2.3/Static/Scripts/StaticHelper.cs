using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace EdadDeLosPueblos.Static
{
    public class StaticHelper : MonoBehaviour
    {
        [SerializeField]
        private float holdTime;

        [SerializeField]
        [Tooltip("You choose which object going to be activated, in case is null, the object which is attached the script is going to be deactivated and then activated")]
        private UnityEvent targetEvent;

        private IEnumerator Timer()
        {
            yield return new WaitForSeconds(holdTime);

            targetEvent.Invoke();
        }

        public void StartCounter() =>
            StartCoroutine(Timer());
    }
}

