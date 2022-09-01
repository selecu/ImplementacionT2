using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using TMPro;


namespace FloMania_vol1
{
    public class DD_item_Drop : MonoBehaviour
    {
        public GameObject item;
        public List<GameObject> vecinos = new List<GameObject>();
        public DD_item_Drag item_drag_registrado;



        //alternativo ---->
        public bool mostrar_tx;
        public TextMeshProUGUI pos_tx;
        // Start is called before the first frame update
        public void Start()
        {
            comprobando_vecinos();
            if (mostrar_tx)
            {
                int charnum = name.Length;
                string new_char = "";
                int index_char = charnum;
                for (int i = 0; i < charnum; i++)
                {
                    if (name[i].ToString() == " ")
                    {
                        index_char = i;
                    }

                    if (i > index_char)
                    {
                        new_char += name[i];
                    }

                }
                pos_tx.text = transform.position.x + " , " + transform.position.y + " : " + new_char;
            } else
            {
                pos_tx.text = "";
            }
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void comprobando_vecinos()
        {
            LayerMask layer = LayerMask.GetMask("casillas");
            RaycastHit2D hitD = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.26f), Vector2.down, 0.8f, layer);
            if(hitD)
            {
                if (hitD.collider.gameObject.GetComponent<DD_item_Drop>())
                {
                    vecinos.Add(hitD.collider.gameObject);
                }
                
            }
            RaycastHit2D hitU = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 0.26f), Vector2.up, 0.8f, layer);
            if (hitU)
            {
                if (hitU.collider.gameObject.GetComponent<DD_item_Drop>())
                {
                    vecinos.Add(hitU.collider.gameObject);
                }

            }
            RaycastHit2D hitR = Physics2D.Raycast(new Vector2(transform.position.x + 0.26f, transform.position.y), Vector2.right, 0.8f, layer);
            if (hitR)
            {
                if (hitR.collider.gameObject.GetComponent<DD_item_Drop>())
                {
                    vecinos.Add(hitR.collider.gameObject);
                }

            }
            RaycastHit2D hitL = Physics2D.Raycast(new Vector2(transform.position.x - 0.26f, transform.position.y), Vector2.left, 0.8f, layer);
            if (hitL)
            {
                if (hitL.collider.gameObject.GetComponent<DD_item_Drop>())
                {
                    vecinos.Add(hitL.collider.gameObject);
                }

            }

        }
    }


}

