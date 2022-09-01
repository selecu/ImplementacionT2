using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace v1
{
    public class PeceraTimer_StartScript : MonoBehaviour
    {
        public static PeceraTimer_StartScript instance;

        // public List<Sprite> Images = new List<Sprite>();


        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            PeceraTimer_ContainerImageView.instance.Setup();

        }
    }

}
