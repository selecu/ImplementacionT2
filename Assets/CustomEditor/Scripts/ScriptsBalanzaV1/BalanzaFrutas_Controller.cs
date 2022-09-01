using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace v1
{
    public class BalanzaFrutas_Controller : MonoBehaviour
    {
        // Start is called before the first frame update
        public string[] fracciones;
        public int[] masas;
        GameObject fraccion;
        int index;
        public GameObject CheckButton;
        GameObject Pool_Balanza;
        public GameObject checkIntegrador;
        public string namescene;

        void Start()
        {
            checkIntegrador.SetActive(false);
            CheckButton.SetActive(false);
            Pool_Balanza = GameObject.Find("Pool_Balanza");
            fraccion = GameObject.Find("fraccion");
            index = Random.Range(0, fracciones.Length);
            fraccion.transform.GetChild(0).GetComponent<Text>().text = fracciones[index];
            fraccion.GetComponent<Rigidbody2D>().mass = masas[index];
            namescene = SceneManager.GetActiveScene().name;

        }

        public void CheckData()
        {

            for (int i = 0; i < Pool_Balanza.transform.childCount; i++)
            {
                string answer = Pool_Balanza.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text;
                if (answer == fracciones[index])
                {

                    checkIntegrador.SetActive(true);
                    CheckButton.SetActive(false);

                }
                else
                {
                    SceneManager.LoadScene(namescene);



                }
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (Pool_Balanza.transform.childCount > 0)
            {
                CheckButton.SetActive(true);
            }
            else
            {
                CheckButton.SetActive(false);
            }
        }
    }
}

