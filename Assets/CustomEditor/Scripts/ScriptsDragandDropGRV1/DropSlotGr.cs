using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace v1
{
    public class DropSlotGr : MonoBehaviour, IDropHandler
    {
        public GameObject item;
        public string id;
        public string idcol;
        public bool IsCorrect;
        public int childLimit;

        public void Start()
        {
            
        }
        public void OnDrop(PointerEventData eventData)
        {

            if (!item && transform.childCount == ( 2 + childLimit))
            {
                item = DragHandlerGr.objBeingDraged;
                item.transform.SetParent(transform);
                item.transform.position = transform.position;
            }

            if (eventData.pointerDrag.GetComponent<DragHandlerGr>().id == id && eventData.pointerDrag.GetComponent<DragHandlerGr>().idcol == idcol)
            {
                IsCorrect = true;
                item.transform.position = transform.position;

                Debug.Log("correcto");
                Debug.Log(id +""+ idcol);

                item.GetComponent<DragHandlerGr>().correct = true;
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
