using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControllerRegletas : MonoBehaviour
{
    public Animator m_Animator;
    public GameObject gb;

    public void TutorialIn()
    {
        gb.SetActive(true);
    }

    public void TutorialOut()
    {
         m_Animator.SetBool("Out", true);
    }
}
