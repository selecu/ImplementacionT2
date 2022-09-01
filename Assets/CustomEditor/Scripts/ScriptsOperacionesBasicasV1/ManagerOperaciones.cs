using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace v1
{
    public class ManagerOperaciones : MonoBehaviour
    {
        [SerializeField] Text Header;
        [SerializeField] Text one;
        [SerializeField] Text two;
        [SerializeField] Text signo;
        [SerializeField] InputField answer;
        [SerializeField] GameObject finalButton;
        [SerializeField] bool Suma;
        [SerializeField] bool Resta;
        [SerializeField] bool Multiplicacion;
        [SerializeField] bool Divicion;
        [SerializeField] int minimo;
        [SerializeField] int maximo;
        public GameObject[] ventana;


        int m1;
        int m2;
        public int r = 0;

        [SerializeField] int Number_preguntas;
        int counter = 0;

        void Start()
        {
            if (Suma == true)
            {
                signo.text = "+".ToString();
                GenerateS();
            }

            if (Resta == true)
            {
                signo.text = "-".ToString();
                GenerateR();
            }

            if (Multiplicacion == true)
            {
                signo.text = "x".ToString();
                GenerateM();
            }

            if (Divicion == true)
            {
                signo.text = "÷".ToString();
                GenerateD();
            }

        }

        public void GenerateS()
        {
            m1 = (int)Random.Range(minimo, maximo);
            m2 = (int)Random.Range(minimo, maximo);
            r = m1 + m2;

            one.text = m1.ToString();
            two.text = m2.ToString();
        }

        public void GenerateR()
        {
            m1 = (int)Random.Range(minimo, maximo);
            m2 = (int)Random.Range(minimo, maximo);
            r = m1 - m2;

            one.text = m1.ToString();
            two.text = m2.ToString();
        }
        public void GenerateM()
        {
            m1 = (int)Random.Range(minimo, maximo);
            m2 = (int)Random.Range(minimo, maximo);
            r = m1 * m2;

            one.text = m1.ToString();
            two.text = m2.ToString();
        }

        public void GenerateD()
        {
            m1 = (int)Random.Range(minimo, maximo);
            m2 = (int)Random.Range(minimo, maximo);
            r = m1 / m2;

            one.text = m1.ToString();
            two.text = m2.ToString();
        }



        public void Check()
        {
            if (Suma == true)
            {
                if (int.Parse(answer.text) == r)
                {
                    counter++;
                    if (counter < Number_preguntas)
                    {
                        GenerateS();
                    }
                    else
                    {
                        finalButton.SetActive(true);
                        ExitGame();
                    }
                }
            }

            if (Resta == true)
            {
                if (int.Parse(answer.text) == r)
                {
                    counter++;
                    if (counter < Number_preguntas)
                    {
                        GenerateR();
                    }
                    else
                    {
                        finalButton.SetActive(true);
                        ExitGame();
                    }
                }
            }

            if (Multiplicacion == true)
            {
                if (int.Parse(answer.text) == r)
                {
                    counter++;
                    if (counter < Number_preguntas)
                    {
                        GenerateR();
                    }
                    else
                    {
                        finalButton.SetActive(true);
                        ExitGame();
                    }
                }
            }

            if (Divicion == true)
            {
                if (int.Parse(answer.text) == r)
                {
                    counter++;
                    if (counter < Number_preguntas)
                    {
                        GenerateR();
                    }
                    else
                    {
                        finalButton.SetActive(true);
                        ExitGame();
                    }
                }
            }


        }
        public void ExitGame()
        {
            v1.Managersound item = FindObjectOfType<Managersound>();
            item.correcto.Play();
            ventana[0].SetActive(true);
        }
    }
}




