using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "data game", menuName = "Game data Objeto")]
public class GameDataObject : ScriptableObject
{
    public List<TemplateDataItem> gameData;
    
}

[System.Serializable]
public class TemplateDataItem
{
    public string name;
    [TextArea]
    public string description;
    public Texture2D imgRef;
    public GameObject prefab;
}
