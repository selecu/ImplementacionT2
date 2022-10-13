using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using v1;

[RequireComponent(typeof(CanvasGroup))]
public class DragController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static GameObject objBeingDraged;

    private Vector3 startPosition;
    private Transform startParent;
    private CanvasGroup canvasGroup;
    private Transform itemDraggerParent;

    [SerializeField]
    private int valueToSend;
    public Transform trasformparent;
    public DropController[] classesToAffect;
    public int ValueToSend { get => valueToSend; }

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        itemDraggerParent = GameObject.FindGameObjectWithTag("ItemDraggerParent").transform;
    }

    #region DragFunctions

    public void OnBeginDrag(PointerEventData eventData)
    {

        objBeingDraged = gameObject;

        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(itemDraggerParent);

        canvasGroup.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        objBeingDraged = null;

        canvasGroup.blocksRaycasts = true;
        if (transform.parent == itemDraggerParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }

    #endregion
}
