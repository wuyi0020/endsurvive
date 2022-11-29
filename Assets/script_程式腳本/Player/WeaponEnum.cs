using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponEnum : MonoBehaviour
{
    public Weapon weapon;
}
[Serializable]
public enum Weapon
{
    空手,
    木棍
}
