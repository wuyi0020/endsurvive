using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "ItemData", menuName = "Data/ItemData")]
[Serializable]
public class Item : ScriptableObject
{
    
    public string ItemName;
    public Sprite ItemImage;
    [Rename("數量"),Range(1,10)]
    public int ItemHeld;
    [Rename("消耗品?"), Tooltip("true是可消耗的意思")]
    public bool Can_use;
    [TextArea]
    public string ItemInfo;
}
