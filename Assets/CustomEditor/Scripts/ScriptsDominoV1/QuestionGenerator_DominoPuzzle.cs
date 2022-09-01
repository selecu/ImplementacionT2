using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace v1
{
    public class QuestionGenerator_DominoPuzzle : MonoBehaviour
    {
        public GameObject[] InternalSolots;
        public GameObject[] ExternalSolots;

        public int[] answers;
        // Start is called before the first frame update
        void Start()
        {
            //ExternalSolots = GameObject.FindGameObjectsWithTag("SlotsROP");
            InternalSolots = GameObject.FindGameObjectsWithTag("Slotses");



            for (int i = 0; i < InternalSolots.Length; i++)
            {
                GameObject ChildGameQuestion = InternalSolots[i].transform.GetChild(0).gameObject;
                GameObject ChildGameAnswerOculta = InternalSolots[i].transform.GetChild(1).gameObject;
                string sym;
                int value1 = Random.Range(20, 40);
                int value2 = Random.Range(1, 19);
                int symbol = Random.Range(1, 3);
                if (symbol == 1)
                {
                    sym = "-";
                    answers[i] = value1 - value2;
                }
                else
                {
                    sym = "+";
                    answers[i] = value1 + value2;
                }
                ChildGameQuestion.GetComponent<Text>().text = value1.ToString() + " " + sym + " " + value2.ToString();
                ChildGameAnswerOculta.GetComponent<Text>().text = answers[i].ToString();
                GameObject ChildGameAnswer = ExternalSolots[i].transform.GetChild(0).gameObject;
                ChildGameAnswer.transform.GetChild(1).GetComponent<Text>().text = answers[i].ToString();



            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }


}