using Interactions.DeciferTheCode;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEditor;
using UnityEngine;

namespace Interactions.DeciferTheCode.BackCollision
{
    public class CreateCollision : MonoBehaviour
    {
        [HideInInspector]
        public ManagerDeciferCode managerDeciferCode;
        private void OnValidate()
        {
            if (managerDeciferCode == null)
                managerDeciferCode = FindObjectOfType<ManagerDeciferCode>();
        }
    }

#region Editor


#if UNITY_EDITOR
    [CustomEditor(typeof(CreateCollision))]
    public class CollisionGUIEditorConfig : Editor
    {
        public override void OnInspectorGUI()
        {
            CreateCollision managerTarget = (CreateCollision)target;
            base.OnInspectorGUI();

            BackRoulette.radius = EditorGUILayout.IntField("Radius Of Detection", BackRoulette.radius);

            if (GUILayout.Button("Create New Collision"))
                BackRoulette.CreateRouletteCollisionComponent(managerTarget.transform.gameObject);

            EditorGUILayout.HelpBox(
                "The collision component is used to detect the collision of every number. Set it to the corresponding number and assign it the value you send as parameter.",
                MessageType.Info);
        }
    }
#endif


#endregion
}
