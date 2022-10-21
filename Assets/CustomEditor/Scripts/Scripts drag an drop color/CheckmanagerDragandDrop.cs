using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;


namespace v1.color
{
    public class CheckmanagerDragandDrop : MonoBehaviour
    {
        public bool correct;
        public DropSlotDragandDrop[] drops;
        public GameObject main_Check;
        public GameObject check_Integrador;
        public GameObject[] ventana;




        public void Start()
        {
            StartCoroutine(LoadSlots());
            check_Integrador.SetActive(false);

        }


        public void check()
        {

            drops = FindObjectsOfType<DropSlotDragandDrop>();

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
                            item.GetComponentInChildren<DragHandlerDragandDrop>().StartPosition();
                            v1.Managersound item1 = FindObjectOfType<v1.Managersound>();
                            item1.incorrecto.Play();
                            ventana[1].SetActive(true);
                            StartCoroutine(Waiting());
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
                            v1.Managersound item1 = FindObjectOfType<v1.Managersound>();
                            item.transform.GetChild(0).GetComponent<Image>().color = Color.white;
                            item1.incorrecto.Play();
                            ventana[1].SetActive(true);
                            StartCoroutine(Waiting());
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
                PreguntaManagerR[] preguntas;
                preguntas = FindObjectsOfType<PreguntaManagerR>();
                foreach(PreguntaManagerR preguntaManagerR in preguntas)
                {
                    preguntaManagerR.Instance();
                }
#endif
            }


        }


        IEnumerator LoadSlots()
        {
            yield return new WaitForSeconds(1);
            drops = FindObjectsOfType<DropSlotDragandDrop>();

        }

        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(5);
            ventana[1].SetActive(false);
            StopCoroutine(Waiting());
        }

    }
}




