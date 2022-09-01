using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;





[System.Serializable]
public class Respuesta
{
    public string id2;
    public Sprite Icon;
    [TextArea]
    public string Info;
    
}


namespace v1
{
    public class AnswerCreator : MonoBehaviour
    {


        public List<Respuesta> AllRespuestas;


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



        // Start is called before the first frame update
        void Start()
        {
            Instance();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Instance()
        {
            Shuffle(AllRespuestas);

            GameObject RespuestaTemplate = transform.GetChild(0).gameObject;
            GameObject g;

            for (int i = 0; i < AllRespuestas.Count; i++)
            {
                g = Instantiate(RespuestaTemplate, transform) as GameObject;
                g.name = RespuestaTemplate.name + " " + i;
                g.transform.GetChild(0).GetComponent<Image>().sprite = AllRespuestas[i].Icon;
                g.transform.GetChild(1).GetComponent<Text>().text = AllRespuestas[i].Info;
                g.transform.GetComponent<MatchItem>().ItemName = AllRespuestas[i].id2;
            }

            Destroy(RespuestaTemplate);
        }
    }

}
