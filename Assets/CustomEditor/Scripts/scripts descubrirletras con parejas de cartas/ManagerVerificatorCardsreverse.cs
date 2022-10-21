using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using v1;

namespace v2
{
    public class ManagerVerificatorCardsreverse : MonoBehaviour
    {
        
        
        
        GameObject c1;
        GameObject c2;
        private int ideInfo;
        List<ManagerCardInforeverse> cards;
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
        public Sprite reverse;


        [Tooltip("Si cuando hacen pareja sale un mensaje de info")]
        public bool conPanelInfo;
        
        [Tooltip("Si se debe mostrar una ventana emergente diferente por cada match")]
        [SerializeField] private GameObject[] ventanas;
        
        [Tooltip("si las ventans emergente se deben mostrar en orden o no")] [SerializeField]
        private bool enOrden;
        
        private int preguntaActual;

        [SerializeField] private GameObject bueno;
        
        private void Start()
        {
            frases = new Queue<string>();
            foreach (var item in infoText)
            {
                frases.Enqueue(item);
            }
            panelInfo.SetActive(false);
            cards = FindObjectsOfType<ManagerCardInforeverse>().ToList();
            if(reverse != null){
                foreach (var card in cards)
                {
                    card.GetComponent<Image>().sprite = reverse;
                    card.GetComponent<Image>().SetNativeSize();
                }
            }
            Reorder();
        }
        public void GetC1C2()
        {
            if (c1 == null && c2 == null)
            {
                c1 = EventSystem.current.currentSelectedGameObject.gameObject;
                c1.GetComponent<ManagerCardInforeverse>().isUsed = true;
                c1.GetComponent<Button>().interactable = false;
                if(c1.GetComponent<ManagerCardInforeverse>().image != null){
                    c1.GetComponent<Image>().sprite = c1.GetComponent<ManagerCardInforeverse>().image;
                }
                
            }
            else if (c2 == null)
            {
                if (EventSystem.current.currentSelectedGameObject.gameObject != c1)
                {
                    c2 = EventSystem.current.currentSelectedGameObject.gameObject;
                    c2.GetComponent<ManagerCardInforeverse>().isUsed = true;
                    c2.GetComponent<Button>().interactable = false;
                    if(c2.GetComponent<ManagerCardInforeverse>().image != null){
                        c2.GetComponent<Image>().sprite = c2.GetComponent<ManagerCardInforeverse>().image;
                }
                    Check();
                }

            }
        }

        public void Check()
        {
            if (c1.GetComponent<ManagerCardInforeverse>().cardID == c2.GetComponent<ManagerCardInforeverse>().cardID)
            {
                if (conPanelInfo)
                {
                    panelInfo.SetActive(true);
                    textInfo.text = frases.Dequeue();
                }

                if (ventanas.Length > 0)
                {
                    if (enOrden)
                    {
                       ventanas[preguntaActual].SetActive(true); 
                    }
                    else
                    {
                        int index = int.Parse(c1.GetComponent<ManagerCardInforeverse>().cardID);
                        ventanas[index].SetActive(true);
                    }

                    preguntaActual++;
                }
                
                Managersound item = FindObjectOfType<Managersound>();
                item.correcto.Play();
                
                botonIntegrador.SetActive(IsFinished());
                //Debug.Log("<color=lime> aca gano? </color>" + IsFinished());
                c1 = null;
                c2 = null;
            }
            else
            { 
                c1.GetComponent<ManagerCardInforeverse>().isUsed = false;
                c1.GetComponent<Button>().interactable = true;
                c2.GetComponent<ManagerCardInforeverse>().isUsed = false;
                c2.GetComponent<Button>().interactable = true;
                if(reverse!= null){
                    StartCoroutine("esperar");
                }else{
                    c1 = null;
                    c2 = null;
                }
                Managersound item = FindObjectOfType<Managersound>();
                item.incorrecto.Play();
            }
        }

        IEnumerator esperar() {
            yield return new WaitForSeconds(1f);
            c1.GetComponent<Image>().sprite = reverse;
            c2.GetComponent<Image>().sprite = reverse;
            c1 = null;
            c2 = null;
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
                bueno.SetActive(true);
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
