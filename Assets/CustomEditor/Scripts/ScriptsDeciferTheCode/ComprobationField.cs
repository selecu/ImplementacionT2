using Interactions.DeciferTheCode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace Interactions.DeciferTheCode.Comprobation
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class ComprobationField : MonoBehaviour
    {
        public string correctValue;
        public string valueToComprobate;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //if (collision.CompareTag("DecifersTheCode"))
            //{
            //    print(collision.name);
            //}
            if (collision.GetComponent<BackCollision.RouletteCollisionComponent>())
            {
                valueToComprobate = collision.GetComponent<BackCollision.RouletteCollisionComponent>().valueToSend;
            }
        }
    }
}
