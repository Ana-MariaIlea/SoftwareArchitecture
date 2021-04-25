using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public ShopModel ShopModel => shopModel; //A getter to access shopModel.

    private ShopModel shopModel; //Model in MVC pattern

    // Start is called before the first frame update
    void Awake()
    {
        shopModel = new BuyModel(2f, 7, 500); //Right now use magic values to set up the shop
        EventQueue.eventQueue.AddEvent(new LoadShopInventory(shopModel));
        EventQueue.eventQueue.Subscribe(EventType.BUYEND, OnRemoveItemFromInventory);
        EventQueue.eventQueue.Subscribe(EventType.SELL, OnAddItemFromInventory);
        for (int i = 0; i < shopModel.myInventory.GetItemCount(); i++)
        {
            Debug.Log("Shop inventory, index "+i+" " + shopModel.myInventory.GetItemByIndex(i).type);
        }
    }

    public void OnRemoveItemFromInventory(EventData eventData)
    {
        if (eventData is BuyEndEventData)
        {
            BuyEndEventData e = eventData as BuyEndEventData;
            shopModel.myInventory.Remove(e.item);
            Debug.Log("Item added " + e.item.name);
        }
        else
        {
            throw new System.ArgumentOutOfRangeException("eventData", "EventData is not BuyEndEventData");
        }
    }

    public void OnAddItemFromInventory(EventData eventData)
    {
        if (eventData is SellEventData)
        {
            SellEventData e = eventData as SellEventData;
            shopModel.myInventory.AddItem(e.item);
            Debug.Log("Item sold " + e.item.name);
        }
        else
        {
            throw new System.ArgumentOutOfRangeException("eventData", "EventData is not SellEventData");
        }
    }
}
