using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Regletas
{
    public class Rev2 : MonoBehaviour
    {
        public enum Tipo { UnicaRespuesta = 0, MultipleRespuesta = 1 }
        public Tipo tipoDeRespuesta;

        [SerializeField] TextAsset csv;
        string values;
        List<string> AnswersValue;

        [SerializeField] Image bottom;
        [SerializeField] Image top;

        public static int counter = 0;

        [SerializeField]int EmptyCubes = 0;

        public static int state = 0;

        [SerializeField] GameObject[] cubes;
        [SerializeField]
        GameObject check;
        bool ter;

        void Start()
        {
            check.SetActive(false);
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
                        cubes[i - 1].GetComponent<EvaluatePieceRegletas>().answers[0] = int.Parse(AnswersValue[i]);
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
                    //Debug.Log("entro en el try bb " + int.Parse("5n"));
                    try
                    {                        
                        if (int.Parse(AnswersValue[i]) != 0)
                        {
                            
                            //cubes[i - 1].GetComponent<EvaluatePieceRegletas>().answers[0] = int.Parse(AnswersValue[i]);
                            cubes[i - 1].GetComponent<EvaluatePieceRegletas>().answers.Add(int.Parse(AnswersValue[i]));
                            if (int.Parse(AnswersValue[i]) != -1)
                            {
                                EmptyCubes++;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        
                        if (AnswersValue[i].Contains(";"))
                        {                            
                            var temp = AnswersValue[i].Split(';');
                            Debug.Log("paso el punto y coma " + temp.Length);
                            if (temp.Length > 1)
                            {
                                EmptyCubes++;
                            }
                            if (temp.Length == 1 && int.Parse(temp[0]) != -1)
                            {
                                EmptyCubes++;
                            }
                            foreach (var n in temp)
                            {
                                cubes[i - 1].GetComponent<EvaluatePieceRegletas>().answers.Add(int.Parse(n));
                            }
                        }
                        else if (AnswersValue[i].Contains("m"))
                        {
                            int tempInt = int.Parse(AnswersValue[i][0].ToString());                            
                            Debug.Log("aca ocurre la magia");
                            //cubes[i - 1].GetComponent<EvaluatePieceRegletasV2>().ChangeColorStatic(tempInt);
                            //cubes[i - 1].GetComponent<Renderer>().material.color = Color.cyan;
                            cubes[i - 1].GetComponent<EvaluatePieceRegletas>().ChangeColorStatic(tempInt-1);
                        }
                       
                        
                        //cubes[i - 1].GetComponent<Renderer>().material.color = Color.cyan;
                    }
                }
            }

        }

        void Update()
        {
            Debug.Log("hechos " + counter);
            if (counter == EmptyCubes)
            {
                
                ter = true;
                Debug.Log("Done");
                checkmanager();
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

        }

        public void checkmanager()
        {
            if (ter == true)
            {
                check.SetActive(true);
            }
        }
    }
}
