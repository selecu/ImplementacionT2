using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace I2935
{
    public class OnEndFishAnimation : StateMachineBehaviour
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            FishController fishesTarget = FindObjectOfType<FishController>();

            int fishValue = Random.Range(0, fishesTarget.fishes.Length);
            animator.GetComponent<FishAttributes>().fishValue = fishValue;

            float speedValue = animator.speed = Random.Range(fishesTarget.fishes[fishValue].minSpeed, fishesTarget.fishes[fishValue].maxSpeed);

            animator.GetComponent<Button>().interactable = true;
            Image imageTarget = animator.GetComponent<Image>();

            if (fishesTarget != null)
                fishesTarget.SelectFish(imageTarget, animator.GetComponent<Button>(), fishValue, speedValue);

            imageTarget.SetNativeSize();
        }
    }
}
