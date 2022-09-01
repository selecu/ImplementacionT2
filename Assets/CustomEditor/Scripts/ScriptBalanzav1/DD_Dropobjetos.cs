using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace v1
{
    public class DD_Dropobjetos : MonoBehaviour, IDropHandler
    {
        public GameObject item;
        public string id;
        [Tooltip("limitar el pool a q solo reciba objetos con si mismo ID")]
        public bool Limitar_id;
        public int limit_obj;
        public bool valor_aleatorio;
        public bool contar_valor_objetos;
        public float valor_acumulado;
        public int valor_min;
        public int valor_max;
        public Text valor_contado;
        public formato_valor valor_contado_formato;
        public bool IsCorrect;


        public void Start()
        {
            if (valor_aleatorio)
            {
                contar_valor_objetos = false;
                asignar_valor_aleatorio();
            }
        }
        public void OnDrop(PointerEventData eventData)
        {
            //Debug.Log("OnDrop activado¡¡");
            if (!item || item)
            {
                item = DD_objeto.objetoMovido;
                if (Limitar_id)
                {
                    if (eventData.pointerDrag.GetComponent<DD_objeto>().id == id)
                    {
                        if (limit_obj != 0 && limit_obj > transform.childCount)
                        {
                            item.transform.SetParent(transform);
                            item.transform.position = transform.position;
                        }
                        else
                        {
                            item = null;
                        }
                    }
                    else
                    {
                        item = null;
                    }
                }
                else
                {
                    if (limit_obj != 0 && limit_obj > transform.childCount)
                    {
                        item.transform.SetParent(transform);
                        item.transform.position = transform.position;
                        
                    }
                    else
                    {
                        item = null;
                    }
                }


            }

        }

        private void Update()
        {
            if (item != null && item.transform.parent != transform)
            {
                item = null;
            }
            if (contar_valor_objetos)
            {
                contando_valor_objetos();
            }

        }

        void contando_valor_objetos()
        {
            valor_acumulado = 0;
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<DD_objeto>())
                {
                    valor_acumulado += transform.GetChild(i).GetComponent<DD_objeto>().Valor;
                }

            }
            asignar_valor_contado();
        }

        public void asignar_valor_aleatorio()
        {
            valor_acumulado = Random.Range(valor_min, valor_max);
            asignar_valor_contado();

        }

        void asignar_valor_contado()
        {
            if (valor_contado)
            {
                if (valor_contado_formato == formato_valor.unidades)
                {
                    valor_contado.text = string.Format("{0:00.00}", valor_acumulado);
                }
                if (valor_contado_formato == formato_valor.decenas)
                {
                    int decenas = (int)valor_acumulado / 10;
                    valor_acumulado = decenas*10;
                    valor_contado.text = decenas.ToString() + " Decenas";
                }

            }
        }
    }
    public enum formato_valor
    {

        unidades,
        decenas,
        centenas,
        
    }
}

