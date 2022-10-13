using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

namespace I2743
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float movementVelocity;

        private Vector2 direccionP;

        private Rigidbody2D playerRigidbody2D;
        private BoxCollider2D playerCollider;

        public float MovementVelocity { get => movementVelocity; set => movementVelocity = value; }
        public BoxCollider2D PlayerCollider { get => playerCollider; set => playerCollider = value; }
        public Rigidbody2D PlayerRigidbody2D { get => playerRigidbody2D; set => playerRigidbody2D = value; }

        void Start()
        {
            PlayerRigidbody2D = GetComponent<Rigidbody2D>();
            PlayerCollider = GetComponent<BoxCollider2D>();
            PlayerCollider.enabled = true;
        }

        void Update()
        {
            direccionP = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            PlayerRigidbody2D.MovePosition(PlayerRigidbody2D.position + direccionP * MovementVelocity * Time.fixedDeltaTime);
        }

        public void SetMovementVelocity(int value) =>
            movementVelocity = value;
    }
}

