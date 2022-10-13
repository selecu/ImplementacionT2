using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace I2743
{
    public class EnemyPatrol : MonoBehaviour
    {
        [SerializeField]
        private float enemyVelocity;

        [SerializeField]
        private float distanciaminima = 0.01f;

        private int Siguientepaso;

        [SerializeField]
        private Transform[] puntosmovimiento;

        public float EnemyVelocity { get => enemyVelocity; set => enemyVelocity = value; }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, puntosmovimiento[Siguientepaso].position, EnemyVelocity * Time.deltaTime);

            if (Vector2.Distance(transform.position, puntosmovimiento[Siguientepaso].position) < distanciaminima)
            {
                Siguientepaso ++;

                if (Siguientepaso >= puntosmovimiento.Length)
                {
                    Siguientepaso = 0;
                }
            }
        }

        public void SetEnemyVelocity(float value) =>
            EnemyVelocity = value;
    }

}