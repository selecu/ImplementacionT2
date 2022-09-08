using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Regletas
{
    public class DragHandlerRegletas : MonoBehaviour
    {
        private Vector3 mOffset;
        private float mZCoord;
        Rigidbody rb;
        public int id;

        bool flag = false;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void OnMouseDown()
        {
            mZCoord = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;

            // Store offset = gameobject world pos - mouse world pos

            mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
            flag = true;

        }

        void OnMouseUp()
        {
            flag = false;
            Re.state = 0;
            rb.velocity = Vector3.zero;
        }

        private Vector3 GetMouseAsWorldPoint()
        {
            // Pixel coordinates of mouse (x,y)

            Vector3 mousePoint = Input.mousePosition;

            // z coordinate of game object on screen

            mousePoint.z = mZCoord;

            // Convert it to world points

            return Camera.main.ScreenToWorldPoint(mousePoint);
        }

        void OnMouseDrag()
        {

            if (Input.GetKeyDown("delete") || Input.GetKeyDown("backspace"))
            {
                Destroy(gameObject);
            }
            //transform.position = GetMouseAsWorldPoint() + mOffset;
            //rb.MovePosition(GetMouseAsWorldPoint() + mOffset);
            rb.velocity = (GetMouseAsWorldPoint() - transform.position) * 10;

        }

        void Update()
        {
            if (Input.GetKey("left ctrl") && flag)
            {
                transform.position = GetMouseAsWorldPoint() + mOffset;
                transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
            }
            if (Input.GetKeyDown("r") && flag)
            {
                transform.Rotate(0,45f,0,0);
            }
            if (flag)
            {
                if (transform.position.y < -0.25)
                {
                    Re.state = 1;
                }
                else
                {
                    Re.state = 2;
                }
            }
        }
    }
}

