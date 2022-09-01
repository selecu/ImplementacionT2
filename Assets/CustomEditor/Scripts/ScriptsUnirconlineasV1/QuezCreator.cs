using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;




[System.Serializable]
public class Pregunta
{
    public string id1;
    public Sprite Icon;
    [TextArea]
    public string Info;
    
}

namespace v1
{
    public class QuezCreator : MonoBehaviour
    {
        public List<Pregunta> AllPreguntas;


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
            Shuffle(AllPreguntas);

            GameObject PreguntaTemplate = transform.GetChild(0).gameObject;
            GameObject g;

            for (int i = 0; i < AllPreguntas.Count; i++)
            {
                g = Instantiate(PreguntaTemplate, transform) as GameObject;
                g.name = PreguntaTemplate.name + " " + i;
                g.transform.GetChild(0).GetComponent<Image>().sprite = AllPreguntas[i].Icon;
                g.transform.GetChild(1).GetComponent<Text>().text = AllPreguntas[i].Info;
                g.transform.GetComponent<MatchItem>().ItemName = AllPreguntas[i].id1;
            }

            Destroy(PreguntaTemplate);
        }
    }

}
