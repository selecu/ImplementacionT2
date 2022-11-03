using UnityEngine;
using UnityEditor;

namespace Static.Feedback.Editor
{
    public class FeedbackSeeker : UnityEditor.Editor
    {
        const string FULLPATH = "Assets/Creaciones/EdadDeLosPueblos/Prefabs/Static/Feedback/FeedbackBueno.prefab";

        private static GameObject prefab;

        private static PostActivator non;


        [MenuItem("Selecu Tools/Create Feedback Fore &#f")]
        private static void CreateFeedbackFore()
        {
            if(!prefab)
                prefab = AssetDatabase.LoadAssetAtPath<GameObject>(FULLPATH);


            Canvas c = FindObjectOfType<Canvas>();

            Instantiate(prefab, c.transform);

            GameObject triggers = new GameObject("Triggers");

            GameObject non = new GameObject("Non", typeof(PostActivator));

            non.SetActive(false);

            non.transform.SetParent(triggers.transform);

            Instantiate(non, triggers.transform);

        }
    }
}

