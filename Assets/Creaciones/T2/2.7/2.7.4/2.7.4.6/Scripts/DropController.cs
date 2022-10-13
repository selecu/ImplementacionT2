using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DropController : MonoBehaviour
{
    [SerializeField]
    private bool checkInternalValues;
    [SerializeField]
    private bool setNativeSizeOnDrop;

    [SerializeField]
    private int correctValue;
    private int valueCollected;

    public static DragController dragController;
    public List<Sprite> spriteList;


    public int CorrectValue { get => correctValue; }
    public int ValueCollected { get => valueCollected; set => valueCollected = value; }

    public void OnDrop()
    {
        foreach (var classElement in dragController.classesToAffect)
        {
            if (classElement == this)
            {
                Image myImage = GetComponent<Image>();

                if (myImage.color.a == 0f)
                {
                    var tempColor = myImage.color;
                    tempColor.a = 255f;
                    myImage.color = tempColor;

                }

                myImage.sprite = spriteList[dragController.ValueToSend];
                ValueCollected = dragController.ValueToSend;

                if (setNativeSizeOnDrop)
                    myImage.SetNativeSize();
            }
        }
    }

    public void OnEnter()
    {
        GameObject itemDrag = GameObject.Find("ItemDraggerParent");

        if (itemDrag.transform.childCount != 0)
            dragController = itemDrag.transform.GetChild(0).GetComponent<DragController>();
    }

    public bool CheckingInternalValues()
    {
        if (checkInternalValues)
        {
            if (ValueCollected == CorrectValue)
                return true;
            return false;
        }
        else
            return true;
    }

    [CustomEditor(typeof(DropController))]
    public class EditorLayout : Editor
    {
        public override void OnInspectorGUI()
        {
            DropController targetDropController = (DropController)target;
           
            base.OnInspectorGUI();

            if (targetDropController.checkInternalValues)
            {
                GUILayout.Space(15);
                GUILayout.Label("Parameters to check...");
                EditorGUILayout.HelpBox($"Correct Value: {targetDropController.CorrectValue}", MessageType.Info);
                EditorGUILayout.HelpBox($"Value Collected: {targetDropController.ValueCollected}", MessageType.Info);
                GUILayout.Space(15);
            }
            else EditorGUILayout.HelpBox("Whatever value you send, return true on the internal function (CheckingInternalValues)", MessageType.Warning);
        }
    }
}
