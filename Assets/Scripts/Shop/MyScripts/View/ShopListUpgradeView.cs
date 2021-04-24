using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopListUpgradeView : ShopListView
{
    private void Start()
    {

        EventQueue.eventQueue.Subscribe(EventType.LOADPLAYERUPGRADEINVENTORY, OnShowInvetory);
        base.Start();

    }


    public override void OnShowInvetory(EventData eventData)
    {
        LoadPlayerUpgradeInventoryEventData e = eventData as LoadPlayerUpgradeInventoryEventData;
        shopModel = e.model;
        shopController.Initialize(shopModel);
        RepopulateItemIconView();
    }
}
