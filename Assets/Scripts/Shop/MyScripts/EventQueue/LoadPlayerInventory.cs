using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerInventory : EventData
{
    ShopModel model;
    public LoadPlayerInventory(ShopModel pModel) : base(EventType.LOADPLAYERINV)
    {
        model = pModel;
    }
}
