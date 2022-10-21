using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Interactions.DeciferTheCode
{
    public class RandomizeBox : MonoBehaviour
    {
        [SerializeField] private bool randomBox;
        void Start()
        {
            float rnd = Random.Range(0.0f, 360.0f);
            if (randomBox)
            {
                transform.GetChild(0).rotation = Quaternion.Euler(0, 0, rnd);
                transform.GetChild(2).rotation = Quaternion.Euler(0, 0, rnd);
            }
        }
    }
}