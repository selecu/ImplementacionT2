using UnityEngine;
using System.Collections;

namespace EdadDeLosPueblos.Static
{
    public class StaticHelper : MonoBehaviour
    {
        [SerializeField]
        private float holdTime;

        [SerializeField]
        [Tooltip("You choose which object going to be activated, in case is null, the object which is attached the script is going to be deactivated and then activated")]
        private GameObject targetObject;

        private void Start()
        {
            var target = targetObject ? targetObject : gameObject;

            target.SetActive(false);
        }

        public IEnumerator Timer()
        {
            yield return new WaitForSeconds(holdTime);

            var target = targetObject ? targetObject : gameObject;

            target.SetActive(true);
        }
    }
}

