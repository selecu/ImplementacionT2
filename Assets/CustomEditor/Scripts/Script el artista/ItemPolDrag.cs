using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyNamespace
{
    public class ItemPolDrag : MonoBehaviour,IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            if (DragAndDropManager.objBeingDraged == null) return;
            DragAndDropManager.objBeingDraged.transform.SetParent(transform);
        }
    }

}
