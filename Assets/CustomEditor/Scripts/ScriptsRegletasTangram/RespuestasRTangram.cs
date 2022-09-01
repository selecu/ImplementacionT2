using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


[Serializable]
public class SRtangram
{
    public string id2R;
    public Sprite IconR;
    [TextArea]
    public string InfoR;
    
}

namespace v2
{
    public class RespuestasRTangram : MonoBehaviour

    {
        public List<SRtangram> AllSlotsR;




        // Start is called before the first frame update
        void Start()
        {
            GameObject SlotTemplate = transform.GetChild(0).gameObject;
            GameObject g;

            int N = AllSlotsR.Count;

            for (int i = 0; i < N; i++)
            {
                g = Instantiate(SlotTemplate, transform);
                g.transform.GetChild(0).GetComponent<Image>().sprite = AllSlotsR[i].IconR;
                g.transform.GetChild(1).GetComponent<Text>().text = AllSlotsR[i].InfoR;
                g.transform.GetComponent<DropSlotDragandDropRtangram>().id = AllSlotsR[i].id2R;


            }

            Destroy(SlotTemplate);
        }

        // Update is called once per frame
        void Update()
        {

        }



    }
}

