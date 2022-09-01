using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;


namespace v1
{
    public class ItemPoolO : MonoBehaviour, IDropHandler
    {

        public void OnDrop(PointerEventData eventData)
        {
            if (DragHandlerO.objBeingDraged == null) return;
            DragHandlerO.objBeingDraged.transform.SetParent(transform);
        }

    }

}
