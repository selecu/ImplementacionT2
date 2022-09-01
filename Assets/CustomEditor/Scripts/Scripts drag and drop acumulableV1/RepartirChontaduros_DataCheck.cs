using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



namespace v1
{
    public class RepartirChontaduros_DataCheck : MonoBehaviour
    {
        [SerializeField]
        GameObject[] CanastaContainer;
        [SerializeField]
        GameObject CheckButton;
        [SerializeField]
        GameObject checkIntegrador;
        [SerializeField]
        GameObject Container;
        [SerializeField]
        int verificador;
        int count;
        int count2;
        public GameObject[] ventana;
        

        // Start is called before the first frame update
        void Start()
        {
            checkIntegrador.SetActive(false);
            CheckButton.SetActive(false);
            


        }

        // Update is called once per frame
        void Update()
        {
            validfractions();

        }

        void validfractions()
        {

            for (int i = 0; i < Container.transform.childCount; i++)
            {
                count2 += Container.transform.GetChild(i).transform.childCount;
                if (count2 == 0)
                {
                    CheckButton.SetActive(true);
                }
                else
                {
                    CheckButton.SetActive(false);
                }
            }
            count2 = 0;


        }

        public void Clicktrys()
        {
            for (int i = 0; i < CanastaContainer.Length; i++)
            {
                int childCount;
                childCount = CanastaContainer[i].transform.childCount - 1;
                if (CanastaContainer[i].transform.GetChild(0).GetComponent<Text>().text == childCount.ToString())
                {
                    count++;



                }

            }

            if (count == verificador)
            {
                checkIntegrador.SetActive(true);
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.correcto.Play();
                ventana[0].SetActive(true);
                StartCoroutine(Waiting());
                CheckButton.SetActive(false);

            }
            else
            {
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.incorrecto.Play();
                ventana[1].SetActive(true);
                StartCoroutine(Waiting());
               
            }
            count = 0;

        }

        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(5);
            ventana[1].SetActive(false);
            StopCoroutine(Waiting());
        }
    }

}
