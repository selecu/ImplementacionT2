using Interactions.DeciferTheCode.Comprobation;
using Interactions.DeciferTheCode.Mechanics;
using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Interactions.DeciferTheCode
{
    public class ManagerDeciferCode : MonoBehaviour
    {
        public const int radiusCollisionConstant = 25;

        [Range(1,5)]
        public float rotationSpeed = 5;

        [Header("Front Roulette")]
        public Sprite frontSprite;

        [Header("Middle Roulette")]
        public Sprite middleSprite;

        [Header("Back Roulette")]
        public Sprite backSprite;

        [Header("Comprobation Fields")]
        public List<ComprobationField> comprobationFields;

        public GameObject[] ventana;

        [Header("Events"), Space(30)]
        public UnityEvent OnIncorrectCheck;
        public UnityEvent OnCorrectCheck;

        private void Start()
        {
            RotateRoulette.speed = rotationSpeed * 100;
        }

        public void CreateRoulette()
        {
            GameObject box = new GameObject($"Box ({transform.childCount})", typeof(RectTransform), typeof(RandomizeBox));
            box.transform.SetParent(this.transform, false);
            box.layer = LayerMask.NameToLayer("UI");

            BackRoulette backComponent = new BackRoulette("Back Roulette", backSprite, box);
            MiddleRoulette middleRoulette = new MiddleRoulette("Middle Roulette", middleSprite, box);
            FrontRoulette frontComponent = new FrontRoulette("Front Roulette", frontSprite, box);
            RouletteComprobation rouletteComprobation = new RouletteComprobation("Roulette Comprobation", box);
        }

        //public void CreateCollisionComponent(GameObject parent)
        //{
        //    if (parent)
        //        BackRoulette.CreateRouletteCollisionComponent(parent);
        //}

        public void Check()
        {
            bool isCorrect;

            isCorrect = Comprobation();

            if (isCorrect)
            {
                OnCorrectCheck.Invoke();
                ventana[0].SetActive(true);
                print("Correct");
            }
            else
            {
                OnIncorrectCheck.Invoke();
                StartCoroutine(des());
                print("Incorrect");
            }
        }

        IEnumerator des()
        {
            yield return new WaitForSeconds(5);
            ventana[1].SetActive(false);
            StopCoroutine(des());
        }

        public bool Comprobation()
        {
            if (comprobationFields.Count == 0)
            {
                Debug.LogError("Set All Comprobation Fields");
                return false;
            }

            foreach (var item in comprobationFields)
            {
                if (item.correctValue != item.valueToComprobate)
                    return false;
            }
            return true;
        }
    }

    public abstract class CreateBaseRouletteObject
    {
        public virtual GameObject CreateBase(string name, GameObject parent)
        {
            GameObject createBaseObject = new GameObject(name, typeof(RectTransform));

            createBaseObject.transform.SetParent(parent.transform, false);
            createBaseObject.layer = LayerMask.NameToLayer("UI");

            return createBaseObject;
        }

        public virtual GameObject CreateBase(string name, Sprite sprite, GameObject parent)
        {
            GameObject createBaseObject = new GameObject(name, typeof(RectTransform), typeof(Image));

            Image image = createBaseObject.GetComponent<Image>();

            image.sprite = sprite;
            image.SetNativeSize();

            createBaseObject.transform.SetParent(parent.transform, false);
            createBaseObject.layer = LayerMask.NameToLayer("UI");

            return createBaseObject;
        }

    }

    public class EmptyObject : CreateBaseRouletteObject
    {
        public EmptyObject(string name, GameObject parent)
        {
            GameObject emptyObject = base.CreateBase(name, parent);
        }
    }

    public class BackRoulette : CreateBaseRouletteObject
    {
        public static int radius = ManagerDeciferCode.radiusCollisionConstant;

        public BackRoulette(string name, Sprite sprite, GameObject parent)
        {
            GameObject backRoulette = base.CreateBase(name, sprite, parent);
            backRoulette.AddComponent<BackCollision.CreateCollision> ();
            CreateRouletteCollisionComponent(backRoulette);
        }

        public static GameObject CreateRouletteCollisionComponent(GameObject parent)
        {
            GameObject collisionObject = new GameObject($"Collision ({parent.transform.childCount})",
                typeof(RectTransform), typeof(CircleCollider2D), typeof(BackCollision.RouletteCollisionComponent));

            CircleCollider2D collider = collisionObject.GetComponent<CircleCollider2D>();
            collider.radius = radius;
            collider.isTrigger = true;
            collider.tag = "DecifersTheCode";

            collisionObject.transform.SetParent(parent.transform, false);

            return collisionObject;
        }
    }


    public class MiddleRoulette : CreateBaseRouletteObject
    {
        public MiddleRoulette(string name, Sprite sprite, GameObject parent)
        {
            GameObject middleRoulette = base.CreateBase(name, sprite, parent);
            EventTrigger eventTrigger = middleRoulette.AddComponent<EventTrigger>();
        }
    }

    public class FrontRoulette : CreateBaseRouletteObject
    {
        public FrontRoulette(string name, Sprite sprite, GameObject parent)
        {
            GameObject frontRoulette = base.CreateBase(name, sprite, parent);
            EventTrigger eventTrigger = frontRoulette.AddComponent<EventTrigger>();
            frontRoulette.AddComponent<Interactions.DeciferTheCode.Mechanics.RotateRoulette>();
        }
    }

    public class RouletteComprobation : CreateBaseRouletteObject
    {
        public RouletteComprobation(string name, GameObject parent)
        {
            GameObject rouletteComprobation = base.CreateBase(name, parent);
            rouletteComprobation.AddComponent<Rigidbody2D>().isKinematic = true;
            CircleCollider2D collider = rouletteComprobation.AddComponent<CircleCollider2D>();
            collider.radius = ManagerDeciferCode.radiusCollisionConstant;

            rouletteComprobation.AddComponent<Interactions.DeciferTheCode.Comprobation.ComprobationField>();
        }
    }





#region Editor


    #if UNITY_EDITOR
        [CustomEditor(typeof(ManagerDeciferCode))]
        public class RouletteGUIEditorConfig : Editor
        {
            public override void OnInspectorGUI()
            {
                ManagerDeciferCode managerTarget = (ManagerDeciferCode)target;
                base.OnInspectorGUI();

                GUILayout.Space(30);

                EditorGUILayout.HelpBox(
                    "Make sure you add the tag 'DecifersTheCode' and that it is assigned correctly in each roulette collision for it to work properly.\n" +
                    "Also, keep in mind to use the EventTrigger to trigger the rotation mechanics.\n\n\t (Recommendation: use the EventTrigger in the MiddleRoulette && FrontRoulette).",
                    MessageType.Warning);

                GUILayout.Space(30);
                if (GUILayout.Button("Create New Roulette"))
                    managerTarget.CreateRoulette();

                if (GameObject.Find("Back Roulette"))
                {
                    GUILayout.Space(5);
                    if (GUILayout.Button("Find All ComprobationFields"))
                    {
                        managerTarget.comprobationFields.Clear();
                        foreach (var item in FindObjectsOfType<Comprobation.ComprobationField>())
                            managerTarget.comprobationFields.Add(item);
                    }
                }
                else BackRoulette.radius = ManagerDeciferCode.radiusCollisionConstant;
            }
        }
    #endif


#endregion

}
