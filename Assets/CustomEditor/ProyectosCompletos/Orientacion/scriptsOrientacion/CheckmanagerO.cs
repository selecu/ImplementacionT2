using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.Linq;


namespace v1
{
    public class CheckmanagerO : MonoBehaviour
    {
        public bool correct;
        public int totalPreguntas = 4;
        public GameObject respuestasParent;
        public GameObject preguntasParent;

        public Image[] imagenes;
        public GameObject referencia;
        public List<string> choose;

        public string respuestaInput;

        public GameObject main_Check;
        public GameObject check_Integrador;



        public void Start()
        {
            main_Check.SetActive(true);
            check_Integrador.SetActive(false);

            NewQuestion();
        }


        public void check()
        {
            for (int i = 0; i < respuestasParent.transform.childCount; i++)
            {
                bool canCheck = true;
                v1.DropSlotO dropSlot = respuestasParent.transform.GetChild(i).GetComponent<v1.DropSlotO>();


                foreach (var item in choose)
                {
                    if (respuestasParent.transform.GetChild(i).gameObject.GetComponent<v1.DropSlotO>().id.ToLower() == item)
                    {
                        canCheck = false;
                        break;
                    }
                    else
                        canCheck = true;
                }

                if (canCheck)
                {
                    if (dropSlot.enabled && dropSlot.IsCorrect &&
                    dropSlot.id.ToLower() == referencia.name.ToLower())
                    {
                        if (dropSlot.item.GetComponent<v1.DragHandlerO>().enabled)
                            dropSlot.item.GetComponent<v1.DragHandlerO>().enabled = false;

                        print("Correcto!");

                        bool canAdd = true;
                        foreach (var item in choose)
                        {
                            if (referencia.name == item)
                            {
                                canAdd = false;
                                break;
                            }
                            else
                                canAdd = true;
                        }

                        if (canAdd)
                        {
                            choose.Add(referencia.name.ToLower());
                        }

                        NewQuestion();

                    }
                    else
                    {
                        dropSlot.enabled = enabled;
                        SetParameters(i);
                    }
                }
            }
        }

        public void OnEndEditInput(TMP_InputField inputField)
        {
            respuestaInput = inputField.text.ToLower();
        }

        public void CheckInput()
        {
            for (int i = 0; i < respuestasParent.transform.childCount; i++)
            {

                bool canCheck = true;

                foreach (var item in choose)
                {
                    if (respuestasParent.transform.GetChild(i).gameObject.GetComponent<v1.DropSlotO>().id.ToLower() == item)
                    {
                        canCheck = false;
                        break;
                    }
                    else
                        canCheck = true;
                }

                if (canCheck)
                {
                    if (respuestaInput == referencia.name.ToLower() &&
                    IsCorrect(respuestasParent.transform.GetChild(i).GetComponent<v1.DropSlotO>()))
                    {
                        print("Correcto!");

                        respuestasParent.transform.GetChild(i).GetComponent<TMP_InputField>().enabled = false;
                        bool canAdd = true;
                        foreach (var item in choose)
                        {
                            if (referencia.name == item)
                            {
                                canAdd = false;
                                break;
                            }
                            else
                                canAdd = true;
                        }

                        if (canAdd)
                        {
                            choose.Add(referencia.name.ToLower());
                        }

                        NewQuestion();
                    }
                    else
                    {
                        print("Recargar");
                        respuestasParent.transform.GetChild(i).GetComponent<TMP_InputField>().enabled = true;
                        SetParametersOnInput(i);

                    }
                }   
            }
        }

        public bool IsCorrect(v1.DropSlotO dropScript)
        {
            if (dropScript.id.ToLower() == respuestaInput)
                return true;
            else
                return false;
        }

        public void NewQuestion()
        {
            if (choose.Count < totalPreguntas)
            {
                bool flag = false;
                int num = 0;

                do
                {
                    num = Random.Range(0, imagenes.Length);

                    foreach (var item in choose)
                    {
                        if (imagenes[num].name.ToLower() == item)
                        {
                            flag = true;
                            break;
                        }
                        else
                            flag = false;
                    }
                } while (flag);

                referencia.GetComponent<Image>().sprite = imagenes[num].sprite;
                referencia.name = imagenes[num].name;
            }
            else
            {
                main_Check.SetActive(false);
                check_Integrador.SetActive(true);
            }
        }

        public void SetParameters(int i)
        {
            if (respuestasParent.transform.GetChild(i).transform.childCount > 2)
            {
                respuestasParent.transform.GetChild(i).GetChild(2).GetComponent<v1.DragHandlerO>().enabled = true;
                respuestasParent.transform.GetChild(i).GetChild(2).GetComponent<CanvasGroup>().blocksRaycasts = true;
                respuestasParent.transform.GetChild(i).GetChild(2).SetParent(preguntasParent.transform);
            }
        }

        public void SetParametersOnInput(int i)
        {
            respuestasParent.transform.GetChild(i).GetComponent<TMP_InputField>().enabled = true;
            respuestasParent.transform.GetChild(i).GetComponent<TMP_InputField>().text = "";
        }
    }   
}


    

