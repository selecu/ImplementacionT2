using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;


namespace v1
{
    public class CheckmanagerDragandDropOP : MonoBehaviour
    {
        public bool correct;
        public DropSlotDragandDropOP[] drops;
        public GameObject main_Check;
        public GameObject check_Integrador;
        public GameObject reference;
        public GameObject[] ventana;



        public void Start()
        {
            StartCoroutine(LoadSlots());
            check_Integrador.SetActive(false);
            reference.SetActive(false);
        }


        public void check()
        {

            drops = FindObjectsOfType<DropSlotDragandDropOP>();

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
                            item.GetComponentInChildren<DragHandlerDragandDropOP>().StartPosition();
                        }
                        catch (System.Exception e)
                        {
                            //if foreach element in drops, the component "DragHandler" in children is equals to null, throw this WARNING.
                            //But this alert is not a preocupation, just it is used to capture the ERROR and continue with the code ejecution.
                            string throwed = "Error generico capturado: " + e;
                            Debug.LogWarning(throwed);
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
                    v1.Managersound item = FindObjectOfType<v1.Managersound>();
                    item.correcto.Play();
                    ventana[0].SetActive(true);
                    main_Check.SetActive(false);
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
                v1.Managersound item = FindObjectOfType<v1.Managersound>();
                item.incorrecto.Play();
                ventana[1].SetActive(true);
                StartCoroutine(Waiting());
#endif
            }


        }


        IEnumerator LoadSlots()
        {
            yield return new WaitForSeconds(1);
            drops = FindObjectsOfType<DropSlotDragandDropOP>();

        }

        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(5);
            ventana[1].SetActive(false);
            StopCoroutine(Waiting());
        }

    }
}


    

