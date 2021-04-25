using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopListBuyView : ShopListView
{

    private void Start()
    {

        EventQueue.eventQueue.Subscribe(EventType.LOADSHOPINV, OnShowInvetory);

        base.Start();
    }

    public override void OnShowInvetory(EventData eventData)
    {
        if (eventData is LoadShopInventory)
        {
            LoadShopInventory e = eventData as LoadShopInventory;

            shopModel = e.model;
            shopController.Initialize(shopModel);
            RepopulateItemIconView();
        }
        else
        {
            throw new System.ArgumentOutOfRangeException("eventData", "EventData is not LoadShopInventory");
        }
    }
}
