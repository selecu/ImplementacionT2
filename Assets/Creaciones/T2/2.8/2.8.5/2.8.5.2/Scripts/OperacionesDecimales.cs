using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

namespace I2852
{
    public class OperacionesDecimales : MonoBehaviour
    {
        public enum operaciones
        {
            none,
            Suma, SumaDecimal,
            Resta, RestaDecimal,
            Multiplicacion,
            DivisionResultadoEnteros,
            DivisionReultadoDecimal,
        }
        public operaciones State;

        [SerializeField] float RangoSumandosMin;
        [SerializeField] float RangoSumandosMax;

        string simbolo;

        public List<v1.DragHandlerDragandDropOP> preguntas;
        public List<v1.DropSlotDragandDropOP> respuestas;

        private void Awake()
        {
            StartCoroutine(GetObjects());
        }


        void Start()
        {

            if (State == operaciones.Suma || State == operaciones.SumaDecimal)
                simbolo = "+";
            if (State == operaciones.Resta || State == operaciones.RestaDecimal)
                simbolo = "-";
            if (State == operaciones.Multiplicacion)
                simbolo = "x";
            if (State == operaciones.DivisionResultadoEnteros || State == operaciones.DivisionReultadoDecimal)
                simbolo = "÷";
        }


        private void PutSuma()
        {

            for (int i = 0; i < preguntas.Count; i++)
            {
                for (int e = 0; e < respuestas.Count; e++)
                {
                    if (preguntas[i].id != respuestas[e].id) continue;

                    double sumando1 = Random.Range(RangoSumandosMin, RangoSumandosMax);
                    double sumando2 = Random.Range(RangoSumandosMin, RangoSumandosMax);

                    sumando1 = System.Math.Round(sumando1);
                    sumando2 = System.Math.Round(sumando2);

                    double respuestaID = sumando1 + sumando2;

                    preguntas[i].GetComponentInChildren<Text>().text = respuestaID.ToString();
                    respuestas[e].GetComponentInChildren<Text>().text = (sumando1.ToString() + " " + simbolo + " " + sumando2.ToString());
                }
            }
        }
        private void PutSumaDecimal()
        {

            for (int i = 0; i < preguntas.Count; i++)
            {
                for (int e = 0; e < respuestas.Count; e++)
                {
                    if (preguntas[i].id != respuestas[e].id) 
                        continue;

                    double sumando1 = Random.Range(RangoSumandosMin, RangoSumandosMax);
                    double sumando2 = Random.Range(RangoSumandosMin, RangoSumandosMax);

                    sumando1 = System.Math.Round(sumando1, 2);
                    sumando2 = System.Math.Round(sumando2, 2);

                    double respuestaID = sumando1 + sumando2;

                    preguntas[i].GetComponentInChildren<Text>().text = respuestaID.ToString();
                    respuestas[e].GetComponentInChildren<Text>().text = (sumando1.ToString() + " " + simbolo + " " + sumando2.ToString());
                }
            }
        }

        private void PutResta()
        {

            for (int i = 0; i < preguntas.Count; i++)
            {
                for (int e = 0; e < respuestas.Count; e++)
                {
                    if (preguntas[i].id != respuestas[e].id) 
                        continue;

                    double sumando1 = Random.Range(RangoSumandosMin, RangoSumandosMax);
                    double sumando2 = Random.Range(RangoSumandosMin, RangoSumandosMax);

                    sumando1 = System.Math.Round(sumando1);
                    sumando2 = System.Math.Round(sumando2);

                    double respuestaID = sumando1 - sumando2;
                    
                    preguntas[i].GetComponentInChildren<Text>().text = respuestaID.ToString();
                    respuestas[e].GetComponentInChildren<Text>().text = (sumando1.ToString() + " " + simbolo + " " + sumando2.ToString());
                }
            }
        }

        private void PutRestaDecimal()
        {

            for (int i = 0; i < preguntas.Count; i++)
            {
                for (int e = 0; e < respuestas.Count; e++)
                {
                    if (preguntas[i].id == respuestas[e].id)
                    {
                        double sumando1 = Random.Range(RangoSumandosMin, RangoSumandosMax);
                        double sumando2 = Random.Range(RangoSumandosMin, RangoSumandosMax);

                        sumando1 = System.Math.Round(sumando1, 2);
                        sumando2 = System.Math.Round(sumando2, 2);

                        double respuestaID = sumando1 - sumando2;

                        preguntas[i].GetComponentInChildren<Text>().text = respuestaID.ToString();
                        respuestas[e].GetComponentInChildren<Text>().text = (sumando1.ToString() + " " + simbolo + " " + sumando2.ToString());

                    }
                }
            }
        }

        private void PutMultiplicacion()
        {

            for (int i = 0; i < preguntas.Count; i++)
            {
                for (int e = 0; e < respuestas.Count; e++)
                {
                    if (preguntas[i].id != respuestas[e].id)
                        continue;

                    double sumando1 = Random.Range(RangoSumandosMin, RangoSumandosMax);
                    double sumando2 = Random.Range(RangoSumandosMin, RangoSumandosMax);
                    
                    sumando1 = System.Math.Round(sumando1);
                    sumando2 = System.Math.Round(sumando2);
                    
                    double respuestaID = sumando1 * sumando2;

                    preguntas[i].GetComponentInChildren<Text>().text = respuestaID.ToString();
                    respuestas[e].GetComponentInChildren<Text>().text = (sumando1.ToString() + " " + simbolo + " " + sumando2.ToString());
                }
            }
        }

        private void PutDivision()
        {

            for (int i = 0; i < preguntas.Count; i++)
            {
                for (int e = 0; e < respuestas.Count; e++)
                {
                    if (preguntas[i].id != respuestas[e].id)
                        continue;
                    
                    double sumando1 = Random.Range(RangoSumandosMin, RangoSumandosMax);
                    double sumando2 = Random.Range(RangoSumandosMin, RangoSumandosMax);

                    sumando1 = System.Math.Round(sumando1);
                    sumando2 = System.Math.Round(sumando2);

                    double respuestaID = sumando1 / sumando2;

                    preguntas[i].GetComponentInChildren<Text>().text = respuestaID.ToString("F0");
                    respuestas[e].GetComponentInChildren<Text>().text = (sumando1.ToString() + " " + simbolo + " " + sumando2.ToString());
                }
            }
        }
        private void PutDivisionDecimal()
        {

            for (int i = 0; i < preguntas.Count; i++)
            {
                for (int e = 0; e < respuestas.Count; e++)
                {
                    if (preguntas[i].id != respuestas[e].id)
                        continue;

                    double sumando1 = Random.Range(RangoSumandosMin, RangoSumandosMax);
                    double sumando2 = Random.Range(RangoSumandosMin, RangoSumandosMax);
                    
                    sumando1 = System.Math.Round(sumando1);
                    sumando2 = System.Math.Round(sumando2);
                    
                    double respuestaID = sumando1 / sumando2;
                    
                    preguntas[i].GetComponentInChildren<Text>().text = respuestaID.ToString("F");
                    respuestas[e].GetComponentInChildren<Text>().text = (sumando1.ToString() + " " + simbolo + " " + sumando2.ToString());
                }
            }
        }

        IEnumerator GetObjects()
        {
            yield return new WaitForSeconds(0.3f);
            preguntas = FindObjectsOfType<v1.DragHandlerDragandDropOP>().ToList<v1.DragHandlerDragandDropOP>();
            respuestas = FindObjectsOfType<v1.DropSlotDragandDropOP>().ToList<v1.DropSlotDragandDropOP>();

            if (State == operaciones.Suma)
                PutSuma();
            else if (State == operaciones.SumaDecimal)
                PutSumaDecimal();
            else if (State == operaciones.Resta)
                PutResta();
            else if (State == operaciones.RestaDecimal)
                PutRestaDecimal();
            else if (State == operaciones.Multiplicacion)
                PutMultiplicacion();
            else if (State == operaciones.DivisionResultadoEnteros)
                PutDivision();
            else if (State == operaciones.DivisionReultadoDecimal)
                PutDivisionDecimal();
        }
    }
}
