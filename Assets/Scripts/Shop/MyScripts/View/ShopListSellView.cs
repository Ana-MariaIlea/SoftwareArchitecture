using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopListSellView : ShopListView
{
    private void Start()
    {
        EventQueue.eventQueue.Subscribe(EventType.LOADPLAYERINV, OnShowInvetory);
        base.Start();

    }


    public override void OnShowInvetory(EventData eventData)
    {
        if (eventData is LoadPlayerInventory)
        {

            LoadPlayerInventory e = eventData as LoadPlayerInventory;

            shopModel = e.model;
            shopController.Initialize(shopModel);
            RepopulateItemIconView();
        }
        else
        {
            throw new System.ArgumentOutOfRangeException("eventData", "EventData is not LoadPlayerInventory");
        }
    }
}
