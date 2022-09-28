using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace v1
{
    public class Collideractive : MonoBehaviour
    {

        public BoxCollider2D col;
        public AnswerScript answerScript;
        public Quizmanager Quizmanager;

        // public Mundo puntos;


        // Start is called before the first frame update
        void Start()
        {
            col = GetComponent<BoxCollider2D>();
            col.enabled = true;



        }

        // Update is called once per frame
        void Update()
        {


            if (answerScript.isCorret == true)
            {
                col.enabled = true;
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (answerScript.isCorret == true && collision.gameObject.tag == "Player")
            {
                Debug.Log("si");
               // correcto.SetActive(true);
                //puntos.puntos++;
                collision.GetComponent<MovemetP>().Lose();
                Quizmanager.ventana[0].SetActive(true);
                StartCoroutine(espe());

            }
            else
            {
                Debug.Log("no");
                Quizmanager.ventana[1].SetActive(true);
                // activar inento
                collision.GetComponent<MovemetP>().Lose();
                col.enabled = false;
                StartCoroutine(espe());

                //puntos.vida--;
            }


        }

        IEnumerator espe()
        {

            yield return new WaitForSeconds(5);
            //correcto.SetActive(false);
            //incorrecto.SetActive(false);
            Quizmanager.correcto();
            if(Quizmanager.QnA.Count > 0)
            {
                Quizmanager.ventana[0].SetActive(false);
            }
           
            Quizmanager.ventana[1].SetActive(false);
            StopAllCoroutines();
        }
    }

}
