using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace v1
{
    public class PointManager : MonoBehaviour
    {
        [SerializeField] int[] validContactPoints;
        [SerializeField] Material mt;
        [SerializeField] Material mtSelected;
        [SerializeField] int id;
        int selection = 0;

        private Vector3 mOffset;
        private float mZCoord;

        bool flag = true;
        GameObject line;
        BoxCollider bx;
        LineRenderer lr;
        List<GameObject> lines;
        int counter = 0;
        GameObject[] linesList;

        public Transform LinesContainer;

        void Start()
        {
            lines = new List<GameObject>();

            line = new GameObject(id.ToString() + counter.ToString());
            line.transform.SetParent(LinesContainer);
            lines.Add(line);
            lines[counter].tag = "line";
            lines[counter].transform.position = gameObject.transform.position;
            lines[counter].AddComponent<LineRenderer>();
            lines[counter].AddComponent<BoxCollider>();
            bx = lines[counter].GetComponent<BoxCollider>();
            
            lines[counter].AddComponent<Lines>();
            lr = lines[counter].GetComponent<LineRenderer>();
            lr.material = mt;

            lr.SetWidth(0.08f, 0.08f);
            lr.SetColors(new Color(1, 0, 0, 0), new Color(0, 0, 1, 0));
            lr.SetPosition(0, gameObject.transform.position);
            lr.SetPosition(1, gameObject.transform.position);

            GameManagerPuntosr.state = 1;
        }

        void Update()
        {

            if (Input.GetKeyUp("s"))
            {
                linesList = GameObject.FindGameObjectsWithTag("line");
                selection = (selection + 1)% linesList.Length;
                Debug.Log(selection + " " + linesList.Length);
                lines[selection].GetComponent<LineRenderer>().material = mtSelected;
            }
        }

        void OnMouseDrag()
        {
            var temp = lines[counter].GetComponent<LineRenderer>();
            temp.SetPosition(1, GetMouseAsWorldPoint() + mOffset);
            GameManagerPuntosr.one = id;
        }

        private Vector3 GetMouseAsWorldPoint()
        {
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = mZCoord;
            return Camera.main.ScreenToWorldPoint(mousePoint);
        }

        void OnMouseDown()
        {
            mZCoord = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        }

        void OnMouseOver()
        {
            GameManagerPuntosr.state = 2;
            GameManagerPuntosr.two = id;
        }

        void OnMouseExit()
        {
            GameManagerPuntosr.state = 1;
        }

        void OnMouseUp()
        {
            
            if (GameManagerPuntosr.state != 2)
            {
                GameManagerPuntosr.state = 0;
                lines[counter].GetComponent<LineRenderer>().SetPosition(1, gameObject.transform.position);
            }
            if (GameManagerPuntosr.state == 2)
            {
                lines[counter].GetComponent<Lines>().one = GameManagerPuntosr.one;
                lines[counter].GetComponent<Lines>().two = GameManagerPuntosr.two;

                counter++;

                line = new GameObject(id.ToString() + counter.ToString());
                line.transform.SetParent(LinesContainer);
                lines.Add(line);
                lines[counter].tag = "line";
                lines[counter].transform.position = gameObject.transform.position;
                lines[counter].AddComponent<LineRenderer>();
                lines[counter].AddComponent<BoxCollider>();
                bx = lines[counter].GetComponent<BoxCollider>();

                lines[counter].AddComponent<Lines>();
                lr = lines[counter].GetComponent<LineRenderer>();

                lr.material = mt;

                lr.SetColors(new Color(1, 0, 0, 1), new Color(0, 0, 1, 1));
                lr.SetWidth(0.08f, 0.08f);
                lr.SetPosition(0, gameObject.transform.position);
                lr.SetPosition(1, gameObject.transform.position);
                
                GameManagerPuntosr.state = 1;
                int[] temp = { GameManagerPuntosr.one, GameManagerPuntosr.two };
                GameManagerPuntosr.pairLines.Add(temp);
            }
        }
    }
}


