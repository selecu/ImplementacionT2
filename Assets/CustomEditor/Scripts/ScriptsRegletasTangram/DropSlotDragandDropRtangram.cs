using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace v2
{
    public class DropSlotDragandDropRtangram : MonoBehaviour, IDropHandler
    {
        public GameObject item;
        public string id;
        public string rotationID;
        public bool IsCorrect = false;

        public void Start()
        {
            gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = 0f;
        }

        public void OnDrop(PointerEventData eventData)
        {

            if (!item)
            {
                item = DragHandlerDragandDropRtangram.objBeingDraged;
                item.transform.SetParent(transform);
                item.transform.position = transform.position;
            }

            if (eventData.pointerDrag.GetComponent<DragHandlerDragandDropRtangram>().id == id)
            {
                if (eventData.pointerDrag.GetComponent<DragHandlerDragandDropRtangram>().rotationID.ToString() == rotationID)
                {
                    IsCorrect = true;
                }
                else
                {
                    IsCorrect = false;
                    Debug.Log("incorrecto");
                }
            }
            else
            {
                IsCorrect = false;
                Debug.Log("incorrecto");
            }
        }

        private void Update()
        {
            if(item != null)
            {
                if(IsCorrect)
                {
                    item.transform.position = transform.position;
                    Debug.Log("correcto");
                    item.GetComponent<RectTransform>().pivot = new Vector2(0.5f,0.5f);
                    gameObject.GetComponent<DropSlotDragandDropRtangram>().enabled = false;
                }
                if(!IsCorrect)
                {
                    item.GetComponentInChildren<DragHandlerDragandDropRtangram>().StartPosition();
                    item.GetComponent<RectTransform>().pivot = new Vector2(0.5f,0.5f);
                    item.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 0);
                    item.GetComponent<DragHandlerDragandDropRtangram>().rotationID = 0;
                }
            }


            if (item != null && item.transform.parent != transform)
            {
                item = null;
            }
            if(IsCorrect)
            {
                item.GetComponent<DragHandlerDragandDropRtangram>().enabled = false;
            }
        }
    }
}
