using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace v1
{
    public class MultipleSelection : MonoBehaviour
    {
        public List<Questiont> preguntas;

        public GameObject panelPreguntas;

        public int RespuestasCorrectas;
        [HideInInspector]
        public int preguntasRespondidas, respuestasCorrectas;
        [HideInInspector]
        public bool win;


        public GameObject buttonCheck;
        public GameObject buttonIntegrador;

        private void Start()
        {
            Shuffle(preguntas);
            ParentedToCanvas();
            buttonIntegrador.SetActive(false);
            //setUp.SetUp(canvas);

        }

        private void ParentedToCanvas()
        {
            foreach (var item in preguntas)
            {
                item.SetUpButton(panelPreguntas.transform);
            }
        }

        private void UnparentToPanelReset()
        {
            preguntasRespondidas = 0;
            respuestasCorrectas = 0;
            foreach (Transform child in panelPreguntas.transform)
            {
                //Destroy(child);
                child.gameObject.SetActive(false);
            }

            Shuffle(preguntas);

            ParentedToCanvas();
            win = false;
        }

        public void Verificator()
        {
            if (win)
            {
#if UNITY_EDITOR
                Debug.Log("<color=green>Termino la interaccion </color>");
#endif
                buttonIntegrador.SetActive(true);
            }
            else
            {
#if UNITY_EDITOR
                Debug.Log("<color=magenta>Lo hizo Malo </color>");
#endif
                UnparentToPanelReset();
                buttonCheck.SetActive(false);

            }
        }

        private void Shuffle<T>(List<T> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                T temp = list[i];
                int rnd = Random.Range(i, list.Count);
                list[i] = list[rnd];
                list[rnd] = temp;
            }
        }
    }



    [System.Serializable]
    public class Questiont
    {
        //public Image question;
        private Button question;
        public bool isCorrect;
        public Sprite image;
        public Color chooseColor;



        public MultipleSelection ms;

        public void SetUpButton(Transform panel)
        {
            GameObject button = new GameObject();
            button.transform.parent = panel;
            button.AddComponent<RectTransform>();
            button.AddComponent<Button>();
            button.AddComponent<Image>();
            button.GetComponent<Image>().sprite = image;
            button.GetComponent<Image>().SetNativeSize();

            button.GetComponent<Button>().targetGraphic = button.GetComponent<Image>();


            /*UnityEngine.Events.UnityAction pedro = null;
            pedro += AutoVerificator;*/

            button.GetComponent<Button>().onClick.AddListener(AutoVerificator);
            ColorBlock cb = button.GetComponent<Button>().colors;
            cb.disabledColor = chooseColor;
            button.GetComponent<Button>().colors = cb;
            question = button.GetComponent<Button>();


        }

        public void AutoVerificator()
        {
            //ms.preguntasRespondidas++;


            if (ms.preguntasRespondidas < ms.RespuestasCorrectas)
            {
                ms.preguntasRespondidas++;
                ChangeColorChoosed();
            }

            if (isCorrect)
            {

                ms.respuestasCorrectas++;

            }


            if (ms.preguntasRespondidas == ms.RespuestasCorrectas)
            {
                ms.buttonCheck.SetActive(true);
                if (ms.respuestasCorrectas == ms.RespuestasCorrectas)
                {

                    ms.win = true;
                }
                else
                {

                    ms.win = false;
                }
            }

        }

        private void ChangeColorChoosed()
        {
            /*Color chooseColor = new Color();
            chooseColor = Color.green;

            ColorBlock cb = question.colors;
            cb.disabledColor = chooseColor;
            question.colors = cb;*/
            question.interactable = false;
        }

    }
}
