using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    public static PlayerUIManager insteance;

    public TextMeshProUGUI UI_HP;
    public TextMeshProUGUI UI_Hunger;
    public TextMeshProUGUI UI_Healt;


    void Awake()
    {
        //如果有其他PlayerUIManager 銷毀該物件並重新註冊
        if (insteance != null)
        {
            Destroy(this);
        }
        else { insteance = this; }
    }
    
  
    void Start()
    {
        //開始時執行UI更新
        PlayerDataUPdata();
        

    }

    //重複執行UI更新
    void Update()
    {
        PlayerDataUPdata();
    }

    public void PlayerDataUPdata()
    {
        UI_HP.SetText("血量：" + PlayerManager.insteance.playerData.HP);
        UI_Hunger.SetText("飢餓：" + PlayerManager.insteance.playerData.Hunger);
        UI_Healt.SetText("健康：" + PlayerManager.insteance.playerData.Healt);
        
    }

}
