﻿using System.Collections;
using System.Collections.Generic;


public enum EventType
{
    BUYSTART,
    BUYEND,
    SELL,
    UPGRADESTART,
    UPGRADEEND,
    LOADSHOPINV,
    LOADPLAYERINV
}
public class EventData 
{
    public EventType eventType;
    public EventData(EventType type)
    {
        eventType = type;
    }

}
