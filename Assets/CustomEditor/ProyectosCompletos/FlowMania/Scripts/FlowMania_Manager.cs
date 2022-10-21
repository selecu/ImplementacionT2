using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



namespace FloMania_vol1
{
    [System.Serializable]
    public class Item_Drag
    {
        [Header("posiciones iniciales: ")]
        public int pos_start;
        public int pos_end;

        [Header("configuracion grafica: ")]
        [Space(15)]
        public Color color_base;
        public Color color_pools;
        public Sprite image_pool_start;
        public Sprite image_pool_end;

    }
    public class FlowMania_Manager : MonoBehaviour
    {
        [Header("Configuracion general")]
        public Vector3 offset_camara;
        [Tooltip("numero de casillas q tendra el tablero a lo ancho de la pantalla")]
        public int width_tablero;
        [Tooltip("numero de casillas q tendra el tablero a lo alto de la pantalla")]
        public int heigth_tablero;





        [Header("alementos de la jerarquia")]
        [Space(15)]
        public GameObject camera1;
        public GameObject Tablero;
        public GameObject prefab_casilla;
        public List<Item_Drag> num_item_drag;
        [SerializeField]private List<GameObject> items_InScena = new List<GameObject>();
        public List<GameObject> casillas;
        public List<Vector3> puntos_usados;
        
        [Space(15)]
        public GameObject item_drag;
        public GameObject pool_start;
        public GameObject pool_end;

        [Space(15)]
        public GameObject check;
        public GameObject check_Integrador;
        // Start is called before the first frame update

        string namescene;
        

        void Start()
        {
            iniciar_tablero();
            crear_pools();
            namescene = SceneManager.GetActiveScene().name;
            
        }

        // Update is called once per frame
        void Update()
        {
            posicionar_camara();
        }

        void posicionar_camara()
        {
            //posicion de la camara -->
            Vector3 pos_camara1 = new Vector3();
            pos_camara1.x = width_tablero / 2;
            pos_camara1.y = heigth_tablero / 2;
            pos_camara1.z = -(heigth_tablero + 2);
            camera1.transform.position = pos_camara1 + offset_camara;
            camera1.GetComponent<Camera>().orthographicSize = pos_camara1.y + offset_camara.z;
        }
        void iniciar_tablero()
        {
            //diseñando el tablero -->
            Tablero.transform.localScale = new Vector3(width_tablero,heigth_tablero,0f);
            Tablero.transform.position = new Vector3(width_tablero/2f, heigth_tablero/2f,0f);

            //diseño casillas -->

            int columna = 0;
            int fila = 0;
            for (int i = 0; i < (width_tablero * heigth_tablero); i++)
            {
                GameObject casilla1 = Instantiate(prefab_casilla);
                casillas.Add(casilla1);
                casilla1.name = "casilla #" + (i+1);
                casilla1.tag = "casilla";
                
                float pos_x= 0.5f + columna;
                float pos_y = 0.5f + fila;
                casilla1.transform.position = new Vector3(pos_x, pos_y, 0f);
                casilla1.transform.SetParent(Tablero.transform);

                if (i < (width_tablero * (fila + 1))-1)
                {
                    columna++;
                }
                else
                {
                    fila++;
                    columna = 0;
                }
            }
            /*
            for (int i = 0; i < (width_tablero * heigth_tablero); i++)
            {
                GameObject C = Instantiate(prefab_casilla);
                C.transform.SetParent(Tablero.transform);
            }*/
            

        }

        void crear_pools()
        {
            for (int i = 0; i < num_item_drag.Count; i++)
            {
                //creando pool_start¡¡ -->
                GameObject ps = Instantiate(pool_start);
                int index = num_item_drag[i].pos_start;
                Transform t_ps = casillas[index-1].transform;
                ps.transform.position = t_ps.position;
                ps.transform.SetParent(t_ps);
                ps.GetComponent<SpriteRenderer>().color = num_item_drag[i].color_pools;
                ps.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = num_item_drag[i].image_pool_start;
                //ps.transform.GetChild(1).GetComponent<DD_item_Drag>().ID_Drag = i.ToString();
                ps.GetComponent<DD_pool>().ID_pool = i.ToString();

                //creando item_drag-->s
                GameObject ps_child = Instantiate(item_drag);
                ps_child.transform.position = ps.transform.position;
                ps_child.transform.SetParent(ps.transform);
                ps_child.GetComponent<DD_item_Drag>().ID_Drag = i.ToString();
                ps_child.GetComponent<DD_item_Drag>().start_index = index;
                ps_child.GetComponent<SpriteRenderer>().color = num_item_drag[i].color_base;
                ps_child.GetComponent<LineRenderer>().startColor= num_item_drag[i].color_base;
                ps_child.GetComponent<LineRenderer>().endColor = num_item_drag[i].color_base;
                ps_child.GetComponent<LineRenderer>().positionCount = width_tablero * heigth_tablero;
                items_InScena.Add(ps_child);

                //cambiando posicion hijos pe -->
                GameObject psh = ps.transform.GetChild(0).gameObject;
                psh.transform.SetParent(null);
                psh.transform.SetParent(ps.transform);

                //creando pool_end¡¡ -->
                GameObject pe = Instantiate(pool_end);
                int index2 = num_item_drag[i].pos_end;
                Transform t_pe = casillas[index2 - 1].transform;
                pe.transform.position = t_pe.position;
                pe.transform.SetParent(t_pe);

                pe.GetComponent<SpriteRenderer>().color = num_item_drag[i].color_pools;
                pe.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = num_item_drag[i].image_pool_end;
                pe.GetComponent<DD_pool>().ID_pool = i.ToString();

            }
        }


        public void check_actividad()
        {
            int correctos = 0;
            foreach (var item in items_InScena)
            {
                if (item.GetComponent<DD_item_Drag>().in_pool_end)
                {
                    correctos++;
                }
                else
                {
                    Debug.Log("Respuestas <color=red>Malas¡¡</color>" + correctos);
                }
            }

            if (correctos == items_InScena.Count)
            {
                check.SetActive(false);
                check_Integrador.SetActive(true);
            }
            else
            {
                casillas.Clear();
                items_InScena.Clear();
                carga();
            }
        }

        public void carga()
        {
           
            FloMania_vol1.ClearTablero item1 = FindObjectOfType<ClearTablero>();
            item1.eliminar();

             iniciar_tablero();
             crear_pools();
        }
    }
}

