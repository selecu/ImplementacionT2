using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace v1
{
    public class PeceraTimer_Script : MonoBehaviour
    {
        public Slider timerSlider;
        public Text timerText;
        public float gameTime;
        [SerializeField]
        GameObject CheckButton;
        [SerializeField]
        GameObject Checkintegrador;

        GameObject TextHolder;
        InputField AnswerText;

        public Text[] cantidades;
        float time;
        public GameObject[] ventana;
        


        private bool stoptimer;
        // Start is called before the first frame update
        void Start()
        {
           
            Checkintegrador.SetActive(false);
            stoptimer = false;
            timerSlider.maxValue = gameTime;
            timerSlider.value = gameTime;
            CheckButton.SetActive(false);
            TextHolder = GameObject.Find("InputField");
            AnswerText = TextHolder.GetComponent<InputField>();
            time = gameTime;
        }

        // Update is called once per frame
        void Update()
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);
            string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            if (time <= 50)
            {
                //stoptimer = true;
                CheckButton.SetActive(true);
            }

            if (time <= 0)
            {
                stoptimer = true;
                //CheckIntegrador.SetActive(true); 
                time = gameTime;
                
            }

            if (stoptimer == false)
            {
                time = gameTime - Time.timeSinceLevelLoad;
                timerText.text = textTime;
                timerSlider.value = time;

            }


        }

        public void DataCheck()
        {
            int total = int.Parse(cantidades[0].text) + int.Parse(cantidades[1].text) + int.Parse(cantidades[2].text);
            int answer = int.Parse(AnswerText.text);
            if (total == answer)
            {
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.correcto.Play();
                ventana[0].SetActive(true);

                Checkintegrador.SetActive(true);
                stoptimer = true;

            }
            else
            {
                time = gameTime;
                v1.PeceraTimer_ContainerImageView itemR = FindObjectOfType<PeceraTimer_ContainerImageView>();
                itemR.PrepareImages();
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.incorrecto.Play();
                ventana[1].SetActive(true);

            }

        }
    }
}

