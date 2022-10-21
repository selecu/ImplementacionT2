using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interactions.DeciferTheCode.Mechanics
{
    public class RotateRoulette : MonoBehaviour
    {
        public GameObject clampedObject;
        public static float speed;
        bool pointerBoolean;
        void FixedUpdate()
        {
            if (this.pointerBoolean)
            {
                if (Input.GetButton("Fire1"))
                {
                    RotateMethod(speed);
                }
            }
        }

        protected void RotateMethod(float speed)
        {
            float zAxies = Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;


            transform.Rotate(Vector3.forward, zAxies);

            if(clampedObject)
                clampedObject.transform.Rotate(Vector3.forward, zAxies);
        }

        public void OnPointer(bool boolean) =>
            pointerBoolean = boolean;
    }
}
