using AutoLetterbox;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

namespace MyCustomTools
{
    public class CreateStaticGameObjects : MonoBehaviour
    {
        public const string fullPathCheckButton = "Assets/Creaciones/EdadDeLosPueblos/Prefabs/Static/BuiltButton/Check.prefab";
        public const string fullPathIntegrateButton = "Assets/Creaciones/EdadDeLosPueblos/Prefabs/Static/BuiltButton/Integrate.prefab";
        public const string fullPathSoundManager = "Assets/CustomEditor/Recursos_Complementos/Audio/Resources_AudioManager/SoundManager.prefab";

        public static Vector2 canvasResolution = new Vector2(1920, 1080);

        public const float alphaReference = 0.3f;

#if UNITY_EDITOR


        [MenuItem("Selecu Tools/Create ContadorGlobal &#c")]
        public static void CreateContadorGlobal()
        {
            if (GameObject.Find("ContadorGlobal") || !FindObjectOfType<Contadorcheck>())
            {
                Debug.LogWarning("ContadorGlobal is already on scene or component 'Contadorcheck' doesn't exist.");
                return;
            }

            GameObject go = new GameObject("ContadorGlobal", typeof(ContadorGlbal));

            go.GetComponent<ContadorGlbal>().FindAllContadorChecks();
        }

        [MenuItem("Selecu Tools/Create All Scene Request Components &#q")]
        public static void CreateAllSceneRequest()
        {
            CreateForceRatioCameraOnScene();
            CreateContadorGlobal();
            CreateSoundManagerOnScene();
            CreateEventSystem();
            

            CreateCanvas();
            CreateBackground();
            CreateCheckButton();
            CreateExample();
        }

        #region Tools Without Keyboard Shortcut

        // -------------------------------------- HEIRARCHY -------------------------------------- //

        [MenuItem("Selecu Tools/Create ForceCameraRatio")]
        public static void CreateForceRatioCameraOnScene()
        {
            if (!GameObject.Find("ForceCameraRatio"))
            {
                GameObject forceCameraRatio = new GameObject("ForceCameraRatio", typeof(ForceCameraRatio));
            }
            else Debug.LogWarning("ForceCameraRatio is already on scene.");
        }

        [MenuItem("Selecu Tools/Create SoundManager")]
        public static void CreateSoundManagerOnScene()
        {
            if (GameObject.Find("SoundManager"))
            {
                Debug.LogWarning("SoundManager is already on scene.");
                return;
            }

            GameObject soundManagerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(fullPathSoundManager);

            GameObject _soundManagerPrefabInstance = PrefabUtility.InstantiatePrefab(soundManagerPrefab, null) as GameObject;
        }

        [MenuItem("Selecu Tools/Create EventSystem")]
        public static void CreateEventSystem()
        {
            if (FindObjectOfType<EventSystem>())
            {
                Debug.LogWarning("EventSystem already on scene.");
                return;
            }

            GameObject go = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }

        // ----------------------------------------------------------------------------------- //

        // -------------------------------------- CANVAS -------------------------------------- //

        public static void SetAnchours(RectTransform rectTrans)
        {
            rectTrans.anchorMin = Vector3.zero;
            rectTrans.anchorMax = Vector3.one;

            rectTrans.SetWidth(canvasResolution.x);
            rectTrans.SetHeight(canvasResolution.y);

            rectTrans.SetPosition(Vector2.zero);
        }

        [MenuItem("Selecu Tools/Create Canvas")]
        public static void CreateCanvas()
        {
            var target = FindObjectOfType<Canvas>();

            if (target)
            {
                if (target.GetComponent<CanvasScaler>().referenceResolution != canvasResolution)
                    SetCanvasResolution(target.gameObject);
            
                Debug.LogWarning("Canvas is already created and set canvas resolution.");
                return;
            }

            GameObject go = new GameObject("Canvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));

            SetCanvasResolution(go);
        }

        public static void SetCanvasResolution(GameObject canvasObject)
        {
            canvasObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObject.GetComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

            canvasObject.GetComponent<CanvasScaler>().referenceResolution = canvasResolution;
        }

        [MenuItem("Selecu Tools/Create Background")]
        public static GameObject CreateBackground()
        {
            if (GameObject.Find("Background"))
            {
                Debug.LogWarning("Background is already created.");
                return null;
            }

            var target = FindObjectOfType<Canvas>().gameObject;

            if (!target)
            {
                Debug.LogWarning("Background can't spawn on scene. Verify if on hierarchy find object of type Canvas.");
                return null;
            }

            GameObject go = new GameObject("Background", typeof(RectTransform), typeof(Image));

            go.transform.SetParent(target.transform);


            SetAnchours(go.GetComponent<RectTransform>());

            return go;
        }

        [MenuItem("Selecu Tools/Create Reference")]
        public static void CreateExample()
        {
            if (GameObject.Find("Reference"))
            {
                Debug.LogWarning("Reference is already created.");
                return;
            }

            var target = FindObjectOfType<Canvas>().gameObject;

            if (!target)
            {
                Debug.LogWarning("Reference can't spawn on scene. Verify if on hierarchy find object of type Canvas.");
                return;
            }

            GameObject go = new GameObject("Reference", typeof(RectTransform), typeof(Image));

            go.transform.SetParent(target.transform);

            RectTransform rectTrans = go.GetComponent<RectTransform>();

            rectTrans.anchorMin = Vector3.zero;
            rectTrans.anchorMax = Vector3.one;

            rectTrans.SetWidth(canvasResolution.x);
            rectTrans.SetHeight(canvasResolution.y);

            rectTrans.SetPosition(Vector2.zero);

            Image image = go.GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = alphaReference;
            image.color = tempColor;

            image.raycastTarget = false;
        }

        [MenuItem("Selecu Tools/Create Check Button")]
        public static void CreateCheckButton()
        {
            if (GameObject.Find("Check"))
                return;

            GameObject target = AssetDatabase.LoadAssetAtPath<GameObject>(fullPathCheckButton);

            Canvas c = FindObjectOfType<Canvas>();

            GameObject _buttonCheckPrefabInstance = PrefabUtility.InstantiatePrefab(target, c.transform) as GameObject;
        }

        [MenuItem("Selecu Tools/Create Integrate Button")]
        public static void CreateIntegrateButton()
        {
            if (GameObject.Find("Integrate"))
                return;

            GameObject target = AssetDatabase.LoadAssetAtPath<GameObject>(fullPathIntegrateButton);

            Canvas c = FindObjectOfType<Canvas>();

            GameObject _buttonIntegratePrefabInstance = PrefabUtility.InstantiatePrefab(target, c.transform) as GameObject;
        }

        [MenuItem("Selecu Tools/Create Panel Window &#p")]
        public static void CreatePanelWindow()
        {
            Canvas c = FindObjectOfType<Canvas>();

            GameObject panel = new GameObject("Panel", typeof(RectTransform));
            panel.transform.SetParent(c.transform);

            SetAnchours(panel.GetComponent<RectTransform>());

            GameObject window = new GameObject("Window", typeof(RectTransform), typeof(Image));
            window.transform.SetParent(panel.transform);
            window.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

            GameObject closeButton = new GameObject("Close", typeof(RectTransform), typeof(Image), typeof(Button));
            closeButton.transform.SetParent(window.transform);
            closeButton.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }

        // ----------------------------------------------------------------------------------- //

        #endregion
#endif
    }
}
