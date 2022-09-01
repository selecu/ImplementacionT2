using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;


namespace v1
{
    public class ItemPoolTamgram : MonoBehaviour, IDropHandler
    {

        public void OnDrop(PointerEventData eventData)
        {
            if (DragHandlerTamgram.objBeingDraged == null) return;
            DragHandlerTamgram.objBeingDraged.transform.SetParent(transform);
        }

    }

}
