using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;


namespace FloMania_vol1
{
    public class DD_item_Drag : MonoBehaviour
    {
        //public static GameObject objetoMovido;
        public string ID_Drag;
        public GameObject my_pool;

        public bool in_pool_end;
        public int start_index;
        [SerializeField] private List<GameObject> contactos;
        [SerializeField] private GameObject inDrop;
        [SerializeField] private GameObject outDrop;
        public List<Vector3> puntos_usados;

        [SerializeField] private FlowMania_Manager manager;
        private LineRenderer line_drag;
        private Vector3 start_pos;

        
        // Start is called before the first frame update
        void Start()
        {
            line_drag = GetComponent<LineRenderer>();
            start_pos = transform.position;

            for (int i = 0; i < line_drag.positionCount; i++)
            {
                line_drag.SetPosition(i, transform.position);
            }

            manager = FindObjectOfType<FlowMania_Manager>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        //cuando tomamos el item con nuestro mouse ¡¡ -->
        private void OnMouseDown()
        {
            //si el item_Drag ya llego a su pool sinal -->
            if (in_pool_end)
            {
                //remover el bool final-->
                in_pool_end = false;
                //limpiar la lista de puntos usados para el linea renderer-->
                puntos_usados.Clear();
                puntos_usados.Add(start_pos);
                //reiniciamos todos los puntos de la linea al inicio -->
                for (int i = 1; i < line_drag.positionCount; i++)
                {
                    line_drag.SetPosition(i, start_pos);
                }

                //asginamos el objeto cercano -->
                inDrop = manager.casillas[start_index-1].gameObject;
                //asignamos los vecinos a los cuales podemos continuar el camino -->
                contactos = inDrop.GetComponent<DD_item_Drop>().vecinos;
            }
            //cofiguracion de la linea -->
            int last_line = line_drag.positionCount - 1;
            line_drag.SetPosition(last_line, transform.position);
        }

        //metodo: accion cuando soltamos el click de mouse -->
        private void OnMouseUp()
        {
            //anulamos el objeto q estamos moviendo -->
            //objetoMovido = null;
            //si el pool final esta definido -->
            if (my_pool)
            {
                //guardamos la posiscion del pool final a nuestro itemDrag -->
                transform.position = my_pool.transform.position;
                //indicamos q el pool end esta completado -->
                in_pool_end = true;
            }
            //si pool no esta definido --->
            else {
                //reiniciamos el item_Dragg -->
                transform.position = start_pos;
                //limpiamos la lista de puntos usados -->
                puntos_usados.Clear();
                puntos_usados.Add(start_pos);
                //asignamos el mismo valor a todos los puntos de la linea -->
                for (int i = 1; i < line_drag.positionCount; i++)
                {
                    line_drag.SetPosition(i, start_pos);
                }
                
                //asignamos el nuevo InDrop -->
                int new_index = start_index;
                inDrop = manager.casillas[new_index-1].gameObject;
                //asginamos los vecinos a los cuales podemos sontinuar el camino -->
                contactos = inDrop.GetComponent<DD_item_Drop>().vecinos;
                
            }
            

        }
        private void OnMouseDrag()
        {
            Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse_pos.z = 0;
            transform.position = mouse_pos;

            //line
            line_drag.SetPosition(line_drag.positionCount - 1, mouse_pos);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<DD_item_Drop>())
            {
                //si InDrop no esta definido -->
                if (!inDrop)
                {
                    //guardamos ese objeto colisionado como InDrop
                    inDrop = collision.gameObject;
                    //si el Indrop contiene item_drag_registrado, es por q ya esta en una linea -->
                    if (inDrop.GetComponent<DD_item_Drop>().item_drag_registrado)
                    {
                        //eliminamos la linea con la cual chocamos
                        DD_item_Drop DD_InDrop = inDrop.GetComponent<DD_item_Drop>();
                        DD_InDrop.item_drag_registrado.puntos_usados.Clear();
                        DD_InDrop.item_drag_registrado.actualizar_line();
                    }
                    //guadamos la posicion del InDrop en la lista de puntos usados -->
                    puntos_usados.Add(inDrop.transform.position);
                    //actualizamos los puntos de la linea -->
                    actualizar_line();
                    //guardamos los vecinos del InDrop para saber a cuales podemos seguir -->
                    contactos = inDrop.GetComponent<DD_item_Drop>().vecinos;

                }
                //si InDrop esta definido -->
                else
                {
                    //ACcciones -->
                    
                    //comprobamos q el collisionado sea uno de los objetos vecinos a los q podemos pasar -->
                    if (contactos.Contains(collision.GetComponent<DD_item_Drop>().gameObject))
                    {
                        //primero es comprobar q el InDrop no tenga ningun pool como hijo -->
                        if (collision.transform.GetComponentsInChildren<DD_pool>().Length > 0)
                        {
                            DD_pool[] pools_inDrop = collision.transform.GetComponentsInChildren<DD_pool>();
                            foreach (var pool in pools_inDrop)
                            {
                                if (pool.ID_pool == ID_Drag)
                                {
                                    my_pool = collision.gameObject;
                                    break;
                                }
                            }
                            return;
                        }

                        //añadimos la condicion q el drop (casilla) no tenga el item_drag_registrado-->
                        if (!collision.GetComponent<DD_item_Drop>().item_drag_registrado)
                        {
                            //si es un vecino podemos asignarlo a nuestro InDrag -->
                            //si no tiene el item_drag_registadro podemos asignarlo a nuestro InDrag-->
                            inDrop = collision.gameObject;
                        }
                        else
                        {
                            //verificamos q el item registrado sea igual a este item -->
                            if(collision.GetComponent<DD_item_Drop>().item_drag_registrado == GetComponent<DD_item_Drop>())
                            {
                                inDrop = collision.gameObject;
                            }
                            //si es un item diferente, revisamos si ese item ya esta in su pool_end -->
                            else
                            {
                                //si ese item_registrado no esta en el Pool_end, lo podemos asignar -->
                                if (!collision.GetComponent<DD_item_Drop>().item_drag_registrado.in_pool_end)
                                {
                                    inDrop = collision.gameObject;
                                } else
                                {
                                    return;
                                }
                            }
                        }
                        
                        //verificamos q el punto del InDrag no este en nuestra lista de puntos -->
                        if (puntos_usados.Contains(inDrop.transform.position))
                        {
                            //si nuestra lista contiene el punto tendremos q -->
                            return;
                        }
                        
                        //si ese InDrag no esta en nuestra lista de puntos -->
                        else
                        {
                            //añadimos ese punto a nuestra linea -->
                            puntos_usados.Add(inDrop.transform.position);
                            //y asignamos nuevos vecinos para saber a cual podeos seguir -->
                            contactos = inDrop.GetComponent<DD_item_Drop>().vecinos;
                            actualizar_line();
                            inDrop.GetComponent<DD_item_Drop>().item_drag_registrado = GetComponent<DD_item_Drag>();
                        }
                        

                    }
                }
                
            }
            
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            //cuando salgamos de un collider2D -->
            //verificamos si nos alejamos de un Drop q tiene un Pool dentro -->
            if (collision.transform.GetComponentsInChildren<DD_pool>().Length > 0)
            {
                //si tiene a lo sumo uno tendremos q ver cual de esos es nuestro pool -->
                DD_pool[] pools_inDrop = collision.transform.GetComponentsInChildren<DD_pool>();
                foreach (var pool in pools_inDrop)
                {
                    if (pool.ID_pool == ID_Drag)
                    {
                        my_pool = null;
                        break;
                    }
                }
            }


        }
        
        public void actualizar_line()
        {
            if (line_drag)
            {
                for (int i = 1; i < line_drag.positionCount; i++)
                {
                    if (puntos_usados.Count != 0)
                    {
                        if (i < puntos_usados.Count)
                        {
                            line_drag.SetPosition(i, puntos_usados[i]);
                        }
                        else
                        {
                            line_drag.SetPosition(i, puntos_usados[puntos_usados.Count - 1]);
                        }
                    }
                    else
                    {
                        line_drag.SetPosition(i, line_drag.GetPosition(0));
                    }


                }
            }
            else
            {
                //Debug.Log("no hay line disponible");
            }
            
        }


       


        //fin class -->
    }

}
