using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace v1
{
    public class ManagerChecklineas : MonoBehaviour
    {

        public bool correct;
        public MatchItem[] Item;

        [Space(10)]
        public GameObject main_Check;
        public GameObject check_Integrador;
        public GameObject[] ventana;



        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(LoadMatch());
            check_Integrador.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void check()
        {

            Item = FindObjectsOfType<MatchItem>();
            var i = 0;

            foreach (var item in Item)
            {
                if (item.IsCorrect)
                {
                    i++;
                    //correct = true;
#if UNITY_EDITOR
                    Debug.Log(item.name + "<color=yellow> es correcto </color>");
#endif
                }
                else
                {
                    correct = false;
                    item.GetComponentInChildren<MatchItem>().Reinicio();
#if UNITY_EDITOR
                    Debug.Log("<color=lime> malo bruto! </color>");
#endif

                }


            }



            //if (correct)
            //{
            //    if (i == Item.Length)
            //    {
            //        Main_chek.SetActive(false);
            //        check_Integrador.SetActive(true);

            //    }
            //}


            if (i == Item.Length)
            {
                try
                {
                    main_Check.SetActive(false);
                    check_Integrador.SetActive(true);
                    v1.Managersound item = FindObjectOfType<Managersound>();
                    item.correcto.Play();
                    ventana[0].SetActive(true);
                }
                catch (System.Exception e)
                {
                    Debug.LogError("Hace falta referenciar el objeto 'main_Check' o 'check_Integrador'.");
                    throw e;
                }
#if UNITY_EDITOR
                //ejecutaraccion cuando todas esten correctas
                Debug.Log("<color=red>❤¡Hola Integrador!❤</color>\n<color=red>*** Este mensaje aparece cuando la interacción ha sido completada en su totalidad. ***</color> ");
#endif
            }
            else
            {
#if UNITY_EDITOR
                Debug.LogWarning(">>>>> Hacen falta respuestas para terminar la interacción. <<<<<");
#endif
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.incorrecto.Play();
                ventana[1].SetActive(true);
                StartCoroutine(Waiting());
            }



        }

        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(5);
            ventana[1].SetActive(false);
            StopCoroutine(Waiting());
        }
        IEnumerator LoadMatch()
        {
            yield return new WaitForSeconds(1);
            Item = FindObjectsOfType<MatchItem>();

        }



    }

}
