using System.Collections;
using System.Collections.Generic;


public enum EventType
{
    BUY,
    SELL,
    UPGRADE
}
public class EventData 
{
    public EventType eventType;
    public EventData(EventType type)
    {
        eventType = type;
    }

}
