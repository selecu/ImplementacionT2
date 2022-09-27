using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Runtime.InteropServices;

namespace EdadDeLosPueblos.Static
{
    public enum States
    {
        EvaluateOnStart,
        CustomEvaluation
    }

    public class StaticHelper : MonoBehaviour
    {
        [Header("Script States")]
        [SerializeField]
        public States scriptState;

        [SerializeField, Space(15)]
        private float holdTime;

        [SerializeField]
        [Tooltip("You choose which object going to be activated, in case is null, the object which is attached the script is going to be deactivated and then activated")]
        private GameObject targetObject;

        private void Start()
        {
            var target = targetObject ? targetObject : gameObject;

            target.SetActive(false);

            if (scriptState == States.EvaluateOnStart) StartCoroutine("Timer");
        }

        public IEnumerator Timer()
        {
            yield return new WaitForSeconds(holdTime);

            var target = targetObject ? targetObject : gameObject;

            target.SetActive(true);
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(StaticHelper))]
    public class CustomGUILayout:Editor
    {
        public override void OnInspectorGUI()
        {
            StaticHelper staticHelper = (StaticHelper)target;
            base.OnInspectorGUI();

            if (staticHelper.scriptState == States.CustomEvaluation)
            {
                EditorGUILayout.Space(15);
                EditorGUILayout.HelpBox("The void 'Timer' start the coroutine and you can use this script to do it.", MessageType.Info);
            }
            else
            {
                EditorGUILayout.Space(15);
                EditorGUILayout.HelpBox("The void 'Timer' on this script will be invoked on start.", MessageType.Warning);
            }
        }
    }
#endif
}

