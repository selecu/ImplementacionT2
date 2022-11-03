using UnityEngine;
using System.Collections;

namespace EdadDeLosPueblos.Static
{
    public class StaticHelper : MonoBehaviour
    {
        public enum States
        {
            [InspectorName("Evaluate Function On Start")]
            OnStart,
            [InspectorName("Custom Evaluation")]
            Custom
        }

        [SerializeField]
        [Tooltip("Parameter used to tell the script at what time to execute the Timer coroutine.")]
        private States stateEvaluation = States.OnStart;

        [SerializeField, Space(15)]
        private float holdTime;

        [SerializeField]
        [Tooltip("You choose which object going to be activated, in case is null, the object which is attached the script is going to be deactivated and then activated")]
        private GameObject targetObject;

        private void Start()
        {
            var target = targetObject ? targetObject : gameObject;

            target.SetActive(false);

            if (stateEvaluation == States.OnStart)
                StartCoroutine(Timer());
        }

        public IEnumerator Timer()
        {
            yield return new WaitForSeconds(holdTime);

            var target = targetObject ? targetObject : gameObject;

            target.SetActive(true);
        }
    }
}

