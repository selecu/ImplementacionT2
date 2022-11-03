using UnityEngine;

namespace Static.Feedback
{
    public class Feedback : MonoBehaviour
    {

        [SerializeField]
        private Dicothomy defaultConfiguration;

        [SerializeField]
        [Tooltip("El padre de los triggers de este Feedback en caso de ser necesario, se puede dejar null, pero inmediatamente buscará por un objeto que tenga el nombre Triggers")]
        private Transform triggers;

        private Animator animator;

        private Dicothomy storedValue;

        private void OnValidate()
        {
            storedValue = defaultConfiguration;
            ConfigureObjects();
        }

        private void Start()
        {
            if(!triggers)
                triggers = GameObject.Find("Triggers").transform;

            triggers.GetChild(0).GetComponent<PostActivator>().SetFeedbackModule(this);
            triggers.GetChild(1).GetComponent<PostActivator>().SetFeedbackModule(this);
        }

        public void CreateState(Dicothomy trigger)
        {

            storedValue = trigger;

            ConfigureObjects();

            if(Application.isPlaying)
                GetComponent<Animator>().SetTrigger("Appear");
        }

        public void ConfigureObjects()
        {
            int index = (int) storedValue;

            int counter = (int) storedValue == 1 ? 2 : 1;

            transform.GetChild(1).GetChild(index).gameObject.SetActive(true);
            transform.GetChild(1).GetChild(counter).gameObject.SetActive(false);
        }
    }
}
