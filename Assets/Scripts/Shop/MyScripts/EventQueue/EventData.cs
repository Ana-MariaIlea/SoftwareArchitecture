using System.Collections;
using System.Collections.Generic;


public enum EventType
{
    BUY,
    SELL,
    UPGRADE,
    INITIALIZESHOPINV,
    INITIALIZEPLAYERINV
}
public class EventData 
{
    public EventType eventType;
    public EventData(EventType type)
    {
        eventType = type;
    }

}
