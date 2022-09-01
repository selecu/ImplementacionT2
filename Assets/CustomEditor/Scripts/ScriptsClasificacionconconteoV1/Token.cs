using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace v1
{
    public class Token : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [Header("Settings")]

        [SerializeField] private Transform parentInDrag;

        public static GameObject pointer;

        private Transform myParent;

        private Vector3 myPosition;

        [SerializeField]
        private int id;

        public int uid
        {
            get{return id;}
        }

        private void Start()
        {
            myParent = transform.parent;
            myPosition = transform.position;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            pointer = gameObject;

            transform.SetParent(parentInDrag);
        }

        public void OnDrag(PointerEventData eventData) =>
            transform.position = Input.mousePosition;

        public void OnEndDrag(PointerEventData eventData)
        {
            if(transform.parent == parentInDrag)
                GoHome();
        }

        public void GoHome()
        {
            transform.SetParent(myParent);
            transform.position = myPosition;
        }

        public void SetVars(int _id, Sprite image)
        {
            id = _id;
            GetComponent<Image>().sprite = image;

            GetComponent<Image>().SetNativeSize();
        }

    }
}