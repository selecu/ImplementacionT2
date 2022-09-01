using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace v1
{
    public class VerificatorCards : MonoBehaviour
    {
        GameObject c1;
        GameObject c2;
        private int ideInfo;
        List<CardInfo> cards;
        [TextArea(10, 10)]
        public List<string> infoText;
        private Queue<string> frases;

        [SerializeField]
        GameObject panelInfo;
        [SerializeField]
        Text textInfo;
        [SerializeField]
        GameObject container;
        [SerializeField]
        GameObject botonIntegrador;

        [Tooltip("Si cuando hacen pareja sale un mensaje de info")]
        public bool conPanelInfo;

        private void Start()
        {
            frases = new Queue<string>();
            foreach (var item in infoText)
            {
                frases.Enqueue(item);
            }
            panelInfo.SetActive(false);
            cards = FindObjectsOfType<CardInfo>().ToList();

            Reorder();
        }
        public void GetC1C2()
        {
            if (c1 == null && c2 == null)
            {
                c1 = EventSystem.current.currentSelectedGameObject.gameObject;
                c1.GetComponent<CardInfo>().isUsed = true;
                c1.GetComponent<Button>().interactable = false;
            }
            else if (c2 == null)
            {
                if (EventSystem.current.currentSelectedGameObject.gameObject != c1)
                {
                    c2 = EventSystem.current.currentSelectedGameObject.gameObject;
                    c2.GetComponent<CardInfo>().isUsed = true;
                    c2.GetComponent<Button>().interactable = false;
                    Check();
                    
                }

            }
        }

        public void Check()
        {
            if (c1.GetComponent<CardInfo>().cardID == c2.GetComponent<CardInfo>().cardID)
            {
                if (conPanelInfo)
                {
                    panelInfo.SetActive(true);
                    v1.Managersound item = FindObjectOfType<Managersound>();
                    item.correcto.Play();
                    textInfo.text = frases.Dequeue();
                }
                botonIntegrador.SetActive(IsFinished());
                //Debug.Log("<color=lime> aca gano? </color>" + IsFinished());
                c1 = null;
                c2 = null;
                v1.Managersound item1 = FindObjectOfType<Managersound>();
                item1.correcto.Play();
            }
            else
            {
                c1.GetComponent<CardInfo>().isUsed = false;
                c1.GetComponent<Button>().interactable = true;
                c2.GetComponent<CardInfo>().isUsed = false;
                c2.GetComponent<Button>().interactable = true;
                c1 = null;
                c2 = null;
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.incorrecto.Play();
            }
        }

        private bool IsFinished()
        {
            int total = cards.Count();
            int count = 0;
            foreach (var item in cards)
            {
                if (item.isUsed)
                {
                    count++;
                }
            }

            if (count == total)
            {
#if UNITY_EDITOR
                Debug.Log("gano el maldito lo logro");
#endif

                return true;
            }
            else
                return false;
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

        private void Reorder()
        {
            Shuffle(cards);
            foreach (var item in cards)
            {
                item.transform.SetParent(container.transform);
            }
        }
    }

}
