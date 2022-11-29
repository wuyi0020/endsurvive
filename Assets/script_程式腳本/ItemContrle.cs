using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemContrle : MonoBehaviour
{
   public Bag Playerbag;
   public void PlayAdditem(Item item)
   {
        if (!Playerbag.Baglist.Contains(item))
        {
            Playerbag.Baglist.Add(item);
            //BagManager.CreateNewItem(item);
        }
        else
        {
            item.ItemHeld+=1;
        }
        BagManager.RefreshItem();

    }
}
