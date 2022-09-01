using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace v1
{
    public class BalanzaFrutas_DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public static Vector3 startPosition0;

        public static GameObject itemDragging;
        public static Text text;
        Vector3 startPosition;
        Transform startParent;
        Transform dragParent;

        private void Start()
        {
            startPosition0 = transform.position;
            dragParent = GameObject.Find("DragParent").transform;
        }


        public void OnBeginDrag(PointerEventData eventData)
        {
            //Debug.Log("OnBeginDrag");
            itemDragging = gameObject;

            startPosition = transform.position;
            startParent = transform.parent;
            transform.SetParent(dragParent);
        }

        public void OnDrag(PointerEventData eventData)
        {
            //Debug.Log("OnDrag");
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //Debug.Log("OnEndDrag");
            itemDragging = null;

            if (transform.parent == dragParent)
            {
                transform.position = startPosition;
                transform.SetParent(startParent);

            }

        }


    }

}




