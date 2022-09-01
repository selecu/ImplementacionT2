using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class ObjetBaseSpawner : EditorWindow
{

    string ObjectBaseName = "";
    GameObject objectToSpawn;
    Vector2 scrollPosition;
    SceneAsset scneToSpawn;
    





   [MenuItem("Tools/Template")]
   public static void ShowWWindow()
    {
        GetWindow(typeof(ObjetBaseSpawner));
    }


    private void OnGUI()
    {
        GUILayout.Label("Spawn new Object", EditorStyles.boldLabel);
        
        EditorGUILayout.Space(5);
        ObjectBaseName = EditorGUILayout.TextField("Base Name", ObjectBaseName);

        EditorGUILayout.Space(5);
        objectToSpawn = EditorGUILayout.ObjectField("Prefab to Spawn", objectToSpawn, typeof(GameObject),false) as GameObject;

        GetAllPrefabs();

        EditorGUILayout.Space(5);
        if (GUILayout.Button("Spawn Object"))
        {

            SpawnObject();


        }


        EditorGUILayout.Space(10);
        GUILayout.Label("Scenes In Proyect " );
        EditorGUILayout.Space(5);
        if (GUILayout.Button("Regletas Spawn "))
        {
            
            string sceneubi = "Assets/CustomEditor/ProyectosCompletos/Regletas/Scenes/Regletas.unity";
            AssetDatabase.CopyAsset(sceneubi, $"Assets/Scenes/Nuevo.unity");
        }

        if (GUILayout.Button("MEC Puntos Spawn "))
        {

            string sceneubi = "Assets/CustomEditor/ProyectosCompletos/MECPuntos/MEC Puntos.unity";
            AssetDatabase.CopyAsset(sceneubi, $"Assets/Scenes/Nuevo.unity");
        }


        if (GUILayout.Button("Pacman Spawn "))
        {

            string sceneubi = "Assets/CustomEditor/ProyectosCompletos/Pacman/Scenes/Pacman.unity";
            AssetDatabase.CopyAsset(sceneubi, $"Assets/Scenes/Nuevo.unity");
        }
        if (GUILayout.Button("Flow Mania "))
        {

            string sceneubi = "Assets/CustomEditor/ProyectosCompletos/FlowMania/Scenes/FlowMania.unity";
            AssetDatabase.CopyAsset(sceneubi, $"Assets/Scenes/Nuevo.unity");
        }

        if (GUILayout.Button("Laberinto con ventana emergente "))
        {

            string sceneubi = "Assets/CustomEditor/ProyectosCompletos/Laberinto/Scenes/Laberinto.unity";
            AssetDatabase.CopyAsset(sceneubi, $"Assets/Scenes/Nuevo.unity");
        }


        EditorGUILayout.Space(10);
        GUILayout.Label( "Templates In Proyect ");
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(300), GUILayout.Height(650));
        foreach (var item in allPrefabs)
        {
            //Debug.Log(item.name);
            EditorGUILayout.Space(1);
            if (GUILayout.Button(item.name))
            {
                
                SpawnObject(item);
                
                
            }
        }
        GUILayout.EndScrollView();



    }




    private void SpawnObject()
    {
        if(objectToSpawn == null)
        {
            Debug.LogError("Error: Please asisin an object to spawned.");
            return;
        }

        if (ObjectBaseName == string.Empty)
        {
            Debug.LogError("Error: Please enter a base name for the object.");
            return;
        }

        GameObject newObject = Instantiate(objectToSpawn);
        newObject.name = ObjectBaseName;
        newObject.transform.localScale = Vector3.zero;
    }

    private void SpawnObject(GameObject prefabChoose)
    {
        if (prefabChoose == null)
        {
            Debug.LogError("Error: Please asisin an object to spawned.");
            return;
        }

        if (ObjectBaseName == string.Empty)
        {
            Debug.LogError("Error: Please enter a base name for the object.");
            return;
        }

        GameObject newObject = Instantiate(prefabChoose);
        newObject.name = ObjectBaseName;
        newObject.transform.localScale = Vector3.zero;
    }

   
    List<GameObject> allPrefabs;

    private void GetAllPrefabs()
    {
        string[] foldersToSearch = { "Assets/CustomEditor/Prefabs" };
        /*List<GameObject>*/ allPrefabs = GetAssets<GameObject>(foldersToSearch, "t:prefab");
    }

    public static List<T> GetAssets<T>(string[] _foldersToSearch, string _filter) where T : UnityEngine.Object
    {
        string[] guids = AssetDatabase.FindAssets(_filter, _foldersToSearch);
        List<T> a = new List<T>();
        for (int i = 0; i < guids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            a.Add(AssetDatabase.LoadAssetAtPath<T>(path));
            
        }
        return a;
    }

}
