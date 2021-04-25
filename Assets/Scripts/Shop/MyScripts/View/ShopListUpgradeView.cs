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
        if (eventData is LoadPlayerUpgradeInventoryEventData)
        {
            LoadPlayerUpgradeInventoryEventData e = eventData as LoadPlayerUpgradeInventoryEventData;
            shopModel = e.model;
            shopController.Initialize(shopModel);
            RepopulateItemIconView();
        }
        else
        {
            throw new System.ArgumentOutOfRangeException("eventData", "EventData is not LoadPlayerUpgradeInventoryEventData");
        }
    }
}
