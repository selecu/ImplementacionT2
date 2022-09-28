using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullar : MonoBehaviour
{
    [SerializeField]
    private float velocidadmovimiento;
    [SerializeField]
    private Transform[] puntosmovimiento;
    [SerializeField]
    private float distanciaminima;

    private int Siguientepaso;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosmovimiento[Siguientepaso].position, velocidadmovimiento * Time.deltaTime);

        if (Vector2.Distance(transform.position,puntosmovimiento[Siguientepaso].position) < distanciaminima)
        {
            Siguientepaso += 1;

            if(Siguientepaso >= puntosmovimiento.Length)
            {
                Siguientepaso = 0 ;

            }
        }
    }
}
