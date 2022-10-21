using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace v1.color
{
    [System.Serializable]
    public class PRtangram1
    {
        public string id1;
        public Color imageColor;
        public Sprite Icon;
        [TextArea]
        public string Info;

    }

    public class PreguntaManagerR : MonoBehaviour
    {


        public List<PRtangram1> AllPiezas;




        private void Shuffle<T>(List<T> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                T temp = list[i];
                int rnd = UnityEngine.Random.Range(i, list.Count);
                list[i] = list[rnd];
                list[rnd] = temp;
            }
        }



        void Start()
        {
            Instance();

        }

        public void Instance()
        {
            Shuffle(AllPiezas);

            GameObject PiezaTemplate = transform.GetChild(0).gameObject;
            GameObject g;

            int N = AllPiezas.Count;
            PiezaTemplate.SetActive(true);
            for (int i = 0; i < N; i++)
            {
                g = Instantiate(PiezaTemplate, transform);
                g.transform.GetChild(0).GetComponent<Image>().color = AllPiezas[i].imageColor;
                g.transform.GetChild(0).GetComponent<Image>().sprite = AllPiezas[i].Icon;
                g.transform.GetChild(1).GetComponent<Text>().text = AllPiezas[i].Info;
                g.transform.GetComponent<DragHandlerDragandDrop>().id = AllPiezas[i].id1;


            }

            PiezaTemplate.SetActive(false);
        }



    }
}



