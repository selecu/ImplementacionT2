using AutoLetterbox;
using UnityEditor;
using UnityEngine;

public class CreateStaticGameObjects : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("Selecu Tools/Create ForceCameraRatio &#r")]
    public static void CreateForceRatioCameraOnScene()
    {
        GameObject forceCameraRatio = new GameObject("ForceCameraRatio", typeof(ForceCameraRatio));
    }
#endif
}
