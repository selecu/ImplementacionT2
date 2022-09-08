using I2552;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace I2552
{
    public class OnEndBoat : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!I2552GameManager.gameRunning)
            {
                animator.transform.gameObject.SetActive(false);
                return;
            }
            animator.speed = Random.Range(I2552GameManager.minSpeed, I2552GameManager.maxSpeed);
            animator.transform.GetComponent<Button>().interactable = true;
        }
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.transform.GetComponentInChildren<TMP_Text>().text = I2552GameManager.ChooseOneRandomLetter(I2552GameManager.frecuency);
        }
    }
}
