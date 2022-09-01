using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace v1
{
    public class PuzzleDomino_RandomActivate : MonoBehaviour
    {
        public GameObject[] SlotsList;
        public string Tag;

        void Awake()
        {
            SlotsList = GameObject.FindGameObjectsWithTag(Tag);
        }
        void Start()
        {



        }


        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < SlotsList.Length; i++)
            {
                SlotsList[Random.Range(0, SlotsList.Length)].transform.SetParent(gameObject.transform);
                /* int rnd = Random.Range(0, SlotsList.Length);
                 if(!SlotsList[rnd].activeSelf) SlotsList[rnd].SetActive(true);
                 else i--; // repeat loop iteration to try and find a disabled coin*/
            }
        }
    }

}