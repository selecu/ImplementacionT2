using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace v1
{
    public class PuzzleDomino_dataCheck : MonoBehaviour
    {
        GameObject CheckButton;
        Vector3 startPosition0;
        public GameObject[] ExternalSlots;
        public GameObject[] slots;
        public float count;
        private float time;
        //public Text trys;
        GameObject DAtamanagerCpntainer;
        public GameObject checkintegrador;

        public PuzzleDomino_DataManager dataManager;
        public GameObject[] ventana;


        // Start is called before the first frame update
        void Start()
        {
            checkintegrador.SetActive(false);
            DAtamanagerCpntainer = GameObject.Find("DataManager");
            dataManager = DAtamanagerCpntainer.GetComponent<PuzzleDomino_DataManager>();
            CheckButton = GameObject.FindGameObjectWithTag("CheckButton");
            CheckButton.SetActive(false);
            slots = GameObject.FindGameObjectsWithTag("Slotses");
            dataManager.Load();
            dataManager.data.trys = 0;
            //trys.text = dataManager.data.trys.ToString();

        }
        public void Clicktrys()
        {
            dataManager.data.trys += 1;
            //trys.text = dataManager.data.trys.ToString();

            for (int i = 0; i < slots.Length; i++)
            {
                GameObject ChildGameQuestion = slots[i].transform.GetChild(1).gameObject;
                GameObject ChildGameAnswer = slots[i].transform.GetChild(2).gameObject;

                if (ChildGameQuestion.GetComponent<Text>().text == ChildGameAnswer.transform.GetChild(1).GetComponent<Text>().text)
                {
                    count += 1;
                }
                else
                {
                    ChildGameAnswer.transform.SetParent(ExternalSlots[i].transform);
                    startPosition0 = ExternalSlots[i].transform.position;
                    ChildGameAnswer.transform.position = startPosition0;
                    int index = int.Parse(ChildGameAnswer.name.Split('(', ')')[1]);
                    float width = ExternalSlots[index].GetComponent<RectTransform>().rect.width;
                    float height = ExternalSlots[index].GetComponent<RectTransform>().rect.height;
                    Vector3 zRotation = ExternalSlots[index].GetComponent<RectTransform>().eulerAngles;
                    Image img = ChildGameAnswer.GetComponent<Image>();
                    img.rectTransform.sizeDelta = new Vector2(width, height);
                    img.rectTransform.eulerAngles = zRotation;

                    //startParent = transform.parent;

                    v1.Managersound item = FindObjectOfType<Managersound>();
                    item.incorrecto.Play();
                    ventana[1].SetActive(true);
                    StartCoroutine(Waiting());

                }
                if (count == 20)
                {
                    checkintegrador.SetActive(true);
                    v1.Managersound item = FindObjectOfType<Managersound>();
                    item.correcto.Play();
                    ventana[0].SetActive(true);
                    StartCoroutine(Waiting());
                    for (int j = 0; j < slots.Length; j++)
                    {
                        GameObject ChildsGameAnswer = slots[j].transform.GetChild(2).gameObject;
                        GameObject.Destroy(ChildsGameAnswer.transform.GetChild(1).gameObject);
                        GameObject.Destroy(ChildsGameAnswer.transform.GetChild(0).gameObject);

                    }
                    dataManager.data.total_time = time;
                    dataManager.Save();
                }
            }
            count = 0;
        }


        void Update()
        {
            time += Time.deltaTime;
            validSlotsColors();
        }

        void validSlotsColors()
        {

            int slotColor = 0;

            for (int i = 0; i < slots.Length; i++)
            {
                try
                {
                    GameObject ChildGameAnswer = slots[i].transform.GetChild(2).gameObject;
                    slotColor += 1;
                }
                catch (UnityException) { }
            }

            if (slotColor == slots.Length)
            {
                CheckButton.SetActive(true);
            }
            else
            {
                CheckButton.SetActive(false);
            }
            slotColor = 0;


        }

        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(5);
            ventana[1].SetActive(false);
            StopCoroutine(Waiting());
        }
    }

}
