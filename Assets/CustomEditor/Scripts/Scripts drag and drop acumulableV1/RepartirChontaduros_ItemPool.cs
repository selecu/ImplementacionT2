using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace v1
{
    public class RepartirChontaduros_ItemPool : MonoBehaviour, IDropHandler
    {
        public GameObject item;

        public void OnDrop(PointerEventData eventData)
        {
            RepartirChontaduros_DragHandler.itemDragging.transform.SetParent(transform);
        }
    }

}

