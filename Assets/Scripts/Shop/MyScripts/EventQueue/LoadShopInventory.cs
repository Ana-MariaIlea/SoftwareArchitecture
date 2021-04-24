using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadShopInventory : EventData
{
    ShopModel model;
    public LoadShopInventory(ShopModel pModel) : base(EventType.LOADSHOPINV)
    {
        model = pModel;
    }
}
