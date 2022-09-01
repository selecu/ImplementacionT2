using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;


namespace v1
{
    public class ItemPoolDragandDropOP : MonoBehaviour, IDropHandler
    {

        public void OnDrop(PointerEventData eventData)
        {
            if (DragHandlerDragandDropOP.objBeingDraged == null) return;
            DragHandlerDragandDropOP.objBeingDraged.transform.SetParent(transform);
        }

    }

}
