using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace I2937
{ 
    public class Movemet : MonoBehaviour
    {
        [SerializeField]
        public float velocidadMovimiento;
        [SerializeField]
        private Vector2 direccion;

        private Rigidbody2D rb2d;

        int taskCollision;
        public GameObject buttonIntegrador;
        public GameObject PanelActividades;

        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            rb2d.MovePosition(rb2d.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
                if (collision.gameObject.name == "end" && CheckAllChildActive(PanelActividades))
                {
                    velocidadMovimiento = 0;
                    buttonIntegrador.SetActive(true);
                }
                else if (
                    collision.gameObject.name == "1" ||
                    collision.gameObject.name == "2" ||
                    collision.gameObject.name == "3"
                    )
                {
                    ActivarTask(collision.gameObject.name);
                    Destroy(collision.gameObject);
                }
        }

        void ActivarTask(string input)
        {
            taskCollision = int.Parse(input);
                PanelActividades.transform.GetChild(taskCollision-1).gameObject.SetActive(true);
        }

        bool CheckAllChildActive(GameObject parent)
        {
            for (int i = 0; i < parent.transform.childCount; i++)
                if (!parent.transform.GetChild(i).gameObject.activeInHierarchy)
                    return false;

            FindObjectOfType<v1.Managersound>().correcto.Play();
            return true;
        }

    }
}

