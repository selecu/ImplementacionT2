using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace v1
{
    public class ButtonClickedManager : MonoBehaviour
    {
        [SerializeField] string[] names;
        [SerializeField] string[] informa;
        [SerializeField] Button[] btn;
        [SerializeField] GameObject infoName;
        [SerializeField] Text infoBox;
        [SerializeField] GameObject infoBoxImg;
        bool question;
        [SerializeField] Text questionBox;
        [SerializeField] InputField answerBox;
        [SerializeField] int min;
        [SerializeField] int max;
        [SerializeField] GameObject check;
        bool checkDone = false;
        [SerializeField] GameObject check_Integrador;
        public GameObject[] ventana;


        int currentAnswer;
        bool[] done;
        Text[] txt;
        Text txtInfo;

       public  GameObject questionObj;
        int prev = -1;

        void Start()
        {
            check_Integrador.SetActive(false);
            txtInfo = infoName.GetComponent<Text>();
            txt = new Text[names.Length];
            done = new bool[names.Length];
            infoBox.text = "";
            infoBoxImg.SetActive(false);

            for(int i  = 0; (i < names.Length && names.Length < 8); i++)
            {
                txt[i] = btn[i].GetComponentInChildren<Text>();
                txt[i].text = names[i];
                done[i] = false;
            }
            if(names.Length < 7)
            {
                for (int i = names.Length + 1; i < 8; i++)
                {
                    GameObject.Find(i.ToString()).SetActive(false);
                }
            }

   
            questionObj = GameObject.Find("Question");
 
        }

        void Update()
        {
            if(ButtonClicked.value >= 0 && ButtonClicked.value < names.Length)
            {
                if (!question)
                {
                    infoBox.text = informa[ButtonClicked.value];
                    infoBoxImg.SetActive(true);
                    txtInfo.text = names[ButtonClicked.value];
                } else
                {
                    if (done[ButtonClicked.value])
                    {
                        infoBox.text = informa[ButtonClicked.value];
                        infoBoxImg.SetActive(true);
                        txtInfo.text = names[ButtonClicked.value];
                    }
                }
            }
            questionObj.SetActive(question);

            check.SetActive(checkDone);
        }

        public void GenerateQuestion()
        {
            if(prev != ButtonClicked.value)
            {
                infoBox.text = "";
                infoBoxImg.SetActive(false);
                prev = ButtonClicked.value;
                question = true;
            }
            if (!done[ButtonClicked.value])
            {
                int one = Random.Range(min, max);
                int two = Random.Range(min, max);
                int three = one > two ? one - two : two - one;
                currentAnswer = three;
                questionBox.text = one > two ? $"{one} - {two} = " : $"{two} - {one} = ";
            }
            else
            {
                questionBox.text = "";
                question = false;
            }

            var temp = 0;
            for (int i = 0; i < names.Length; i++)
            {
                if (done[i])
                {
                    temp++;
                }
            }
            if (temp == names.Length)
            {
                checkDone = true;
            }

        }

        public void Compare()
        {

            if (int.Parse(answerBox.text) == currentAnswer)
            {
                done[ButtonClicked.value] = true;
                questionBox.text = "";
                answerBox.text = "";
                question = false;
            }
        }

        public void Check()
        {
            check.SetActive(false);
            check_Integrador.SetActive(true);
            v1.Managersound item = FindObjectOfType<Managersound>();
            item.correcto.Play();
            ventana[0].SetActive(true);
        }
    }
}

