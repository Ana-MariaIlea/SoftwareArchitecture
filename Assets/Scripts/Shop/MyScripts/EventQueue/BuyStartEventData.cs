using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyStartEventData : EventData
{
    public MyItem item;
    public int price;
    public BuyStartEventData(MyItem pItem, int pPrice) : base(EventType.BUYSTART)
    {
        item = pItem;
        price = pPrice;
    }
}
