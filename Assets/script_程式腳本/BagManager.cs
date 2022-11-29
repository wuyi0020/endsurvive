using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BagManager : MonoBehaviour
{
    //公開靜態變數 製作成單例模式
    //單例模式解釋 註冊一個靜態的物件 靜態物件不像動態物件可以被其他物件註冊 所以同時只會存在一個
    //將靜態物件註冊為自身就可以讓所有物件都可呼叫這唯一的物件 不用重新註冊
    public static BagManager insteance;

    //註冊 Bag(ScriptableObject) 用途：用來存放物品的物件
    public Bag Mybag;
    //註冊 圖片存放位置 用途：將新生成物件的父級設定為此物件就能自動排列(Grid Layout Group)
    public GameObject SoltGrid;
    //註冊 物件的prefab 用途：將物品資料顯示的prefab物件
    public Slot soltprefab;
    //註冊 顯示文字的UI 用途：
    public TextMeshProUGUI info;


    void Awake()
    {
        //如果有其他BagManager 銷毀該物件並重新註冊
        if (insteance != null)
        {
            Destroy(this);
        }
        else { insteance = this; }
    }

    private void OnEnable()
    {
        //啟動時讓背包有東西
        RefreshItem();
        insteance.info.SetText("");
    }
    public static void UpdataIteminfo(string info)
    {
        insteance.info.SetText(info);
    }

    //創建在背包裡的物件並顯示在UI
    public static void CreateNewItem(Item item)
    {
        //生成一個newItem 生成方式為 複製一個新的Solt物件 原對象為單例模式下的insteance.soltprefab 
        Slot newItem = Instantiate(insteance.soltprefab, insteance.SoltGrid.transform.position, Quaternion.identity);
        //設定父級為 insteance.SoltGrid
        newItem.gameObject.transform.SetParent(insteance.SoltGrid.transform);
        //將接收到的item資料設定給newItem
        newItem.Slotitem = item;
        newItem.SlotImage.sprite = item.ItemImage;
        newItem.SlotNum.SetText(item.ItemHeld.ToString());
    }

    //銷毀並重新創建背包裡的物件並顯示在UI
    public static void RefreshItem()
    {
        //用迴圈把insteance.SoltGrid的子級銷毀
        for (int i = 0; i < insteance.SoltGrid.transform.childCount; i++)
        {
            if (insteance.SoltGrid.transform.childCount==0)
            {
                break;
            }
            Destroy(insteance.SoltGrid.transform.GetChild(i).gameObject);
        }
        //用迴圈把背包內的物品加回UI
        for (int i = 0; i < insteance.Mybag.Baglist.Count; i++)
        {
            CreateNewItem(insteance.Mybag.Baglist[i]);
        }
    }

}
