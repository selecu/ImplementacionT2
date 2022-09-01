using UnityEngine;
using UnityEngine.EventSystems;

namespace v1
{
    public class Spore : MonoBehaviour, IDropHandler
    {

        [Header("Settings")]

        [SerializeField] private Transform container;

        public static GameObject pointer;

        [SerializeField]
        int contenido;

        [HideInInspector] public int children = 0;

        private int index = 0, child = 0;


        void Start ()
        {
            contenido = container.childCount;
        }
            

        public void OnDrop(PointerEventData eventData)
        {
            if(children < contenido )
            {
                pointer = Token.pointer;

                for(int i = 0; i < container.childCount; i++)
                {
                    if(container.GetChild(i).childCount == 0)
                    {
                        pointer.transform.SetParent(container.GetChild(i));
                        pointer.transform.
                            SetPositionAndRotation(
                                container.GetChild(i).position,
                                container.rotation
                            );
                        break;
                    }
                }
            }
        }

        void Update()
        {
            if(pointer != null && pointer.transform.parent != transform)
                pointer = null;
            
            if(index >= container.childCount)
            {
                children = child;

                Debug.Log(children);

                child = index = 0;
            }

            child += container.GetChild(index).childCount;

            index++;
        }
    }
}
