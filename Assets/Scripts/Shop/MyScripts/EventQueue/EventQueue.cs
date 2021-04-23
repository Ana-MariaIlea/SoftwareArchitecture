using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EventQueue : MonoBehaviour
{

    public delegate void EventHandler(EventData eventData);
    private Dictionary<EventType, EventHandler> subscriberDictionary= new Dictionary<EventType, EventHandler>();
    private List<EventData> eventList=new List<EventData>();

    // Update is called once per frame
    void Update()
    {
        PublishEvents();
    }

    public void Subscribe(EventType eventType, EventHandler eventHandler)
    {
        if (!subscriberDictionary.ContainsKey(eventType))
        {
            EventHandler handler = null;
            subscriberDictionary.Add(eventType, handler);
        }
        subscriberDictionary[eventType] += eventHandler;
    }

    public void UnSubscribe(EventType eventType, EventHandler eventHandler)
    {
        if (subscriberDictionary.ContainsKey(eventType))
        {
            subscriberDictionary[eventType] -= eventHandler;
        }
        else
        {
            Debug.Log("Event type " + eventType.ToString() + " doesn't exist in the dictionary");
        }
    }

    public void AddEvent(EventData eventData)
    {
        if (!Enum.IsDefined(typeof(EventType), eventData.eventType))
        {
            throw new ArgumentOutOfRangeException("eventData.eventType", "EventType is invalid");
        }
    }

    public void PublishEvents()
    {
        for (int i = eventList.Count-1; i >=0; i--)
        {
            EventData data = eventList[i];
            if (subscriberDictionary.ContainsKey(data.eventType))
            {
                subscriberDictionary[data.eventType]?.Invoke(data);
            }
            else
            {
                Debug.Log("Event type " + data.eventType.ToString() + " doesn't exist in the dictionary");
            }

            eventList.Remove(data);
        }
    }
}
