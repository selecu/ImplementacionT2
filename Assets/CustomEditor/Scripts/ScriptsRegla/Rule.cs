using UnityEngine;
using UnityEngine.EventSystems;



namespace v1
{
    public class Rule : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public  float xMin = 200f, xMax = 1720f;

       public  float yMin = 105f, yMax = 940f;

        bool dragging = false;

        public void OnBeginDrag(PointerEventData eventData)
        {
            
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = new Vector3(
                Mathf.Clamp(Input.mousePosition.x, xMin, xMax),
                Mathf.Clamp(Input.mousePosition.y, yMin, yMax), 0f);
            dragging = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            dragging = false;
        }

        public void Update()
        {
            if (Input.GetKeyUp("r") && dragging)
            {
                transform.Rotate(0, 0, -90);
            }
        }
    }
}