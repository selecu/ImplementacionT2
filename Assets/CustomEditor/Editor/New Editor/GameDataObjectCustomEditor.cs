using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

[CustomEditor(typeof(GameDataObject))]
public class GameDataObjectCustomEditor : Editor
{
    [OnOpenAsset()]
    public static bool OpenEditor(int instanceId, int line)
    {
        GameDataObject obj = EditorUtility.InstanceIDToObject(instanceId) as GameDataObject;
        if (obj != null)
        {
            GameDataObjectEditorWindow.Open(obj);
            return true;
        }
        return false;
    }
    /*
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        if (GUILayout.Button("No muesta lo del scriptable y abre editorWindow"))
        {
            GameDataObjectEditorWindow.Open((GameDataObject)target);
            Debug.Log("No muesta lo del scriptable y abre editorWindow");
        }
    }*/
    [MenuItem("Selecu/Templates #s")]
    public static void OpenWindowSelecu()
    {
        var p = AssetDatabase.FindAssets("game data t:scriptableObject");

        var x = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(p[0]), typeof(GameDataObject));
        Debug.Log(x);

        GameDataObjectEditorWindow.Open((GameDataObject)x);
    }
}