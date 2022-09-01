using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



namespace v1
{
    public class CarMovement : MonoBehaviour
    {
        float currentSpeed = 2.5f;
        public int gasolinas;
        public GameObject checkButton;
        new Rigidbody2D rigidbody2D;
        


        IEnumerator Timer()
        {
            while (true)
            {
                ChangeSpeed(-0.5f);
                GasolinaController.instance.gasolinaSlider.value -= 5f;
                yield return new WaitForSeconds(5);
            }
        }
        public void ChangeSpeed(float amount)
        {
            currentSpeed = Mathf.Clamp(currentSpeed + amount, 0, 5);
            //Debug.Log("Speed" + currentSpeed + "/" + 5);
        }
        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            StartCoroutine(Timer());
            
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
                
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                transform.rotation = Quaternion.Euler(0, 0, -180);
                
            }
            if (currentSpeed == 0)
            {
                
            }
        }
        private void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector2 position = rigidbody2D.position;

            position.x = position.x + currentSpeed * horizontal * Time.deltaTime;
            position.y = position.y + currentSpeed * vertical * Time.deltaTime;
            rigidbody2D.MovePosition(position);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "gasolina")
            {
                gasolinas++;
                int num = int.Parse(collision.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text);
                int den = int.Parse(collision.gameObject.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text);

                GasolinaController.instance.GasolinaValue(num, den);

                if (currentSpeed < 5)
                {
                    ChangeSpeed(1);
                }

                Destroy(collision.gameObject);
            }
            if (collision.tag == "Casa")
            {
                if (gasolinas == 4)
                {

                    checkButton.SetActive(true);
                }

            }
        }
    }

}

