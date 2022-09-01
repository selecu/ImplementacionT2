using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using TMPro;




namespace v1
{
    public class DragHandlerGr : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public static GameObject objBeingDraged;

        private Vector3 startPosition;
        private Transform startParent;
        private CanvasGroup canvasGroup;
        private Transform itemDraggerParent;
        public string id;
        public string idcol;
        public Transform trasformparent;
        public bool correct;
        TMP_Text iden;
        
        



        private void Start()

        {
            canvasGroup = GetComponent<CanvasGroup>();
            itemDraggerParent = GameObject.FindGameObjectWithTag("ItemDraggerParent").transform;
            iden = GetComponentInChildren<TMP_Text>();
            iden.text = id;


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

