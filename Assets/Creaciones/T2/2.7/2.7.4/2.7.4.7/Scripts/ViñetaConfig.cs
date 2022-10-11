using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace I2747
{

    [System.Serializable]
    public class ViñetaAttribute
    {
        [Header("Atributos de viñeta")]
        [Tooltip("Sprite del fondo de la viñeta.")]
        public Sprite backgroundViñeta;
        [Tooltip("AudioClip de la viñeta.")]
        public AudioClip audioClipViñeta;
        [TextArea, Tooltip("Audio de la viñeta.")]
        public string text;

        [Space(15)]
        public UnityEvent OnEndViñeta;
        [Header("Timer"), Space(10), Tooltip("Duración de la viñeta.")]
        public float delay;
    }

    [RequireComponent(typeof(AudioSource))]
    public class ViñetaConfig : MonoBehaviour
    {
        public List<ViñetaAttribute> viñetas;

        [Header("Targets"), Space(30)]
        //"Puedes asignar en este evento la funcion de StartCoroutineInitializedViñetas para inicializar las viñetas en el start."
        public UnityEvent OnStartEvent;
        public UnityEvent OnEndAllViñetas;

        [Header("Targets"), Space(30)]
        [Tooltip("AudioSource en el que se reproducirán los audios.")]
        public AudioSource audioSourceTarget;
        [SerializeField, Tooltip("Imagen referenciada de la viñeta")]
        private Image imageTarget;
        [SerializeField, Tooltip("Texto referenciado de la viñeta")]
        private TMP_Text textTarget;

        public Image ImageTarget { get => imageTarget; set => imageTarget = value; }
        public TMP_Text TextTarget { get => textTarget; set => textTarget = value; }

        private void Start()
        {
            OnStartEvent.Invoke();
        }

        public void StartCoroutineInitializedViñetas() =>
            StartCoroutine(InitializedViñetas());

        IEnumerator InitializedViñetas()
        {
            for (int i = 0; i < viñetas.Count; i++)
            {
                ImageTarget.sprite = viñetas[i].backgroundViñeta;
                TextTarget.text = viñetas[i].text;
                audioSourceTarget.clip = viñetas[i].audioClipViñeta;
                audioSourceTarget.Play();
                yield return new WaitForSeconds(viñetas[i].audioClipViñeta.length + viñetas[i].delay);
                viñetas[i].OnEndViñeta.Invoke();
            }
            OnEndAllViñetas.Invoke();
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(ViñetaConfig))]
    public class EditorGUILayoutConfig : Editor
    {
        public override void OnInspectorGUI()
        {
            ViñetaConfig targetVar = (ViñetaConfig)target;
            base.OnInspectorGUI();
            EditorGUILayout.Space(15);

            if (GUILayout.Button("Crear Viñeta"))
            {
                CreateViñetaGameObject();
            }
            if (GUILayout.Button("Link Viñeta Targets"))
            {
                if (!targetVar.audioSourceTarget)
                    targetVar.audioSourceTarget = targetVar.GetComponent<AudioSource>();

                var targetViñeta = GameObject.Find("Viñeta");
                if (targetViñeta)
                {
                    targetVar.ImageTarget = targetViñeta.GetComponentInChildren<Image>();
                    targetVar.TextTarget = targetViñeta.GetComponentInChildren<TMP_Text>();
                }
            }


            if (targetVar.viñetas != null && targetVar.viñetas.Count != 0)
            {
                if (targetVar.viñetas[0].audioClipViñeta != null)
                {
                    GUILayout.Space(15);
                    EditorGUILayout.HelpBox($"La duración de la viñeta está anclada a la duración del audio.\n\n\t Ejemplo (viñetas[0]): ({targetVar.viñetas[0].audioClipViñeta.length} + {targetVar.viñetas[0].delay})", MessageType.Warning);
                }
            }
        }

        public GameObject CreateViñetaGameObject()
        {
            var target = GameObject.Find("Viñeta");
            if (target != null)
            {
                DestroyImmediate(target);
                CreateViñetaGameObject();
            }
            else
            {
                GameObject newViñeta = new GameObject();

                newViñeta.AddComponent<RectTransform>();
                newViñeta.transform.SetParent(FindObjectOfType<Canvas>().transform);
                newViñeta.name = "Viñeta";

                GameObject imageGO = new GameObject();
                imageGO.AddComponent<RectTransform>();
                imageGO.AddComponent<Image>();
                imageGO.transform.SetParent(newViñeta.transform);
                imageGO.name = "Image";

                GameObject text = new GameObject();
                text.AddComponent<RectTransform>();
                text.AddComponent<TextMeshProUGUI>();
                text.transform.SetParent(newViñeta.transform);
                text.name = "Text (TMP)";

                return newViñeta;
            }
            return null;
        }
#endif
    }
}
