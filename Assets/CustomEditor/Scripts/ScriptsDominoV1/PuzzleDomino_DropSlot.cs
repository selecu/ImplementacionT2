using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace v1
{
    public class PuzzleDomino_DropSlot : MonoBehaviour, IDropHandler
    {
        public GameObject item;
        RectTransform rectTransform;
        //public static int dropCounts;
        float width;
        float height;
        Vector3 zRotation;

        void Start()
        {
            width = gameObject.GetComponent<RectTransform>().rect.width;
            height = gameObject.GetComponent<RectTransform>().rect.height;
            zRotation = gameObject.GetComponent<RectTransform>().eulerAngles;
        }
        public void OnDrop(PointerEventData eventData)
        {
            //Debug.Log("Drop");
            if (!item)
            {
                item = PuzzleDomino_DragHandler.itemDragging;
                item.transform.SetParent(transform);
                item.transform.position = transform.position;
                Image img = item.GetComponent<Image>();
                img.rectTransform.sizeDelta = new Vector2(width, height);
                img.rectTransform.eulerAngles = zRotation;
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