using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;




namespace v1
{
    public class DragHandlerTamgram : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public static GameObject objBeingDraged;

        private Vector3 startPosition;
        private Transform startParent;
        private CanvasGroup canvasGroup;
        public Transform itemDraggerParent;
        [Tooltip ("Identificador que debe coincidir con la posición de respuesta")]
        public string id;
        [Tooltip("Identificador de rotación de la pieza debe coincidir con la respuesta si la pieza debe ser rotada")]
        public int rotationID = 0;
        [Tooltip ("número de rotaciones que tiene la pieza")]
        public int numOfPositions = 8;
        public Transform trasformparent;
        bool dragging = false;
        RectTransform rectTransform;
        int rotation = 0;
        Vector2 startPivot;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;
            startPivot = rectTransform.pivot;
        }

        #region DragFunctions

        public void OnBeginDrag(PointerEventData eventData)
        {

            objBeingDraged = gameObject;

            startPosition = transform.position;
            startParent = transform.parent;
            transform.SetParent(itemDraggerParent);

            canvasGroup.blocksRaycasts = false;

            if (gameObject.tag == "movepivot")
            {
                rectTransform.pivot = new Vector2(0.25f, 0.25f);
            }
            if (gameObject.tag == "movepivotright")
            {
                rectTransform.pivot = new Vector2(0.75f, 0.75f);
            }
            if (gameObject.tag == "movepivotrightdown")
            {
                rectTransform.pivot = new Vector2(0.75f, 0.25f);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
            dragging = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {

            objBeingDraged = null;
            dragging = false;

            canvasGroup.blocksRaycasts = true;
            if (transform.parent == itemDraggerParent)
            {
                transform.position = startPosition;
                transform.SetParent(startParent);
                gameObject.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 0);
                rotationID = 0;
            }

            if (gameObject.tag == "Untagged" || gameObject.tag == "movepivotrightdown" || gameObject.tag == "movepivotrightdown")
            {
                gameObject.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            }
            if (gameObject.tag == "movepivotright" || gameObject.tag == "movepivot")
            {
                gameObject.GetComponent<RectTransform>().pivot = startPivot;
            }
        }

        #endregion

        public void StartPosition()
        {
            startParent = transform.parent;
            transform.SetParent(trasformparent);
            rectTransform.anchoredPosition = new Vector2(0, 0);
        }

        private void Update()
        {
            if (Input.GetKeyUp("r") && dragging)
            {
                transform.Rotate(0, 0, 45);
                rotationID = (rotationID + 1) % numOfPositions;
                Debug.Log(rotationID);
            }
        }
    }

}

