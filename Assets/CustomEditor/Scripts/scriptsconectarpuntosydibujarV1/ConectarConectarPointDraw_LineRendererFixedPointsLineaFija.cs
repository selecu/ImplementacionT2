using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace v1
{
    public class ConectarConectarPointDraw_LineRendererFixedPointsLineaFija : MonoBehaviour
    {
        // Start is called before the first frame update
        private LineRenderer lr;
        //private Transform[] points;
        private List<Transform> points = new List<Transform>();
        private void Awake()
        {
            lr = GetComponent<LineRenderer>();
        }


        public void SetUpLine(List<Transform> points)
        {
            lr.startWidth = 5f;
            lr.endWidth = 5f;
            lr.positionCount = points.Count;
            this.points = points;
        }

        private void Update()
        {
            for (int i = 0; i < points.Count; i++)
            {
                lr.SetPosition(i, points[i].position);
            }
        }

    }
} 


