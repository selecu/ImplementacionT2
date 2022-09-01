using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


namespace v1
{
    public class QuestionGenerator_PointDraw : MonoBehaviour
    {
        public static QuestionGenerator_PointDraw instance;
        public List<int> Answers = new List<int>();

        [Tooltip("Todas la figuras deben iniciar y terminar en 25")]
        public List<int> Respuestas = new List<int>();

        [Tooltip("los valores de las preguntas se cambian desde el texto del objeto")]
        public GameObject[] ExternalElements;
        [SerializeField]
        GameObject CheckButton;
        [SerializeField]
        GameObject CheckIntegrador;
        [SerializeField]
        GameObject BlockImage;
        [SerializeField]
        GameObject RemovePoint;
        [SerializeField]
        GameObject LineRenderer;
        string sym;
        [SerializeField]
        int count;
        [SerializeField]
        int respcount;

        public Material mat1, mat2;

        public GameObject[] ventanas;



        private void Awake()
        {
            instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            sym = "=";
            BlockImage.SetActive(false);
            CheckButton.SetActive(false);
            CheckIntegrador.SetActive(false);


            for (int i = 1; i < ExternalElements.Length; i++)
            {
                GameObject ChildGameQuestion = ExternalElements[i].transform.GetChild(0).gameObject;
                ChildGameQuestion.SetActive(false);
            }

        }

        public void ActivateQuestion(string nombre)
        {
            count++;


            if (count < ExternalElements.Length)
            {
                GameObject ChildGameQuestion = ExternalElements[count].transform.GetChild(0).gameObject;
                GameObject ChildGameQuestionBefore = ExternalElements[count - 1].transform.GetChild(0).gameObject;
                string texto = ChildGameQuestionBefore.GetComponent<Text>().text;
                int respuesta = int.Parse(nombre.Split('(', ')')[1]) + 1;
                Answers.Add(respuesta);
                ChildGameQuestionBefore.GetComponent<Text>().text = texto + " " + sym + " " + respuesta.ToString();
                ChildGameQuestion.SetActive(true);
            }
            else if (count == ExternalElements.Length)
            {
                GameObject ChildGameQuestionBefore = ExternalElements[count - 1].transform.GetChild(0).gameObject;
                string texto = ChildGameQuestionBefore.GetComponent<Text>().text;
                int respuesta = int.Parse(nombre.Split('(', ')')[1]) + 1;
                Answers.Add(respuesta);
                ChildGameQuestionBefore.GetComponent<Text>().text = texto + " " + sym + " " + respuesta.ToString();
            }
        }

        public void RemoveQuestion()
        {
            if (count < ExternalElements.Length)
            {
                GameObject ChildGameQuestion = ExternalElements[count].transform.GetChild(0).gameObject;
                ChildGameQuestion.SetActive(false);
                GameObject ChildGameQuestionBefore = ExternalElements[count - 1].transform.GetChild(0).gameObject;
                string texto = ChildGameQuestionBefore.GetComponent<Text>().text;
                string pregunta = texto.Split('=')[0];
                ChildGameQuestionBefore.GetComponent<Text>().text = pregunta;
                count--;
                int numero = int.Parse(texto.Split('=')[1]) - 1;
                Answers.RemoveAt(count);
                Debug.Log("Button (" + numero.ToString() + ")");
                GameObject ButtonActivate = GameObject.Find("Button (" + numero.ToString() + ")");
                ButtonActivate.GetComponent<Button>().interactable = true;

            }
            else if (count == ExternalElements.Length)
            {
                GameObject ChildGameQuestionBefore = ExternalElements[count - 1].transform.GetChild(0).gameObject;
                string texto = ChildGameQuestionBefore.GetComponent<Text>().text;
                string pregunta = texto.Split('=')[0];
                ChildGameQuestionBefore.GetComponent<Text>().text = pregunta;
                count--;
                Answers.RemoveAt(count);
            }
        }

        void Update()
        {
            //Debug.Log(Answers.Count());
            if (count > ExternalElements.Length - 1 && Answers.Last() == Answers.First())
            {
                CheckButton.SetActive(true);
                BlockImage.SetActive(true);
            }
            else
            {
                CheckButton.SetActive(false);
                BlockImage.SetActive(false);
            }


        }

        public void CheckAnswers()
        {

            for (int i = 0; i < Answers.Count(); i++)
            {
                if (Answers[i] == Respuestas[i])
                {
                    respcount++;
                }
            }
            Debug.Log(respcount);
            if (respcount == Answers.Count())
            {
                Debug.Log("Done");
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.correcto.Play();
                ventanas[0].SetActive(true);
                RemovePoint.SetActive(false);
                CheckButton.SetActive(false);
                CheckIntegrador.SetActive(true);

            }
            else
            {
                Debug.Log("Incorrecto");
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.correcto.Play();
                ventanas[1].SetActive(true);
                StartCoroutine(Waiting());
                LineRenderer.GetComponent<LineRenderer>().material = mat1;
                StartCoroutine(Fade());
            }
            respcount = 0;
        }
        IEnumerator Fade()
        {
            yield return new WaitForSeconds(3);
            LineRenderer.GetComponent<LineRenderer>().material = mat2;

        }

        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(5);
            ventanas[1].SetActive(false);
            StopCoroutine(Waiting());
        }
    }

}

