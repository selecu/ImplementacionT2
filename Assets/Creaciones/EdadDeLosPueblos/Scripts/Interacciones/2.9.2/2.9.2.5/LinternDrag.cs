using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;




namespace I2925
{
    public class LinternDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public static GameObject objBeingDraged;

        private Vector3 startPosition;
        private Transform startParent;
        private Transform itemDraggerParent;
        public Transform trasformparent;



        private void Start()
        {
            itemDraggerParent = GameObject.FindGameObjectWithTag("ItemDraggerParent").transform;

        }

        #region DragFunctions

        public void OnBeginDrag(PointerEventData eventData)
        {

            objBeingDraged = gameObject;

            startPosition = transform.position;
            startParent = transform.parent;
            transform.SetParent(itemDraggerParent);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            objBeingDraged = null;

            if (transform.parent == itemDraggerParent)
            {
                transform.position = startPosition;
                transform.SetParent(startParent);
            }
        }

        #endregion

        public void StartPosition()
        {
            startParent = transform.parent;
            transform.SetParent(trasformparent);
        }
    }

}

