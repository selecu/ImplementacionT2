using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace v1
{
    public class InfoCardScript : MonoBehaviour
    {

        Animator anim;

        void Start()
        {
            anim = GetComponent<Animator>();
            StartCoroutine(SelfControl());
        }

        IEnumerator SelfControl()
        {
            yield return new WaitForSeconds(GameManagerCartas.infoWaitTime);
            anim.SetBool("Out", true);
        }

        void Update()
        {
            if (GameManagerCartas.infoState)
            {
                StartCoroutine(SelfControl());
                GameManagerCartas.infoState = false;
            }

        }
    }
}


