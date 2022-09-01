using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace v1
{
    public class SandTimer_Script : MonoBehaviour
    {
        public Slider timerSlider;
        public Text timerText;
        public float gameTime;

        [SerializeField] GameObject CheckButton;
        [SerializeField] GameObject checkIntegrador;
        [SerializeField] GameObject TextHolder;
        InputField AnswerText;
        public Text[] cantidades;
        float time;
        public static bool stoptimer;
        public GameObject[] ventana;

        // Start is called before the first frame update
        void Start()
        {
           
            checkIntegrador.SetActive(false);
            stoptimer = false;
            timerSlider.maxValue = gameTime;
            timerSlider.value = 0;
            CheckButton.SetActive(false);
            AnswerText = TextHolder.GetComponent<InputField>();
            
        }

        // Update is called once per frame
        void Update()
        {
            timer();
        }

        public void DataCheck()
        {
            int total = int.Parse(cantidades[0].text) + int.Parse(cantidades[1].text);
            int answer = int.Parse(AnswerText.text);
            if (total == answer)
            {
                v1.Managersound item = FindObjectOfType<v1.Managersound>();
                item.correcto.Play();
                ventana[0].SetActive(true);
                checkIntegrador.SetActive(true);
                CheckButton.SetActive(false);
                stoptimer = true;

            }
            else
            {
                v1.Managersound item = FindObjectOfType<v1.Managersound>();
                item.incorrecto.Play();
                ventana[1].SetActive(true);
                StartCoroutine(Waiting());
                //reloadR();
            }
           

        }

        public void timer()
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);
            string textTime = string.Format("{0:D2}:{1:D2}", seconds / 60, seconds % 60);

            if (time >= gameTime)
            {
                stoptimer = true;
                time = 0;

                

            }

            if (time >= 10)
            {
                CheckButton.SetActive(true);
            }
            if (stoptimer == false)
            {
                time = Time.timeSinceLevelLoad;
                timerText.text = textTime;
                timerSlider.value = time;
            }
            else
            {
                time = 0;
                
            }
        }

        public void reloadR()
        {
            timerSlider.maxValue = 0;
            timerText.text = "00:00";
            checkIntegrador.SetActive(false);
            stoptimer = false;
            timerSlider.maxValue = gameTime;
            timerSlider.value = 0;
            CheckButton.SetActive(false);
            AnswerText = TextHolder.GetComponent<InputField>();
            timer();
            v1.SandTimer_Script itemR = FindObjectOfType<SandTimer_Script>();
            itemR.reloadR();
        }

        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(5);
            ventana[1].SetActive(false);
            StopCoroutine(Waiting());
        }
    }

}
