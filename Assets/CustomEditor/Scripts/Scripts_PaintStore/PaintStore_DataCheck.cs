using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace v1
{
    public class PaintStore_DataCheck : MonoBehaviour
    {
        [SerializeField]
        GameObject[] Amounts;
        [SerializeField]
        GameObject[] Answers;
        [SerializeField]
        GameObject total_Answer;
        [SerializeField]
        public int[] costs;
        [SerializeField]
        int count;
        [SerializeField]
        int subtotal;
        [SerializeField]
        int total;

        // Start is called before the first frame update
        void Start()
        {
            Amounts = GameObject.FindGameObjectsWithTag("PaintStore_Amounts");
            Answers = GameObject.FindGameObjectsWithTag("PaintStore_Answers");
            total_Answer = GameObject.Find("Container_Total_Text_InputField");

        }


        public void check()
        {
            for (int i = 0; i < Amounts.Length; i++)
            {
                Text Amount = Amounts[i].GetComponent<Text>();
                InputField inputField_Answer = Answers[i].GetComponent<InputField>();

                if ((int.Parse(Amount.text) * costs[i]) == int.Parse(inputField_Answer.text))
                {
                    count += 1;
                    inputField_Answer.image.color = Color.white;

                }
                else
                {
                    inputField_Answer.image.color = Color.red;
                }
                subtotal += int.Parse(Amount.text) * costs[i];

                //Debug.Log(count);
            }

            count = 0;
            total = subtotal;
            subtotal = 0;
            //Debug.Log(total);
            InputField inputField_Total_Answer = total_Answer.GetComponent<InputField>();

            if (int.Parse(inputField_Total_Answer.text) == total)
            {
                inputField_Total_Answer.image.color = Color.white;
            }
            else
            {
                inputField_Total_Answer.image.color = Color.red;
            }
        }

    }

}

