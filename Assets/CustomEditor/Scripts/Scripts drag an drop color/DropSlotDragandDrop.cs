using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace v1.color
{
    public class DropSlotDragandDrop : MonoBehaviour, IDropHandler
    {
        public GameObject item;
        public string id;
        public bool IsCorrect;
        public int childLimit;

        public void Start()
        {

        }
        public void OnDrop(PointerEventData eventData)
        {

            if (!item && transform.childCount == ( 2 + childLimit))
            {
                item = DragHandlerDragandDrop.objBeingDraged;
                item.transform.SetParent(transform);
                item.transform.position = transform.position;
                transform.GetChild(0).GetComponent<Image>().color = item.transform.GetChild(0).GetComponent<Image>().color;
                Destroy(item);
            }

            if (eventData.pointerDrag.GetComponent<DragHandlerDragandDrop>().id == id)
            {
                IsCorrect = true;
                item.transform.position = transform.position;
                Debug.Log("correcto");
            }
            else
            {
                IsCorrect = false;

                Debug.Log("incorrecto");

            }



        }

        private void Update()
        {
            if (item != null && item.transform.parent != transform)
            {

                item = null;
            }
        }


    }

}
