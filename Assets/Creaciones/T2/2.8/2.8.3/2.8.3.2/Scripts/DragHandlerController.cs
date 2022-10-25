using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace I2832
{
    public static class DragStaticComponents
    {
        private static Image imageTarget;
        private static bool dragging;
        public static Image ImageTarget { get => imageTarget; set => imageTarget = value; }
        public static bool Dragging { get => dragging; set => dragging = value; }
    }
    public class DragHandlerController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public static GameObject objBeingDraged;
        private Vector3 startPosition;
        private Transform startParent;
        private CanvasGroup canvasGroup;
        private Transform itemDraggerParent;

        public Sprite sendSprite;
        public GameObject panelToActive;
        public int totalDrags;

        public UnityEvent OnTotalDrags;

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
            DragStaticComponents.Dragging = true;
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

            OnEndDrag();

            if (DragStaticComponents.Dragging)
                DragStaticComponents.Dragging = false;   
        }

        #endregion

        public void StartPosition() =>
            startParent = transform.parent;

        public void OnEnterTrigger(Image target)
        {
            if (DragStaticComponents.Dragging)
                DragStaticComponents.ImageTarget = target;
        }

        public void OnEndDrag()
        {
            if (DragStaticComponents.ImageTarget == null) return;
            DragStaticComponents.ImageTarget.sprite = sendSprite;

            panelToActive.SetActive(true);
        }
            
    }
}
