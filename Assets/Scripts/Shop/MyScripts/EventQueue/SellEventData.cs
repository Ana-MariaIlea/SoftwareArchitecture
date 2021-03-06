﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellEventData : EventData
{
    public MyItem item;
    public int price;
    public SellEventData(MyItem pItem, int pPrice) : base(EventType.SELL)
    {
        item = pItem;
        price = pPrice;
    }
}
