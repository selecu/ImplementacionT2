using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace v1
{
        public class MultipleButtoms : MonoBehaviour
        {
            [SerializeField] private bool correct;
            VerfyCorrectMultiple manager;
            public bool Correct { get => correct; set => correct = value; }

        // Start is called before the first frame update
        void Start()
        {
            manager = FindObjectOfType<VerfyCorrectMultiple>();
        }

        public void click()
        {
            if (Correct)
            {
                GetComponent<Image>().sprite = manager.SpriteCorrect;
                manager.click();
            }
        }
    }
}
