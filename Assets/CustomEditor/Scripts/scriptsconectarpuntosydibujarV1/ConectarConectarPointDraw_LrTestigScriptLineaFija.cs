using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace v1
{
    public class ConectarConectarPointDraw_LrTestigScriptLineaFija : MonoBehaviour
    {
        //[SerializeField] private Transform[] points;
        //public static ConectarConectarPointDraw_LrTestigScript instance;
        [SerializeField] private List<Transform> points = new List<Transform>();
        [SerializeField] private ConectarConectarPointDraw_LineRendererFixedPointsLineaFija line;


        // Start is called before the first frame update
        private void Awake()
        {
            //instance = this;
        }

        public void NewPoint(Transform Point)
        {
            points.Add(Point);
            line.SetUpLine(points);
        }

        void Update()
        {
            line.SetUpLine(points);
        }


    }

}

