using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerUpgradeInventoryEventData : EventData
{
    public ShopModel model;
    public LoadPlayerUpgradeInventoryEventData(ShopModel pModel) : base(EventType.LOADPLAYERUPGRADEINVENTORY)
    {
        model = pModel;
    }
}
