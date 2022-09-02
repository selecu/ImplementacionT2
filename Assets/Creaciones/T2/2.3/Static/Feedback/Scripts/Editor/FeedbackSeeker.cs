using UnityEngine;
using UnityEditor;

namespace Static.Feedback.Editor
{
    public class FeedbackSeeker : UnityEditor.Editor
    {
        const string fullPath = "Assets/Creaciones/T2/2.6/Static/Feedback/PrefabCorrect/FeedbackBueno.prefab";
        private static GameObject prefab;


        private static PostActivator non;

        [MenuItem("Selecu Tools/Create Feedback Fore")]
        private static void CreateFeedbackFore()
        {
            if(!prefab)
            {
                prefab = AssetDatabase.LoadAssetAtPath<GameObject>(fullPath);
            }

            
            Canvas c = FindObjectOfType<Canvas>();

            Instantiate(prefab, c.transform);

            GameObject triggers = new GameObject("Triggers");
            non = new PostActivator();
            
            Instantiate(non, triggers.transform);
            Instantiate(non, triggers.transform);

        }
    }
}

