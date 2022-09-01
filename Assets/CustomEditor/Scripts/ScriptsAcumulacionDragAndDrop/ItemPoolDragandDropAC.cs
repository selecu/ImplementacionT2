using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;


namespace v1
{
    public class ItemPoolDragandDropAC : MonoBehaviour, IDropHandler
    {

        public void OnDrop(PointerEventData eventData)
        {
            if (DragHandlerDragandDropAC.objBeingDraged == null) return;
            DragHandlerDragandDropAC.objBeingDraged.transform.SetParent(transform);
        }

    }

}
