using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameDataObjectEditorWindow : ExtendedEditorWindow
{
    
    public static void Open(GameDataObject dataObject)
    {
        GameDataObjectEditorWindow window = GetWindow<GameDataObjectEditorWindow>();
        window.serializedObject = new SerializedObject(dataObject);
    }

    private void OnGUI()
    {
        currentProperty = serializedObject.FindProperty("gameData");
        //DrawProperties(currentProperty, true);

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));

        DrawSidebar(currentProperty);

        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));
        if (selectedProperty !=null)
        {
            DrawProperties(selectedProperty, true);
        }
        else
        {
            EditorGUILayout.LabelField("selecciona un item de la lista");
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
    }
}
