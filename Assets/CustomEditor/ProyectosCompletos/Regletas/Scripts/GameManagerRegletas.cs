using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Regletas
{
    public class GameManagerRegletas : MonoBehaviour
    {

        public enum Tipo { UnicaRespuesta = 0, MultipleRespuesta = 1 }
        public Tipo tipoDeRespuesta;

        [SerializeField] TextAsset csv;
        string values;
        List<string> AnswersValue;

        [SerializeField] Image bottom;
        [SerializeField] Image top;

        public static int counter = 0;
        int EmptyCubes = 0;

        public static int state = 0;

        GameObject[] cubes;
        [SerializeField]
        GameObject check;
        bool ter;


        void Start()
        {
            check.SetActive(false);
            ter = false;
            cubes = new GameObject[256];

            for (int i = 0; i < 256; i++)
            {
                cubes[i] = GameObject.Find(i.ToString());
            }
            AnswersValue = new List<string>();

            if (tipoDeRespuesta == 0)
            {
                var l1 = csv.text.Replace('d', '\n');
                var l2 = l1.Split('\n');

                for (int i = 1; i < 32; i += 2)
                {
                    values += l2[i];
                }
                var l3 = values.Split(',');
                foreach (var c in l3)
                {
                    AnswersValue.Add(c);
                }
                for (int i = 1; i < 257; i++)
                {
                    if (int.Parse(AnswersValue[i]) != 0)
                    {
                        cubes[i-1].GetComponent<EvaluatePieceRegletas>().answers[0] = int.Parse(AnswersValue[i]);
                        if (int.Parse(AnswersValue[i]) != -1)
                        {
                            EmptyCubes++;
                        }
                    }
                }
            }
            if (tipoDeRespuesta != 0)
            {
                var l1 = csv.text.Replace('d', '\n');
                var l2 = l1.Split('\n');

                for (int i = 1; i < 32; i += 2)
                {
                    values += l2[i];
                }
                var l3 = values.Split(',');
                foreach (var c in l3)
                {
                    AnswersValue.Add(c);
                }
                for (int i = 1; i < 257; i++)
                {
                    try
                    {
                        if (int.Parse(AnswersValue[i]) != 0)
                        {
                            cubes[i - 1].GetComponent<EvaluatePieceRegletas>().answers[0] = int.Parse(AnswersValue[i]);
                            if (int.Parse(AnswersValue[i]) != -1)
                            {
                                EmptyCubes++;
                            }
                        }
                    } catch(Exception e)
                    {
                        //EmptyCubes++;
                        var temp = AnswersValue[i].Split(';');
                        foreach (var n in temp)
                        {
                            cubes[i - 1].GetComponent<EvaluatePieceRegletas>().answers.Add(int.Parse(n));
                            if (int.Parse(AnswersValue[i]) != -1)
                            {
                                EmptyCubes++;
                            }
                        }
                    }
                }
            }
            //Debug.Log(EmptyCubes);
        }

        void Update()
        {
            if (counter == EmptyCubes)
            {
                ter = true;
                Debug.Log("Done");
            }

            switch (state)
            {
                case 0:
                    top.color = Color.white;
                    bottom.color = Color.white;
                    break;
                case 1:
                    top.color = Color.white;
                    bottom.color = Color.green;
                    break;
                case 2:
                    top.color = Color.green;
                    bottom.color = Color.white;
                    break;
            }
            checkmanager();
        }


        public void checkmanager ()
        {
            if (ter)
            {
                check.SetActive(true);
            }
        }
    }
}

