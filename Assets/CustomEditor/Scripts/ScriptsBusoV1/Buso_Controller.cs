using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace v1
{
    public class Buso_Controller : MonoBehaviour
    {
        public Button[] buttons;
        public bool[] swithcer;
        int count;
        int multiplo;
        int position;
        GameObject Buso;
        [SerializeField]
        GameObject CheckButton;
        GameObject Multiplo;
        GameObject Lifes;
        [SerializeField]
        GameObject check_Integrador;
        string namescene;

        bool notDone = true;
        public List<int> usedValues = new List<int>();
        public List<int> usedButtons = new List<int>();
        public List<int> choosedButtons = new List<int>();

        private void Awake()
        {

            while (notDone)
            {
                if (usedValues.Count >= 11)
                {
                    //Print( "We've used all the numbers" );
                    notDone = false;
                    return;
                }

                int randomIndexUno = UnityEngine.Random.Range(2, 13);

                while (usedValues.Contains(randomIndexUno))
                {
                    randomIndexUno = UnityEngine.Random.Range(2, 13);
                }
                usedValues.Add(randomIndexUno);
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            check_Integrador.SetActive(false);
            namescene = SceneManager.GetActiveScene().name;
            count = 3;
            CheckButton.SetActive(false);
            Multiplo = GameObject.Find("Multiplo");
            multiplo = Random.Range(2, 13);
            Buso = GameObject.Find("Buso");
            Lifes = GameObject.Find("Lifes");
            Lifes.GetComponent<Text>().text = count.ToString();
            Multiplo.transform.GetChild(0).GetComponent<Text>().text = multiplo.ToString();
            buttons[0].transform.GetChild(0).GetComponent<Text>().text = multiplo.ToString();
            buttons[0].GetComponent<Image>().color = Color.yellow;
            for (int i = 1; i < buttons.Length; i++)
            {
                int index = i;
                buttons[index].onClick.AddListener(() => Checker(index));
                swithcer[index] = false;
                int value = Random.Range(10, 100);
                bool isMultiple = value % multiplo == 0;
                if (isMultiple)
                {
                    value = value + 1;
                    buttons[i].transform.GetChild(0).GetComponent<Text>().text = value.ToString();

                }
                else
                {
                    buttons[i].transform.GetChild(0).GetComponent<Text>().text = value.ToString();
                }

            }

            for (int i = 0; i < buttons.Length; i += 3)
            {
                if (i == 0)
                {
                    int random = Random.Range(1, 3);
                    int actualValue = int.Parse(buttons[i + random].transform.GetChild(0).GetComponent<Text>().text);
                    usedButtons.Add(i + random);
                    int finalValue = (i + 2) * multiplo;
                    buttons[i + random].transform.GetChild(0).GetComponent<Text>().text = finalValue.ToString();
                }
                else
                {
                    int random = Random.Range(0, 3);
                    int actualValue = int.Parse(buttons[i + random].transform.GetChild(0).GetComponent<Text>().text);
                    usedButtons.Add(i + random);
                    int finalValue = (i + 2) * multiplo;
                    buttons[i + random].transform.GetChild(0).GetComponent<Text>().text = finalValue.ToString();
                }

            }
        }


        public void Checker(int index)
        {
            Buso.transform.SetParent(buttons[index].transform);
            Buso.transform.position = buttons[index].transform.position;
            swithcer[index] = !swithcer[index];
            choosedButtons.Add(index);
            if (swithcer[index])
            {
                buttons[index].GetComponent<Image>().color = Color.yellow;
                //count++;

            }
            else
            {
                buttons[index].GetComponent<Image>().color = Color.white;
            }

            if (!usedButtons.Contains(index))
            {
                count--;
                Lifes.GetComponent<Text>().text = count.ToString();
            }

            if (count == 0)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].GetComponent<Image>().color = Color.white;
                    swithcer[i] = false;
                }
                Buso.transform.SetParent(buttons[0].transform);
                Buso.transform.position = buttons[0].transform.position;
                count = 3;
                Lifes.GetComponent<Text>().text = count.ToString();
            }

            if (choosedButtons.Count == usedButtons.Count || index == 11 || index == 12)
            {
                CheckButton.SetActive(true);
            }
            else
            {
                CheckButton.SetActive(false);
            }
        }

        public void DataCheck()
        {
            if (usedButtons.Count != choosedButtons.Count)
            {


                SceneManager.LoadScene(namescene);
            }
            for (int i = 0; i < usedButtons.Count; i++)
            {
                if (usedButtons[i] != choosedButtons[i])
                {

                    SceneManager.LoadScene(namescene);

                }
                else
                {

                    CheckButton.SetActive(false);
                    check_Integrador.SetActive(true);

                }
            }

        }


    }
}


