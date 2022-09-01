using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;


namespace v1
{
    public class ItemPoolDragandDrop : MonoBehaviour, IDropHandler
    {

        public void OnDrop(PointerEventData eventData)
        {
            if (DragHandlerDragandDrop.objBeingDraged == null) return;
            DragHandlerDragandDrop.objBeingDraged.transform.SetParent(transform);
        }

    }

}
