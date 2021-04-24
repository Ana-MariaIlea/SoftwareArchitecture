using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeEndEventData : EventData
{
    public MyItem item;
    public int price;
    public UpgradeEndEventData(MyItem pItem, int pPrice) : base(EventType.UPGRADEEND)
    {
        item = pItem;
        price = pPrice;
    }
}
