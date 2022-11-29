using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//儲存格UI 用來放置Prefab內的組件
public class Slot : MonoBehaviour
{
    public Item Slotitem;
    public Image SlotImage;
    public TextMeshProUGUI SlotNum;

    public void updatainfo()
    {
        BagManager.UpdataIteminfo(Slotitem.ItemInfo);
    }
}
