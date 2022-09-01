using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;


namespace v1
{
    public class ItemPoolGr : MonoBehaviour, IDropHandler
    {

        public void OnDrop(PointerEventData eventData)
        {
            if (DragHandlerGr.objBeingDraged == null) return;
            DragHandlerGr.objBeingDraged.transform.SetParent(transform);
        }

    }

}
