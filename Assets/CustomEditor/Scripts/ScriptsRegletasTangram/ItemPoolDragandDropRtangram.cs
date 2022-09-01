using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;


namespace v2
{
    public class ItemPoolDragandDropRtangram : MonoBehaviour, IDropHandler
    {

        public void OnDrop(PointerEventData eventData)
        {
            if (DragHandlerDragandDropRtangram.objBeingDraged == null) return;
            DragHandlerDragandDropRtangram.objBeingDraged.transform.SetParent(transform);
        }

    }

}
