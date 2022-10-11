using AutoLetterbox;
using ContadorChecks;
using UnityEditor;
using UnityEngine;

namespace MyCustomTools
{
    public class CreateStaticGameObjects : MonoBehaviour
    {
#if UNITY_EDITOR
        [MenuItem("Selecu Tools/Create ForceCameraRatio &#r")]
        public static void CreateForceRatioCameraOnScene()
        {
            if (!GameObject.Find("ForceCameraRatio"))
            {
                GameObject forceCameraRatio = new GameObject("ForceCameraRatio", typeof(ForceCameraRatio));
            }
            else Debug.LogWarning("ForceCameraRatio is already on scene.");
        }

        [MenuItem("Selecu Tools/Create SoundManager &#s")]
        public static void CreateSoundManagerOnScene()
        {
            if (!GameObject.Find("SoundManager"))
            {
                const string pathPrefab = "Assets/CustomEditor/Recursos_Complementos/Audio/Resources_AudioManager/SoundManager.prefab";
                GameObject SoundManagerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(pathPrefab);
                Instantiate(SoundManagerPrefab).name = "SoundManager";
            }
            else Debug.LogWarning("SoundManager is already on scene.");
        }

        [MenuItem("Selecu Tools/Create ContadorGlobal &#c")]
        public static void CreateObjectOnScene()
        {
            if (!GameObject.Find("ContadorGlobal"))
            {
                GameObject go = new GameObject("ContadorGlobal", typeof(ContadorGlbal));
            }
            else Debug.LogWarning("ContadorGlobal is already on scene.");
        }

        [MenuItem("Selecu Tools/CreateAllSceneRequest &#q")]
        public static void CreateAllSceneRequest()
        {
            CreateForceRatioCameraOnScene();
            CreateSoundManagerOnScene();
            CreateObjectOnScene();
        }
#endif
    }
}
