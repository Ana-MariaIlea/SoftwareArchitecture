using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopGridBuyView : ShopGridView
{ 

    private void Start()
    {
        EventQueue.eventQueue.Subscribe(EventType.LOADSHOPINV, OnShowInvetory);
        base.Start();
        
    }


    public override void OnShowInvetory(EventData eventData)
    {
        LoadShopInventory e = eventData as LoadShopInventory;

        shopModel = e.model;
        shopController.Initialize(shopModel);
        RepopulateItemIconView();
    }

   
}
