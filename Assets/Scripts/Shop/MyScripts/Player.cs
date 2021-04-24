using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int money;
    public ShopModel ShopModel => shopModel; //A getter to access shopModel.

    private ShopModel shopModel; //Model in MVC pattern

    // Start is called before the first frame update
    void Start()
    {
        shopModel = new BuyModel(2f, 16, 500); //Right now use magic values to set up the shop
        EventQueue.eventQueue.AddEvent(new LoadPlayerInventory(shopModel));
        EventQueue.eventQueue.Subscribe(EventType.BUYSTART, OnItemBuyBegin);
        EventQueue.eventQueue.Subscribe(EventType.BUYEND, OnAddItemToInventory);
    }

    public void ChangeMoneyAmount(int amount)
    {
        money += amount;
    }

    public bool HasEnoughMoney(int m)
    {
        if (money >= m) return true;
        return false;
    }

    public void OnItemBuyBegin(EventData eventData)
    {
        BuyStartEventData e = eventData as BuyStartEventData;
        if (HasEnoughMoney(e.price))
        {
            EventQueue.eventQueue.AddEvent(new ScreenGridChangeEventData());
            EventQueue.eventQueue.AddEvent(new BuyEndEventData(e.item,e.price));
        }
    }

    public void OnAddItemToInventory(EventData eventData)
    {
        BuyEndEventData e = eventData as BuyEndEventData;
        shopModel.myInventory.AddItem(e.item);
        ChangeMoneyAmount(-e.price);
        Debug.Log("Item added "+ e.item.name);

    }
}
