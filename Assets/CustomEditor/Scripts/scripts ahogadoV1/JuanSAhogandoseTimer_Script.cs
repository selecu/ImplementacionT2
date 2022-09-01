using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace v1
{
    public class JuanSAhogandoseTimer_Script : MonoBehaviour
    {
        public Slider timerSlider;
        public Text timerText;
        public float gameTime;
        [SerializeField]
        GameObject CheckButton;
        [SerializeField]
        GameObject CheckIntegrador;
        [SerializeField]
        GameObject TextHolder;
        [SerializeField]
        InputField AnswerText;

        public Text[] cantidades;
        [SerializeField]
        int minimo;
        [SerializeField]
        int maximo;
        float time;
        public GameObject[] ventanas;

        private bool stoptimer;
        // Start is called before the first frame update
        public void Start()
        {


            stoptimer = false;
            timerSlider.maxValue = gameTime;
            timerSlider.value = 0;
            CheckButton.SetActive(false);
            CheckIntegrador.SetActive(false);
            AnswerText = TextHolder.GetComponent<InputField>();
            

            for (int i = 0; i < 2; i++)
            {
                int Randomindex = UnityEngine.Random.Range(minimo, maximo);
                cantidades[i].text = Randomindex.ToString();
                
            }


        }

        // Update is called once per frame
        void Update()
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);

            string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            if (time >= gameTime)
            {
                stoptimer = true;
                time = 0;
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.incorrecto.Play();
                ventanas[1].SetActive(true);
                StartCoroutine(Waiting());
            }
            if (time >= 8)
            {
                //stoptimer = true;
                CheckButton.SetActive(true);
            }
            if (stoptimer == false)
            {
                time = Time.timeSinceLevelLoad;
                timerText.text = textTime.ToString();
                timerSlider.value = time;
            }
            if (timerSlider.value == timerSlider.maxValue)
            {
                timerSlider.value = timerSlider.minValue;
                

            }

        }

        public void DataCheck()
        {
            int total = int.Parse(cantidades[0].text) * int.Parse(cantidades[1].text);
            int answer = int.Parse(AnswerText.text);
            if (total == answer)
            {

                stoptimer = true;
                ventanas[0].SetActive(true);
                CheckIntegrador.SetActive(true);
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.correcto.Play();

            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    int Randomindex = UnityEngine.Random.Range(minimo, maximo);
                    cantidades[i].text = Randomindex.ToString();
                    
                }
                ventanas[1].SetActive(true);
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.incorrecto.Play();
                StartCoroutine(Waiting());

            }


        }

        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(5);
            ventanas[1].SetActive(false);
            StopCoroutine(Waiting());
        }


    }



}
