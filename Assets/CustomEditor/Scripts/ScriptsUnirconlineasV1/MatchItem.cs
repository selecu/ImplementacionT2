using UnityEngine;
using UnityEngine.EventSystems;


namespace v1
{
    public class MatchItem : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerEnterHandler, IPointerUpHandler
    {

        public static MatchItem hoverItem;

        public GameObject LeneRender;
        public string ItemName;
        public bool IsCorrect;

        private GameObject line;
        [SerializeField] private GameObject parentalInstanceLine;

        private Canvas canvas;

        private void Start()
        {
            canvas = GameObject.FindObjectOfType<Canvas>();
        }
        public void OnDrag(PointerEventData eventData)
        {

            UpdateLine(Input.mousePosition);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            IsCorrect = false;
            if (!line && LeneRender != null)
            {

                if (parentalInstanceLine != null)
                {
                    line = Instantiate(LeneRender, transform.position, Quaternion.identity.normalized, parentalInstanceLine.transform) as GameObject;
                    line.name = line.name;
                }
                else
                {
                    line = Instantiate(LeneRender, transform.position, Quaternion.identity.normalized, transform.parent.parent) as GameObject;
                    line.name = line.name;
                }
                UpdateLine(eventData.position);

            }


        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            hoverItem = this;


        }

        public void OnPointerUp(PointerEventData eventData)
        {

            if (!this.Equals(hoverItem))
            {
                if (this.ItemName.Equals(hoverItem.ItemName))
                {
                    UpdateLine(hoverItem.transform.position);
                    this.IsCorrect = true;
                    hoverItem.IsCorrect = true;
#if UNITY_EDITOR
                    Debug.Log("correcto");
#endif
                }
                else
                {
                    UpdateLine(hoverItem.transform.position);
                    IsCorrect = false;
#if UNITY_EDITOR
                    Debug.Log("Incorrecto");
#endif
                }
            }
            else
            {

                UpdateLine(hoverItem.transform.position);
                IsCorrect = false;
#if UNITY_EDITOR
                Debug.Log("Incorrecto");
#endif
            }



        }


        void UpdateLine(Vector3 position)
        {
            if (line != null && LeneRender != null)
            {
                Vector3 direction = position - transform.position;
                line.transform.right = direction;

                line.transform.localScale = new Vector3(
                    (direction.magnitude / canvas.scaleFactor), 1f* canvas.scaleFactor, 1f);
            }


        }

        public void Reinicio()
        {
            if (LeneRender != null)
            {
                Destroy(line);
            }
        }


    }

}



