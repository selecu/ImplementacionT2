using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

namespace MyNamespace
{

    [System.Serializable]
    public class ValueSlot
    {
        public string id2;
        public Sprite Icon;
        [TextArea]
        public string Info;

    }


    public class RepuestasManagerSlot : MonoBehaviour
    {
        public List<ValueSlot> AllSlots;

        // Start is called before the first frame update
        void Start()
        {
            GameObject SlotTemplate = transform.GetChild(0).gameObject;
            GameObject g;

            int N = AllSlots.Count;

            for (int i = 0; i < N; i++)
            {
                g = Instantiate(SlotTemplate, transform);
                g.transform.GetChild(0).GetComponent<Image>().sprite = AllSlots[i].Icon;
                g.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = AllSlots[i].Info;
                g.transform.GetChild(1).GetComponent<SlotManager>().id = AllSlots[i].id2;
                g.transform.GetChild(2).GetComponent<SlotManager>().id = AllSlots[i].id2;
                g.transform.GetChild(3).GetComponent<SlotManager>().id = AllSlots[i].id2;


            }

            Destroy(SlotTemplate);
        }

    }

}
