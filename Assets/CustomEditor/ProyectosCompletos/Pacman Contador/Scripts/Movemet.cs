using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace v1.Pacmancontador
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
        private Vector3 playerPosition;
        private int gamePoints = 0;
        public GameObject[] targetPoints;

        private float verticalValue;
        private float horizontalValue;

        public float gameTime;
        private float targetTime;

        public Text timerText;
        public Image clock;
        public Sprite[] clockImages;

        private bool active = true;

        // Start is called before the first frame update
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            playerPosition = gameObject.transform.position;
            targetTime = gameTime;
        }

        void Update()
        {
            direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            verticalValue = Input.GetAxis("Vertical");
            horizontalValue = Input.GetAxis("Horizontal");

            if (active == true)
            {
                if (horizontalValue < 0)
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
                else if (horizontalValue > 0)
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (verticalValue < 0)
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
                }
                else if (verticalValue > 0)
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                }

                float minutes = targetTime / 60;
                float seconds = targetTime % 60;
                timerText.text = string.Format("{0}:{1}", Mathf.FloorToInt(minutes).ToString("D2"), Mathf.FloorToInt(seconds).ToString("D2"));

                float currentImage = gameTime / clockImages.Length;
                try
                {
                    clock.sprite = clockImages[Mathf.FloorToInt((targetTime / currentImage))];
                }
                catch (Exception)
                {

                }

                if (targetTime > 0)
                {
                    targetTime -= Time.deltaTime;
                }
                else
                {
                    resetGame();
                }
            }
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            rb2d.MovePosition(rb2d.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);
        }



        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == "end")
            {
                //velocidadMovimiento = 0;
                //buttonIntegrador.SetActive(true);
                //buttonIntegrador.SetActive(true);
            }
            else if (collision.gameObject.name.StartsWith("Nopal"))
            {
                //ActivarTask(collision.gameObject.name);
                gamePoints++;
                collision.gameObject.SetActive(false);
                if (gamePoints == targetPoints.Length)
                {
                    active = false;
                    velocidadMovimiento = 0;
                    buttonIntegrador.SetActive(true);
                    buttonIntegrador.SetActive(true);
                }
            }



        }
        private void resetGame()
        {
            targetTime = gameTime;
            gamePoints = 0;
            gameObject.transform.position = playerPosition;
            foreach (GameObject item in targetPoints)
            {
                item.SetActive(true);
            }
        }
        void ActivarTask(string input)
        {
            taskCollision = int.Parse(input);
            PanelActividades.transform.GetChild(taskCollision - 1).gameObject.SetActive(true);
            velocidadMovimiento = 0;
        }

    }

}

