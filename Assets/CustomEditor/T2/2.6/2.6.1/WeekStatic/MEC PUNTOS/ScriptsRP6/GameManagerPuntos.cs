using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


namespace v1.I26CruzRombo
{
    public class GameManagerPuntos : MonoBehaviour
    {
        [SerializeField]
        GameObject check;
        [SerializeField]
        GameObject checkintegrador;
        [SerializeField]
        GameObject mediacion;
        public static int state = 0;
        List<int[]> pairs;
        List<int[]> pairsAnswers;
        public static List<int[]> pairLines;
        public static int one;
        public static int two;
        bool complete = false;

        int counter = 0;
        int[] positions;

        //public GameObject[] pointsTemplates;
        //int activeTemplate = 0;
        bool flag = false;

        void Start()
        {


            mediacion.SetActive(false);
            checkintegrador.SetActive(false);

            positions = new int[100];
            pairs = new List<int[]>(7);
            pairsAnswers = new List<int[]>(7);
            pairLines = new List<int[]>(100);


            // Answers here ------------------------------------------
            //Derecha
            pairs.Add(new int[] { 1, 2 });
            pairs.Add(new int[] { 2, 3 });
            pairs.Add(new int[] { 3, 4 });
            pairs.Add(new int[] { 4, 5 });
            pairs.Add(new int[] { 5, 6 });
            pairs.Add(new int[] { 6, 7 });
            pairs.Add(new int[] { 7, 8 });
            pairs.Add(new int[] { 8, 9 });
            pairs.Add(new int[] { 9, 10 });
            pairs.Add(new int[] { 10, 11 });
            pairs.Add(new int[] { 11, 12 });
            pairs.Add(new int[] { 12, 1 });

            pairs.Add(new int[] { 13, 14 });
            pairs.Add(new int[] { 14, 15 });
            pairs.Add(new int[] { 15, 16 });
            pairs.Add(new int[] { 16, 13 });

            //Izquierda
            pairs.Add(new int[] { 17, 18 });
            pairs.Add(new int[] { 18, 19 });
            pairs.Add(new int[] { 19, 20 });
            pairs.Add(new int[] { 20, 21 });
            pairs.Add(new int[] { 21, 22 });
            pairs.Add(new int[] { 22, 23 });
            pairs.Add(new int[] { 23, 24 });
            pairs.Add(new int[] { 24, 25 });
            pairs.Add(new int[] { 25, 26 });
            pairs.Add(new int[] { 26, 27 });
            pairs.Add(new int[] { 27, 28 });
            pairs.Add(new int[] { 28, 17 });

            pairs.Add(new int[] { 29, 30 });
            pairs.Add(new int[] { 30, 31 });
            pairs.Add(new int[] { 31, 32 });
            pairs.Add(new int[] { 32, 29 });

            /*para agregar nuevos puntos se hace 
             * desde aqu? sin repetir las secuencias ya utilizadas
             * ejem : pairs.Add(new int[] { 15, 16 });
             *        pairs.Add(new int[] { 16, 17 });
                      pairs.Add(new int[] { 17, 18 });
             * Recordar renombrar los objetos y los ids
             * y asi se crean nuevas figuras 
             * si se modifica el codigo poner un nuevo
             * namespace para no alterar el resto de interacciones*/
            //---------------------------------------------------------

            for (int i = 0; i < pairs.Count; i++)
            {
                pairsAnswers.Add(new int[] { pairs[i][0], pairs[i][1] });
            }

            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = 0;
            }

            //pointsTemplates[activeTemplate].SetActive(true);
        }

        void Update()
        {
            if (counter == pairs.Count && flag)
            {
                flag = false;
                counter = 0;
                pairLines = new List<int[]>(100);
                GameObject[] emptyLines = GameObject.FindGameObjectsWithTag("line");

                foreach (GameObject g in emptyLines)
                {
                    Destroy(g);
                }

                complete = true;
                mediacion.SetActive(false);
                check.SetActive(false);
                checkintegrador.SetActive(true);
                Debug.Log("Correcto");

                //pointsTemplates[activeTemplate].SetActive(false);
                //activeTemplate++;
                //pointsTemplates[activeTemplate].SetActive(true);

                for (int i = 0; i < pairs.Count; i++)
                {
                    var temp = pairsAnswers[i];
                    pairs[i] = temp;
                }

                for (int i = 0; i < positions.Length; i++)
                {
                    positions[i] = 0;
                }

            }
            else
            {
                flag = false;
            }
            for (int t = 0; t < pairLines.Count; t++)
            {
                for (int p = 0; p < pairs.Count; p++)
                {
                    if (pairLines[t][0] == pairs[p][0] && pairLines[t][1] == pairs[p][1] || pairLines[t][0] == pairs[p][1] && pairLines[t][1] == pairs[p][0])
                    {
                        pairs[p][0] = -1;
                        pairs[p][1] = -1;
                        positions[t] = -1;
                        counter++;
                    }
                }
            }
        }

        void FindAndClean(int t1, int t2)
        {
            GameObject[] emptyLines = GameObject.FindGameObjectsWithTag("line");

            for (int i = 0; i < emptyLines.Length; i++)
            {
                var line = emptyLines[i].GetComponent<v1.Lines>();

                if (line.one != 0 && line.two != 0)
                {
                    if (line.one == t1 && line.two == t2)
                    {
                        Destroy(emptyLines[i]);
                    }
                }
            }
        }

        public void Check()
        {
            StartCoroutine(Wait());
        }

        IEnumerator Wait()
        {
            flag = true;

            if (!complete)
            {
                mediacion.SetActive(true);

                yield return new WaitForSeconds(6);

                for (int i = 0; i < positions.Length; i++)
                {
                    if (positions[i] != -1)
                    {
                        try
                        {
                            FindAndClean(pairLines[i][0], pairLines[i][1]);
                        }
                        catch (Exception e)
                        {
                            //Revisar la expecion que arroja. En este caso, ver si el valor al que accede es un valor null y redireccionar el elemento.
                            // Debug.LogWarning($"Exception catched: {e}");
                        }
                    }
                }
            }
        }
    }
}

