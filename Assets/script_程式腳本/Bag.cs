using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Bag",menuName ="Data/BagData")]
public class Bag : ScriptableObject
{
    public List<Item> Baglist = new List<Item>();
}
