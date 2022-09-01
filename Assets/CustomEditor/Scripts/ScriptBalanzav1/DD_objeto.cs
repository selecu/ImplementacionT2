using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

namespace v1
{
    public class DD_objeto : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {

        public static GameObject objetoMovido;

        private Vector3 startPosition;
        public Transform startParent;
        private CanvasGroup canvasGroup;
        public Transform itemDraggerParent;
        [Header("valores iniciales")]
        [Space(15)]
        public bool correcto;
        public string id;
        public float Valor;
        public Transform trasformparent;
        public bool Infinity_obj;

        [Header("mejora visual")]
        [Space(15)]
        public GameObject indicador;
        public GameObject poolIndicador;
        // Start is called before the first frame update
        void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            //Debug.Log("iniciamos a dibujar con el mouse");
            if (Infinity_obj)
            {
                GameObject prefab = gameObject;
                objetoMovido = Instantiate(prefab);
                objetoMovido.GetComponent<DD_objeto>().Infinity_obj = false;
            }
            else
            {
                objetoMovido = gameObject;
            }


            startPosition = transform.position;
            startParent = transform.parent;
            transform.SetParent(itemDraggerParent);
            if (indicador)
            {
                indicador.SetActive(true);
            }
            if (poolIndicador)
            {
                poolIndicador.GetComponent<Image>().color = new Vector4(1f, 1f, 1f, 0.3f);
            }


            canvasGroup.blocksRaycasts = false;

        }
        public void OnDrag(PointerEventData eventData)
        {
            //Debug.Log("mientras dibujamos con el boton del maouse");
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //Debug.Log("terminamos de dibujar con el maouse");
            objetoMovido = null;
            canvasGroup.blocksRaycasts = true;
            if (transform.parent == itemDraggerParent)
            {
                transform.position = startPosition;
                transform.SetParent(startParent);
            }

            if (indicador)
            {
                indicador.SetActive(false);
            }
            if (poolIndicador)
            {
                poolIndicador.GetComponent<Image>().color = new Vector4(1f, 1f, 1f, 0f);
            }
        }


        public void StartPosition()
        {
            startParent = transform.parent;
            transform.SetParent(trasformparent);
        }
    }
}

    
