using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace v1
{
    public class BalanzaFrutas_ItemPool : MonoBehaviour, IDropHandler
    {
        public GameObject item;
        public GameObject[] SoportesLaterales;

        void Start()
        {
            SoportesLaterales = GameObject.FindGameObjectsWithTag("3324_SoportaLateral");
        }

        public void OnDrop(PointerEventData eventData)
        {

            BalanzaFrutas_DragHandler.itemDragging.transform.SetParent(transform);
            for (int i = 0; i < SoportesLaterales.Length; i++)
            {
                SoportesLaterales[i].SetActive(false);
            }
        }

    }
}



