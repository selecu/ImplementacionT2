using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class ExtendedEditorWindow : EditorWindow 
{
    protected SerializedObject serializedObject;
    protected SerializedProperty currentProperty;

    private string selectedPropertyPath;
    protected SerializedProperty selectedProperty;
    GameObject prefabTemplate;
    private Rect rect;
    private string interaccion;
    Vector2 scrollPosition;
    


    protected void DrawProperties(SerializedProperty prop, bool drawChildren)
    {
        GUIStyle style = new GUIStyle();
        style.richText = true;
        EditorGUILayout.BeginVertical("Box");
        string lastPropPath = string.Empty;
        foreach (SerializedProperty p in prop)
        {
             //Original foreach 
            if (p.isArray && p.propertyType == SerializedPropertyType.Generic)
            {
                
                EditorGUILayout.BeginHorizontal();
                p.isExpanded = EditorGUILayout.Foldout(p.isExpanded, p.displayName);
                EditorGUILayout.EndHorizontal();
                

                if (p.isExpanded)
                {
                    EditorGUI.indentLevel++;
                    DrawProperties(p, drawChildren);
                    EditorGUI.indentLevel--;
                   
                }
                GUILayout.Label("algo debe de aparecer");
            }
            
            else
            {
                if(!string.IsNullOrEmpty(lastPropPath) && p.propertyPath.Contains(lastPropPath)) { continue; }
                lastPropPath = p.propertyPath;
                //EditorGUILayout.PropertyField(p, drawChildren);

                

                if (p.displayName == "Name")
                {
                    //EditorGUILayout.LabelField(p.stringValue);
                    EditorGUILayout.BeginVertical("Box");
                    EditorGUILayout.LabelField("<size=30> <color=gray>" + p.stringValue + "</color></size>",style);
                    EditorGUILayout.EndVertical();
                    GUILayout.Space(20);
                }
                else if (p.displayName == "Img Ref")
                {
                    rect = EditorGUILayout.GetControlRect();
                    rect = new Rect(rect.x, rect.y, 256, 144);
                    var textu = (Texture2D)p.objectReferenceValue;
                    EditorGUI.DrawPreviewTexture(rect, textu);
                    GUILayout.Space(100);
                }
                else if (p.displayName == "Description")
                {
                    //EditorGUILayout.LabelField(p.stringValue);
                    EditorGUILayout.HelpBox(p.stringValue,MessageType.Info);
                    GUILayout.Space(10);
                }
                else if (p.displayName == "Prefab")
                {
                    GUILayout.Space(30);
                    prefabTemplate = (GameObject)p.objectReferenceValue;
                                   
                }
               

                //Debug.Log("<color=lime> tipo: " + p.displayName + "</color>");
                
               
                //EditorGUILayout.LabelField(p.stringValue); funciono, jejejeje


            }

            // Final del original

            // aca ininia mi burrada.


            
        }

        interaccion = EditorGUILayout.TextField("Interacción", interaccion);
        if (GUILayout.Button("Crear"))
        {
            GUILayout.Space(10);
            CreateFolderScene(interaccion);
            Instantiate(prefabTemplate);
            /*UnityEditor.SceneManagement.EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            Instantiate(prefabTemplate);
            EditorApplication.SaveScene();*/
        }
        EditorGUILayout.EndVertical();
    }

    protected void DrawSidebar(SerializedProperty prop)
    {
        GUILayout.Space(10);
        foreach (SerializedProperty item in prop)
        {
            if (GUILayout.Button(item.displayName))
            {
                selectedPropertyPath = item.propertyPath;
                
            }
        }
        if (!string.IsNullOrEmpty(selectedPropertyPath))
        {
            selectedProperty = serializedObject.FindProperty(selectedPropertyPath);            
        }
    }

    public void CreateFolderScene(string nameInteraction)
    {
        string ruta = AssetDatabase.CreateFolder("Assets", nameInteraction);
        string guid = AssetDatabase.CreateFolder("Assets/" + nameInteraction, "Images");

        string rutaScene = AssetDatabase.GUIDToAssetPath(ruta);


        string rutaScenaNombre = rutaScene + ("/" + nameInteraction + ".unity");

        var scenaUna = UnityEditor.SceneManagement.EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects);

        bool saveOK = EditorSceneManager.SaveScene(scenaUna, rutaScenaNombre);

    }

}
