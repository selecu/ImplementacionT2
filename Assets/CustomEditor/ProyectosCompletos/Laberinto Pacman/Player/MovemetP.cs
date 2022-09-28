using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace v1
{
    public class MovemetP : MonoBehaviour
{
    [SerializeField] 
    private float velocidadMovimientoP;
    [SerializeField] 
    private Vector2 direccionP;
   
    //public Mundo Mundo;
    private Rigidbody2D rb2dP;
    private BoxCollider2D col;
   
    
    // Start is called before the first frame update
    void Start()
    {
        rb2dP = GetComponent<Rigidbody2D>();
        col = FindObjectOfType<BoxCollider2D>();
        col.enabled = true;
    }

    void Update ()
    {
        direccionP = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb2dP.MovePosition(rb2dP.position + direccionP * velocidadMovimientoP * Time.fixedDeltaTime);
    }

    public void Lose()
    {
        col.enabled = false;
        rb2dP.velocity = Vector3.zero;
        transform.position = new Vector3 (0.3f, -0.96f, 0);
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            // Mundo.vida--;
            transform.position = new Vector3(0.3f, -0.96f, 0);



        }
       


    }

}

}

