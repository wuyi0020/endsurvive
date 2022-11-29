using UnityEngine;
using System;
using TMPro;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
[Serializable]
public class PlayerData : ScriptableObject
{
    [Rename("血量"), Tooltip("預設為80")]
    public int HP = 80;
    [Rename("飢餓"), Tooltip("預設為80")]
    public int Hunger = 80;
    [Rename("健康狀態"), Tooltip("預設為80")]
    public int Healt = 80;
    [Rename("武器"), Tooltip("預設為空手")]
    public Weapon weapon;
    [Rename("副武器"), Tooltip("預設為空手")]
    public Weapon secWeapon;
    [Rename("生病狀態")]
    public Sick sick;


    
    
}
[Serializable]
public enum Sick
{
    //無受傷
    健康,
    //受傷
    受傷,
    //受傷後受傷
    出血,
    //生病
    生病,
    //生病加重
    發燒,
    //與一般生病不同
    病毒感染,
    //病毒感染太久沒治療
    殭屍病毒發作,
    死亡,
}

