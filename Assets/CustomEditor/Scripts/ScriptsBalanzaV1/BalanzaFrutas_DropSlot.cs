using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace v1
{
    public class BalanzaFrutas_DropSlot : MonoBehaviour, IDropHandler
    {
        public GameObject item;
        //public static int dropCounts;


        public void OnDrop(PointerEventData eventData)
        {
            //Debug.Log("Drop");
            if (!item)
            {
                item = BalanzaFrutas_DragHandler.itemDragging;
                item.transform.SetParent(transform);
                item.transform.position = transform.position;
                //dropCounts +=1;
                //Debug.Log(dropCounts);  
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

