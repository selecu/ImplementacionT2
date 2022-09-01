using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace v1
{
    public class ConectarConectarPointDraw_LrTestigScript : MonoBehaviour
    {
        //[SerializeField] private Transform[] points;
        public static ConectarConectarPointDraw_LrTestigScript instance;
        [SerializeField] private List<Transform> points = new List<Transform>();
        [SerializeField] private ConectarConectarPointDraw_LineRendererFixedPoints line;


        // Start is called before the first frame update
        private void Awake()
        {
            instance = this;
        }

        public void NewPoint(Transform Point)
        {
            points.Add(Point);
            line.SetUpLine(points);
        }

        public void DeletePoint()
        {
            int index = points.Count;
            points.RemoveAt(index - 1);
            line.SetUpLine(points);
            QuestionGenerator_PointDraw.instance.RemoveQuestion();
        }



        void Update()
        {
            line.SetUpLine(points);
        }


    }
}


