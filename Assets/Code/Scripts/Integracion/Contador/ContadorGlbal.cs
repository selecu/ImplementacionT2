using AutoLetterbox;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace ContadorChecks
{
    public class ContadorGlbal : MonoBehaviour
    {
        [SerializeField] Contadorcheck[] contadorGlobal;

        public Contadorcheck[] GetContadorGlobal { get { return contadorGlobal; } }

        public int ObtenerContadorCheckGlobal()
        {
            int total = 0;
            if (contadorGlobal == null || contadorGlobal.Length == 0)
            {
                total = 1;
                return total;
            }
            if (contadorGlobal.Length >= 1)
            {
                for (int i = 0; i < contadorGlobal.Length; i++)
                {
                    total += contadorGlobal[i].check_count;
                }
                return total;
            }
            else
            {
                int tl = 0;
                tl = contadorGlobal[0].check_count;
                return tl;
            }
        }


        public void FindAllContadorChecks()
        {
            var target = FindObjectsOfType<Contadorcheck>();
            contadorGlobal = new Contadorcheck[target.Length];
            Array.Clear(contadorGlobal, 0, contadorGlobal.Length);
            contadorGlobal = target;
        }

#if UNITY_EDITOR
        [MenuItem("Selecu Tools/Create ContadorGlobal &#c")]
        public static void CreateObjectOnScene()
        {
            GameObject go = new GameObject("ContadorGlobal", typeof(ContadorGlbal));
        }
#endif
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(ContadorGlbal))]
    public class GUILayoutEditorConfig : Editor
    {
        public override void OnInspectorGUI()
        {
            ContadorGlbal targetCheck = (ContadorGlbal)target;
            base.OnInspectorGUI();

            // If the user hovers the mouse over the button, the global tooltip gets set
            GUI.Label(new Rect(100, 40, 100, 40), GUI.tooltip);

            if (GUILayout.Button(new GUIContent("Find All Objects", $"The button will search all activated objects on scene and assign them to variable 'Contador Global'.\n\n" +
                $"\ttypeof({targetCheck.GetContadorGlobal}).")))
            {
                targetCheck.FindAllContadorChecks();
            }
        }
    }
#endif
}
