using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace I2641
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



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + direccion*velocidadMovimiento * Time.fixedDeltaTime);
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.name == "end")
            {
                velocidadMovimiento = 0;
                buttonIntegrador.SetActive(true);
                buttonIntegrador.SetActive(true);
            }
            else if (
                collision.gameObject.name == "1" ||
                collision.gameObject.name == "2" ||
                collision.gameObject.name == "3" ||
                collision.gameObject.name == "4" ||
                collision.gameObject.name == "5"
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
            velocidadMovimiento = 0;
    }

}

}

