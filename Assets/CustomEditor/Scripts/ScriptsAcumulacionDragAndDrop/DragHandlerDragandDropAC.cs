using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;




namespace v1
{
    public class DragHandlerDragandDropAC : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public static GameObject objBeingDraged;

        private Vector3 startPosition;
        private Transform startParent;
        private CanvasGroup canvasGroup;
        private Transform itemDraggerParent;
        public string id;
        public Transform trasformparent;



        private void Start()

        {
            canvasGroup = GetComponent<CanvasGroup>();
            itemDraggerParent = GameObject.FindGameObjectWithTag("ItemDraggerParent").transform;

        }

        #region DragFunctions

        public void OnBeginDrag(PointerEventData eventData)
        {

            objBeingDraged = gameObject;

            startPosition = transform.position;
            startParent = transform.parent;
            transform.SetParent(itemDraggerParent);

            canvasGroup.blocksRaycasts = false;

        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {

            objBeingDraged = null;

            canvasGroup.blocksRaycasts = true;
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
        private void Update()
        {

        }


    }

}

