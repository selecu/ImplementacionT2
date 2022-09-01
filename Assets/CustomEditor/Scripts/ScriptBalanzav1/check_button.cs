using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace v1
{
    public class check_button : MonoBehaviour
    {

        public bool Actividad_completada;
        [Header("opciones de configuracion")]
        [Space(10)]
        [Tooltip("numero de ejercicios totales q tiene la interaccion¡¡ \n min:1 , maximo: #")]
        public int Rep_ejercicio = 1;
        [Tooltip("numero de segundos para terminar la prueba")]
        public float Temporizador;
        [Tooltip("ordenar los objetos a mover de forma aleatoria")]
        public bool OrdenObjetos_aleatorio;
        [Tooltip("Recinia los objetos q estan mal clacificados,\n objetos con id diferente al pool")]
        public bool reiniciar_objetos;
        public bool reiniciar_objetos_mal_ubicados;

        [Header("Objeto padre donde se encuentras los objeto a mover, a los pools donde van los objetos")]
        [Space(10)]
        public GameObject pool_objetos;
        public GameObject Pools;
        public DD_Dropobjetos[] Valor_pools;

        [Header("Elementos activos")]
        public GameObject BTN_Integrador;
        public Text tx_temporizador;
        [Tooltip("aqui van los objetos q se activaran del marcador de ejercisios.")]
        public GameObject[] marcador;
        public GameObject fallo;

        public bool peso_derecha;
        public Animator animador;
        //elementos no visibles-->
        private int ejercicio_actual = 1;
        private float tiempo;
        [SerializeField]private bool respuesta_mala = false;
        [SerializeField]private List<GameObject> objetos_movibles;

        public GameObject[] ventana;
        // Start is called before the first frame update
        void Start()
        {

            crear_listaObjetos(pool_objetos);
            if (OrdenObjetos_aleatorio)
            {
                ordenarLista_aleatoriamente(objetos_movibles);
            }
            //reiniciar los objetos del game -->
            if (reiniciar_objetos)
            {
                reiniciar_objetos_mal_ubicados = false;
            }

            //temprizador -->
            tiempo = Temporizador;
        }

        // Update is called once per frame
        void Update()
        {
            if (respuesta_mala || !Actividad_completada)
            {
                temporizar_actividad();
            } else
            {
                tiempo = 0;
            }

            animar_balanza();
        }

        //Ordenar los objetos a mover en orden aleatorio -->
        void crear_listaObjetos(GameObject padre_Objetos)
        {
            for (int i = 0; i < padre_Objetos.transform.childCount; i++)
            {
                if (padre_Objetos.transform.GetChild(i).GetComponent<DD_objeto>().enabled == true)
                {
                    objetos_movibles.Add(padre_Objetos.transform.GetChild(i).gameObject);
                }
            }
                
        }
        void ordenarLista_aleatoriamente<T>(List<T> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                T temp = list[i];
                int rnd = UnityEngine.Random.Range(i, list.Count);
                list[i] = list[rnd];
                GameObject hijo1 = null;
                hijo1 = pool_objetos.transform.GetChild(i).gameObject;
                hijo1.transform.SetParent(null);
                hijo1.transform.SetParent(pool_objetos.transform);
                list[rnd] = temp;
                GameObject hijo2 = null;
                hijo2 = pool_objetos.transform.GetChild(rnd).gameObject;
                hijo2.transform.SetParent(null);
                hijo2.transform.SetParent(pool_objetos.transform);


            }
        }




        //temporizador para la actividad -->
        void temporizar_actividad()
        {
            if(Temporizador != 0)
            {
                tiempo -= Time.deltaTime;
                string minutos = null;
                minutos = ((int)tiempo / 60).ToString();

                string segundos = null;
                if (tiempo <= 60)
                {
                    segundos = string.Format("{00:00}", tiempo);
                }
                else
                {
                    segundos = string.Format("{00:00}", tiempo - 60);
                }
                tx_temporizador.text = string.Format("{000:000}:{1:00}",minutos, segundos);

                //si el tiempo se agoto¡¡ -->
                if(tiempo <= 0)
                {
                    //Y respesta_mala es verdadera ó actividad_correcta es falsa -->
                    if (respuesta_mala || !Actividad_completada)
                    {
                        check_clacificar();
                        //tiempo = Temporizador;
                        StartCoroutine("fin_juego");
                    }
                    
                }
            }
        }
        //check q funciona para clacificar losobjetos asignados en los pools-->
        public void check_clacificar()
        {
            
            foreach (var objeto in objetos_movibles)
            {
                if (objeto.transform.parent.GetComponent<DD_Dropobjetos>())
                {
                    if (objeto.GetComponent<DD_objeto>().id == objeto.transform.parent.GetComponent<DD_Dropobjetos>().id)
                    {
                        if (objeto == objetos_movibles[objetos_movibles.Count - 1])
                        {
                            Actividad_completada = true;
                            v1.Managersound item = FindObjectOfType<Managersound>();
                            item.correcto.Play();
                            ventana[0].SetActive(true);
                            
                        }
                        Debug.Log("objeto bn ubicado");
                        continue;
                    }
                    else
                    {
                        respuesta_mala = true;
                        
                        Debug.Log("respuesta mala¡");
                        break;
                    }
                }
                else
                {
                    respuesta_mala = true;
                    
                    Debug.Log("respuesta mala¡");
                   
                    break;
                }

            }

            if (respuesta_mala)
            {
                Debug.Log("respuesta mala¡");
                if (reiniciar_objetos)
                {
                    reiniciar_objetos_juego();
                   
                }
                if (reiniciar_objetos_mal_ubicados)
                {
                    reiniciar_objetos_ubicados();
                    
                }

               
                respuesta_mala = false;

               
            }
            if (Actividad_completada)
            {
                if(Rep_ejercicio > 1)
                {
                    Debug.Log("hay q repetir el ejercisio¡¡");
                    if(ejercicio_actual < Rep_ejercicio)
                    {
                        reiniciar_objetos_juego();
                        foreach (var pool in Valor_pools)
                        {
                            pool.valor_acumulado = 0;
                            if (pool.valor_aleatorio)
                            {
                                pool.asignar_valor_aleatorio();
                            }
                        }

                    }
                } else
                {
                    completar_actividad();
                    v1.Managersound item = FindObjectOfType<Managersound>();
                    item.correcto.Play();
                    ventana[0].SetActive(true);

                }
                
            }
            else 
            {
                
            }

        }
        //check q funciona para comparar los valores de los pools, como en una balanza -->
        public void check_Comparar_valores_pools(GameObject Check_integrador)
        {
            //DD_Dropobjetos[] Valor_pools = Pools.GetComponentsInChildren<DD_Dropobjetos>();
            foreach (var pool_valor in Valor_pools)
            {

            }


            if (Valor_pools[0].valor_acumulado != 0 && Valor_pools[1].valor_acumulado != 0)
            {
                if (Valor_pools[0].valor_acumulado == Valor_pools[1].valor_acumulado)
                {
                    Debug.Log("bien pagado¡¡");
                    v1.Managersound item = FindObjectOfType<Managersound>();
                    item.correcto.Play();
                    ventana[0].SetActive(true);
                    if (Rep_ejercicio > 1)
                    {
                        Debug.Log("hay q repetir el ejercisio¡¡");
                        if (ejercicio_actual < Rep_ejercicio)
                        {
                            pool_objetos.GetComponent<GridLayoutGroup>().enabled = true;
                            reiniciar_objetos_juego();
                            foreach (var pool in Valor_pools)
                            {
                                
                                pool.valor_acumulado = 0;
                                if (pool.valor_aleatorio)
                                {
                                    pool.asignar_valor_aleatorio();
                                }
                            }
                            //pool_objetos.GetComponent<GridLayoutGroup>().enabled = false;
                            marcador[ejercicio_actual].SetActive(true);
                            ejercicio_actual++;
                        }
                        else
                        {
                            //completar la actividad¡¡
                            Check_integrador.SetActive(true);
                            
                            item.correcto.Play();
                            ventana[0].SetActive(true);
                           

                        }
                    }
                    else
                    {
                        Check_integrador.SetActive(true);
                       
                        item.correcto.Play();
                        ventana[0].SetActive(true);
                       
                    }
                    

                }
                else
                {
                    //primero tenemos el valor del pool fijo al cual queremos llegar  a completar -->
                    //el segundo pools es el valor q estamos llenando para completar el valor q deseamos -->
                    if (Valor_pools[1].valor_acumulado > Valor_pools[0].valor_acumulado)
                    {
                        Debug.Log("aun faltan monedas para poder pagar la cuenta");
                        v1.Managersound item = FindObjectOfType<Managersound>();
                        item.incorrecto.Play();
                        ventana[1].SetActive(true);
                        StartCoroutine(Waiting());
                    }
                    else
                    {
                        Debug.Log("creo q has pagado de mas, pero no hay cambio, retira monedas para ajustar el precio.");
                        v1.Managersound item = FindObjectOfType<Managersound>();
                        item.incorrecto.Play();
                        ventana[1].SetActive(true);
                        StartCoroutine(Waiting());
                    }
                }
            }
            else
            {
                Debug.Log("hay q adicionar productos y monedas para completar el ejercicio");
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.incorrecto.Play();
                ventana[1].SetActive(true);
                StartCoroutine(Waiting());
            }

        }


        //verificamos si la actividad esta correcta -->
        public void completar_actividad()
        {
            if (!respuesta_mala && Actividad_completada)
            {
                BTN_Integrador.SetActive(true);
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.correcto.Play();
                ventana[0].SetActive(true);
            }
            else
            {
                
            }
            
        }
        //reiniciamos la ubicacion de todos objetos --->
        public void reiniciar_objetos_juego()
        {
            foreach (var objeto in objetos_movibles)
            {
                objeto.GetComponent<DD_objeto>().correcto = false;
                objeto.transform.SetParent(objeto.GetComponent<DD_objeto>().trasformparent);
            }
        }
        //reiniciamos la ubicacion de los objetos q no estan en el pool correcto --->
        public void reiniciar_objetos_ubicados()
        {
            foreach (var objeto in objetos_movibles)
            {
                if (objeto.transform.parent.GetComponent<DD_Dropobjetos>())
                {
                    if (objeto.GetComponent<DD_objeto>().id != objeto.transform.parent.GetComponent<DD_Dropobjetos>().id)
                    {
                        objeto.GetComponent<DD_objeto>().correcto = false;
                        objeto.transform.SetParent(objeto.GetComponent<DD_objeto>().trasformparent);
                    }
                }     
            }
        }
        public IEnumerator fin_juego()
        {
            if (respuesta_mala || !Actividad_completada)
            {
                //fallo.SetActive(true);
                yield return new WaitForSeconds(1f);
                //fallo.SetActive(false);
                if (reiniciar_objetos)
                {
                    reiniciar_objetos_juego();
                }
                if (reiniciar_objetos_mal_ubicados)
                {
                    reiniciar_objetos_ubicados();
                }
                tiempo = Temporizador;
                respuesta_mala = false;

            }
            
        }

        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(5);
            ventana[1].SetActive(false);
            StopCoroutine(Waiting());
        }


        public void animar_balanza()
        {
            //DD_Dropobjetos[] Valor_pools = Pools.GetComponentsInChildren<DD_Dropobjetos>();
            float peso_balanza = Valor_pools[1].valor_acumulado;
            float peso_agregado = Valor_pools[0].valor_acumulado;
            if (!peso_derecha)
            {
                peso_balanza = Valor_pools[0].valor_acumulado;
                peso_agregado = Valor_pools[1].valor_acumulado;
            }
            //Debug.Log("peso balanza : " + peso_balanza);
            //Debug.Log("peso agregado : " + peso_agregado);
            float valor_relativo = 10 / peso_balanza;
            //Debug.Log("peso relativo : " + valor_relativo);
            float peso_total = 0;
            if (peso_derecha)
            {
                peso_total = ((-valor_relativo * peso_balanza) + (valor_relativo * peso_agregado));
            } else
            {
                peso_total = ((valor_relativo * peso_balanza) + (-valor_relativo * peso_agregado));
            }
            
            Debug.Log("peso total : " + peso_total);


            animador.SetFloat("peso", peso_total);
        }
         
    }
}
