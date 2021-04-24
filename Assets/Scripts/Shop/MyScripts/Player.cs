using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int money;
    public ShopModel ShopModel => shopModel; //A getter to access shopModel.

    private ShopModel shopModel; //Model in MVC pattern

    public ShopModel ShopUpgradeModel => shopUpgradeModel; //A getter to access shopModel.

    private ShopModel shopUpgradeModel; //Model in MVC pattern

    // Start is called before the first frame update
    void Start()
    {
        shopModel = new SellModel(2f, 16, 500); //Right now use magic values to set up the shop
        shopUpgradeModel = new UpgradeModel(2f, 16, 500); //Right now use magic values to set up the shop
        shopUpgradeModel.myInventory = shopModel.myInventory;
        EventQueue.eventQueue.AddEvent(new LoadPlayerInventory(shopModel));
        EventQueue.eventQueue.AddEvent(new LoadPlayerUpgradeInventoryEventData(shopUpgradeModel));


        EventQueue.eventQueue.Subscribe(EventType.BUYSTART, OnItemBuyBegin);
        EventQueue.eventQueue.Subscribe(EventType.BUYEND, OnAddItemToInventory);
        EventQueue.eventQueue.Subscribe(EventType.SELL, OnItemSold);

        for (int i = 0; i < shopModel.myInventory.GetItemCount(); i++)
        {
            Debug.Log("Player inventory, index " + i + " " +shopModel.myInventory.GetItemByIndex(i).type);
        }
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
        shopUpgradeModel.myInventory.AddItem(e.item);
        ChangeMoneyAmount(-e.price);
        Debug.Log("Item added "+ e.item.name);

    }

    public void OnItemSold(EventData eventData)
    {
        SellEventData e = eventData as SellEventData;
        shopModel.myInventory.Remove(e.item);
        shopUpgradeModel.myInventory.Remove(e.item);
        ChangeMoneyAmount(e.price);
        Debug.Log("Item sold " + e.item.name);

    }

    public void OnItemUpgradeStart(EventData eventData)
    {
        UpgradeStartEventData e = eventData as UpgradeStartEventData;
        if (HasEnoughMoney(e.price))
        {
            EventQueue.eventQueue.AddEvent(new ScreenGridChangeEventData());
            EventQueue.eventQueue.AddEvent(new UpgradeEndEventData(e.item, e.price));
        }
    }

    public void OnItemUpgradeEnd(EventData eventData)
    {

    }
}
