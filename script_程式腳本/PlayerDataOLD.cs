using UnityEngine;
using System;
using TMPro;
using UnityEngine.Events;

public class PlayerDataOLD : MonoBehaviour
{
   

    [Rename("血量"), Tooltip("預設為80")]
    public int HP = 80;
    [Rename("飢餓"), Tooltip("預設為80")]
    public int Hunger = 80;
    [Rename("健康狀態"), Tooltip("預設為80")]
    public int Healt = 80;
    [Rename("武器"), Tooltip("預設為空手")]
    public Weapon weapon ; 
    [Rename("副武器"), Tooltip("預設為空手")]
    public Weapon secWeapon ;
    [Rename("生病狀態")]
    public Sick sick ;

    [Header("更新數值(updata)")]
    public UnityEvent updata;

    [Header("時間設置")]
    public TimeManager time;

    public GameObject MyBag;
    [HideInInspector]
    public bool bag;


    private void Start()
    {
        bag = false;
    }



    private void Update()
    {
        updata.Invoke();
        OpenBag();
    }

    public void HPupdata(TextMeshProUGUI textMeshPro)
    {
        
        textMeshPro.SetText("血量：" + HP);
    }
    public void HPhit(int hit)
    {
        HP -= hit;
    }
    public void HPHealt(int heal)
    {
        HP += heal;
    }
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
    public enum Weapon
    {
       空手,
       木棍
    }

    public void OpenBag()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            bag = !bag;
            MyBag.SetActive(bag);
            BagManager.RefreshItem();
            if (bag)
            {
                time.Timestop();
            }
            else
            {
                time.TimeResume();
            }
        }
        
    }

}
