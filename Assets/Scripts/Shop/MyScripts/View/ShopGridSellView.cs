using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGridSellView : ShopGridView
{
    private void Start()
    {
        EventQueue.eventQueue.Subscribe(EventType.LOADPLAYERINV, OnShowInvetory);
        base.Start();
        
    }


    public override void OnShowInvetory(EventData eventData)
    {
        LoadPlayerInventory e = eventData as LoadPlayerInventory;

        shopModel = e.model;
        shopController.Initialize(shopModel);
        RepopulateItemIconView();
    }


}
