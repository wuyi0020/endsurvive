using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager insteance;

    public PlayerData playerData;
    public GameObject MyBag;
    public GameObject gameover;


    //[Rename("血量"), Tooltip("playerData 血量顯示 無法更改")]
    //public int M_HP = 80;
    //[Rename("飢餓"), Tooltip("playerData 飢餓顯示 無法更改")]
    //public int M_Hunger = 80;
    //[Rename("健康狀態"), Tooltip("playerData 健康狀態顯示 無法更改")]
    //public int M_Healt = 80;
    //[Rename("武器"), Tooltip("playerData 武器顯示 無法更改")]
    //public Weapon M_weapon;
    //[Rename("副武器"), Tooltip("playerData 副武器顯示 無法更改")]
    //public Weapon M_secWeapon;
    //[Rename("生病狀態"), Tooltip("playerData 生病狀態顯示 無法更改")]
    //public Sick sick;

    void Awake()
    {
        //如果有其他靜態物件 銷毀該物件並重新註冊
        if (insteance != null)
        {
            Destroy(this);
        }
        else { insteance = this; }
    }

    private void Update()
    {
        GameOver();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenBag();
        }
        //Playerupdata();
    }

    //void Playerupdata()
    //{
    //    M_HP = playerData.HP;
    //    M_Hunger = playerData.Hunger;
    //    M_weapon = playerData.weapon;
    //    M_secWeapon = playerData.secWeapon;
    //    M_Healt = playerData.Healt;

    //}

    public void Hit(int hit)
    {
        playerData.HP -= hit;
    }
    public void Healt(int Healt)
    {
        playerData.HP += Healt;
    }
    public void Hunger(int Hunger)
    {
        playerData.Hunger -= Hunger;
    }

    public void ChangeWeapon(WeaponEnum a)
    {
        //switch (a)
        //{
        //    case ((int)Weapon.空手):
        //        playerData.weapon = Weapon.空手;
        //        break;
        //    case ((int)Weapon.木棍):
        //        playerData.weapon = Weapon.木棍;
        //        break;
        //}
        if (a.weapon == Weapon.木棍)
        {
            playerData.weapon = Weapon.木棍;
            Debug.Log("木棍");
            return;
        }
        if (a.weapon == Weapon.空手)
        {
            playerData.weapon = Weapon.空手;
            return;
        }



    }

    public void GameOver()
    {
        //暫停時間
        if (playerData.HP <= 0)
        {
            TimeManager.insteance.Timestop();
            Debug.Log("Gameover");
            //未做 顯示GameOver畫面
            gameover.SetActive(true);
            //未做 儲存遊戲紀錄
        }
    }
    public void OpenBag()
    {

        

        MyBag.SetActive(!MyBag.activeSelf);
        BagManager.RefreshItem();
        if (MyBag.activeSelf)
        {
            TimeManager.insteance.Timestop();
        }
        else
        {
            TimeManager.insteance.TimeResume();
        }


    }
}
