using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace v1{
    public class GameManagerdigital : MonoBehaviour
    {
        
        public int[] answers;
        public static int[] done;
        public ButtonManagerdigital[] Butons;
        [SerializeField] int counter ;
        [SerializeField] int correctas ;
        public int intentos;
        [SerializeField] GameObject chek;
        [SerializeField] GameObject chekIntegrador;
        [SerializeField] GameObject block;
        [SerializeField] GameObject[] ventana;






        void Awake()
        {
            done = new int[answers.Length];
        }

        void Start()
        {
            Butons = FindObjectsOfType<ButtonManagerdigital>();
            chek.SetActive(false);
            chekIntegrador.SetActive(false);
            
            for(int i  = 0; i < answers.Length; i++)
            {
                if(answers[i] == 1)
                {
                    correctas++;
                }
            }
        }


        void Update()
        {
            if (intentos == correctas )
            {
                chek.SetActive(true);
               // block.SetActive(true);

            }
        }

        public void check()
        {

            for(int i  = 0; i < answers.Length; i++)
            {
                if(done[i] == 1 && answers[i] == done[i])
                {
                    counter++;
                }
                if (done[i] == 1 && answers[i] != done[i])
                {
                    done[i] = 0;
                }

            }
            if(counter == correctas)
            {
                chekIntegrador.SetActive(true);
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.correcto.Play();
                ventana[0].SetActive(true);

            }
            else 
            {
                foreach (var item in Butons)
                {
                    item.ResetImg();
                   
                    
                }
                v1.Managersound item1 = FindObjectOfType<Managersound>();
                item1.incorrecto.Play();
                chek.SetActive(false);
                ventana[1].SetActive(true);
                StartCoroutine(Waiting());
            }
            counter = 0;
            intentos = 0;
            if(intentos == 0)
            {
                block.SetActive(false);
            }
            
        }

        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(5);
            ventana[1].SetActive(false);
            StopCoroutine(Waiting());
        }
    }
}

