using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

namespace v1
{
    public class DD_poolObjetos : MonoBehaviour, IDropHandler
    {
        public string id;
        public int limit_obj;

        private void Start()
        {

        }
        public void OnDrop(PointerEventData eventData)
        {
            if (DD_objeto.objetoMovido == null) return;
            if (eventData.pointerDrag.GetComponent<DD_objeto>().id == id)
            {
                //si el limite de objetos q puede tener el pool es difrente a cero -->
                if (limit_obj != 0)
                {
                    if (limit_obj > transform.childCount)
                    {
                        //haga padre del objeto q se mueve con el drag -->
                        DD_objeto.objetoMovido.transform.SetParent(transform);
                    }
                    else
                    {
                        //destruya el objeto, ya q este pool no puede tener mas -->
                        DD_objeto.objetoMovido.GetComponent<DD_objeto>().indicador.SetActive(false);
                        DD_objeto.objetoMovido.GetComponent<DD_objeto>().poolIndicador.GetComponent<Image>().color = new Vector4(1f, 1f, 1f, 0f);
                        Destroy(DD_objeto.objetoMovido);
                        DD_objeto.objetoMovido = null;
                    }


                }
                else
                {
                    //haga padre del objeto q se mueve con el drag -->
                    DD_objeto.objetoMovido.transform.SetParent(transform);
                }
            }

        }

    }
}



