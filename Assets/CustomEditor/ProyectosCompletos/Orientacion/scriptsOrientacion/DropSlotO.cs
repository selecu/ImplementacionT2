using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace v1
{
    public class DropSlotO : MonoBehaviour, IDropHandler
    {
        public GameObject item;
        public string id;
        public bool IsCorrect;

        public void OnDrop(PointerEventData eventData)
        {

            if (!item)
            {
                item = DragHandlerO.objBeingDraged;
                item.transform.SetParent(transform);
                item.transform.position = transform.position;

                if (eventData.pointerDrag.GetComponent<DragHandlerO>().id == id)
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

                for (int i = 0; i < this.transform.parent.transform.childCount; i++)
                {
                    DropSlotO dropSlot = this.transform.parent.transform.GetChild(i).GetComponent<v1.DropSlotO>();
                    if (dropSlot.IsCorrect == false)
                    {
                        dropSlot.enabled = false;
                    }

                    if (dropSlot.item != null)
                    {
                        dropSlot.item.GetComponent<v1.DragHandlerO>().enabled = false;
                    }
                }
            }
        }

        private void Update()
        {
            if (item != null && item.transform.parent != transform)
                item = null;
        }


    }

}
