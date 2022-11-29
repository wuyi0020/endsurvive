using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManger : MonoBehaviour
{
    public static DialogManger insteance;
    void Awake()
    {
        //如果有其他靜態物件 銷毀該物件並重新註冊
        if (insteance != null)
        {
            Destroy(this);
        }
        else { insteance = this; }
    }
}
