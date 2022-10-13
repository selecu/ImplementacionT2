using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace I2743
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class PlayerCollisionController : MonoBehaviour
    {
        public PlayerMovement playerMovement;

        public Transform startPosition;

        [Space(20)]
        public UnityEvent OnWin;
        public UnityEvent OnLose;

        public void Lose()
        {
            ResetPlayerParameters();

            OnLose.Invoke();
        }

        public void Win()
        {
            ResetPlayerParameters();

            OnWin.Invoke();
        }

        public void ResetPlayerParameters()
        {
            playerMovement.PlayerRigidbody2D.velocity = Vector3.zero;
            transform.position = startPosition.position;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                ResetPlayerParameters();

                collision.gameObject.GetComponent<EnemyCollisionController>().collision.Invoke();
            }
            else if (collision.gameObject.name == "CollisionObject")
            {
                ResetPlayerParameters();

                collision.gameObject.GetComponent<ObjectCollisionController>().collision.Invoke();
            }
        }
    }
}
