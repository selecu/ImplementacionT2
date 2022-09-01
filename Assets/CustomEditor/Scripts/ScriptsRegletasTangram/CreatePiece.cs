using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;


namespace v2
{
    public class CreatePiece : MonoBehaviour
    {

        [SerializeField]
        GameObject one;
        [SerializeField]
        GameObject two;
        [SerializeField]
        GameObject three;
        [SerializeField]
        GameObject four;
        [SerializeField]
        GameObject five;
        [SerializeField]
        GameObject six;
        [SerializeField]
        GameObject seven;
        [SerializeField]
        GameObject eight;
        [SerializeField]
        GameObject nine;
        [SerializeField]
        GameObject ten;

        [SerializeField]
        Transform fichas;


        public bool correct;
        public DropSlotDragandDropRtangram[] drops;
        public GameObject check_Integrador;
        public GameObject reference;
        public GameObject[] ventana;

        public void Start()
        {
            StartCoroutine(LoadSlotsTangram());
            check_Integrador.SetActive(false);
            reference.SetActive(false);
        }
        IEnumerator LoadSlotsTangram()
        {
            yield return new WaitForSeconds(1);
            drops = FindObjectsOfType<DropSlotDragandDropRtangram>();

        }

        private void Update()
        {
            check();
        }

        public void check()
        {

            drops = FindObjectsOfType<DropSlotDragandDropRtangram>();

            var i = 0;

            if (drops.Length != 0)
            {
                foreach (var item in drops)
                {
                    if (item.IsCorrect)
                    {
                        i++;
#if UNITY_EDITOR
                        Debug.Log("<color=yellow> es correcto </color>");
#endif
                    }
                    else
                    {
                        try
                        {
                            item.GetComponentInChildren<DragHandlerDragandDropRtangram>().StartPosition();
                        }
                        catch (System.Exception e)
                        {
                            //if foreach element in dropsT, the component "DragHandler" in children is equals to null, throw this WARNING.
                            //But this alert is not a preocupation, just it is used to capture the ERROR and continue with the code ejecution.
                            string throwed = "Error generico capturado: " + e;
                            
                        }
                        finally
                        {
#if UNITY_EDITOR
                            Debug.Log("<color=lime> Malo bruto </color>");
#endif
                        }
                    }
                }
            }

            if (i == drops.Length)
            {
                try
                {
                   
                    ventana[0].SetActive(true);
                    check_Integrador.SetActive(true);
                    reference.SetActive(true);
                }
                catch (System.Exception e)
                {
#if UNITY_EDITOR
                    Debug.LogError("Hace falta referenciar el objeto 'main_Check' o 'check_Integrador'.");
#endif
                    throw e;
                }
                finally
                {
#if UNITY_EDITOR
                    //ejecutaraccion cuando todas esten correctas
                    Debug.Log("<color=red>❤¡Hola Integrador!❤ el boton INTEGRADOR es para que lo programes cuando termina la interaccion  </color>\n<color=red>*** Este mensaje aparece cuando la interacción ha sido completada en su totalidad. ***</color> ");
#endif
                }

            }
            else
            {
#if UNITY_EDITOR
                Debug.LogWarning(">>>>> Hacen falta respuestas para terminar la interacción. <<<<<");
               
#endif
            }


        }

       


        public void One()
        {
            Instantiate(one, fichas.position, Quaternion.identity, fichas);
        }
        public void Two()
        {
            Instantiate(two, fichas.position, Quaternion.identity, fichas);
        }
        public void Three()
        {
            Instantiate(three, fichas.position, Quaternion.identity, fichas);
        }
        public void Four()
        {
            Instantiate(four, fichas.position, Quaternion.identity, fichas);
        }
        public void Five()
        {
            Instantiate(five, fichas.position, Quaternion.identity, fichas);
        }
        public void Six()
        {
            Instantiate(six, fichas.position, Quaternion.identity, fichas);
        }
        public void Seven()
        {
            Instantiate(seven, fichas.position, Quaternion.identity, fichas);
        }
        public void Eight()
        {
            Instantiate(eight, fichas.position, Quaternion.identity, fichas);
        }
        public void Nine()
        {
            Instantiate(nine, fichas.position, Quaternion.identity, fichas);
        }
        public void Ten()
        {
            Instantiate(ten, fichas.position, Quaternion.identity, fichas);
        }
    }

}
