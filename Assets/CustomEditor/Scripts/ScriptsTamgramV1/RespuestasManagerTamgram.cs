using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;




namespace v1
{

    [System.Serializable]
    public class SlotsTangram
    {
        public string id2;
        public Sprite Icon;
        [TextArea]
        public string Info;

    }
    public class RespuestasManagerTamgram : MonoBehaviour

    {
        public List<SlotsTangram> AllSlots;




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
                g.transform.GetChild(1).GetComponent<Text>().text = AllSlots[i].Info;
                g.transform.GetComponent<DropSlotTamgram>().id = AllSlots[i].id2;


            }

            Destroy(SlotTemplate);
        }

        // Update is called once per frame
        void Update()
        {

        }



    }
}

