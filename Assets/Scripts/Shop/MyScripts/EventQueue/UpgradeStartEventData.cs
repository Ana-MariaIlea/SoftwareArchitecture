using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStartEventData : EventData
{
    public MyItem item;
    public int price;
    public UpgradeStartEventData(MyItem pItem, int pPrice) : base(EventType.UPGRADESTART)
    {
        item = pItem;
        price = pPrice;
    }
}
