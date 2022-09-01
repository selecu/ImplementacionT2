using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace v1
{
    public class DropSlotDragandDropOP : MonoBehaviour, IDropHandler
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
                item = DragHandlerDragandDropOP.objBeingDraged;
                item.transform.SetParent(transform);
                item.transform.position = transform.position;
            }

            if (eventData.pointerDrag.GetComponent<DragHandlerDragandDropOP>().id == id)
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
