using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyEndEventData : EventData
{
    public MyItem item;
    public int price;
    public BuyEndEventData(MyItem pItem, int pPrice) : base(EventType.BUYEND)
    {
        item = pItem;
        price = pPrice;
    }
}
