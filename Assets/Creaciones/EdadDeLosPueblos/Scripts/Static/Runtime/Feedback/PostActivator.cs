using System;
using UnityEngine;

namespace Static.Feedback
{

    public enum Dicothomy
    {
        Right = 1,
        Wrong = 2,
    }

    public class PostActivator : MonoBehaviour
    {
        [SerializeField]
        private Dicothomy trigger;

        private Feedback feedback;

        private void OnEnable()
        {
            feedback.CreateState(trigger);
            gameObject.SetActive(false);
        }

        private void OnValidate() =>
            name = $"{(int)trigger}";

        public void SetFeedbackModule(Feedback fb) =>
            feedback = fb;

    }
}
