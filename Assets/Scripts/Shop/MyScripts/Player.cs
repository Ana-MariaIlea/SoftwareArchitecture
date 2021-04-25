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
    void Awake()
    {
        shopModel = new SellModel(2f, 7, 500); //Right now use magic values to set up the shop
        shopUpgradeModel = new UpgradeModel(2f, 7, 500); //Right now use magic values to set up the shop
        shopUpgradeModel.myInventory = shopModel.myInventory;
        EventQueue.eventQueue.AddEvent(new LoadPlayerInventory(shopModel));
        EventQueue.eventQueue.AddEvent(new LoadPlayerUpgradeInventoryEventData(shopUpgradeModel));


        EventQueue.eventQueue.Subscribe(EventType.BUYSTART, OnItemBuyBegin);
        EventQueue.eventQueue.Subscribe(EventType.BUYEND, OnItemBuyEnd);
        EventQueue.eventQueue.Subscribe(EventType.SELL, OnItemSold);
        EventQueue.eventQueue.Subscribe(EventType.UPGRADESTART, OnItemUpgradeStart);
        EventQueue.eventQueue.Subscribe(EventType.UPGRADEEND, OnItemUpgradeEnd);

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
        if (eventData is BuyStartEventData)
        {
            BuyStartEventData e = eventData as BuyStartEventData;
            if (HasEnoughMoney(e.price))
            {
                EventQueue.eventQueue.AddEvent(new ScreenGridChangeEventData());
                EventQueue.eventQueue.AddEvent(new BuyEndEventData(e.item, e.price));
            }
        }
        else
        {
            throw new System.ArgumentOutOfRangeException("eventData", "EventData is not BuyStartEventData");
        }
    }

    public void OnItemBuyEnd(EventData eventData)
    {
        if (eventData is BuyEndEventData)
        {
            BuyEndEventData e = eventData as BuyEndEventData;
            shopModel.myInventory.AddItem(e.item);
            ChangeMoneyAmount(-e.price);
            Debug.Log("Item added " + e.item.name);
        }
        else
        {
            throw new System.ArgumentOutOfRangeException("eventData", "EventData is not BuyEndEventData");
        }
    }

    public void OnItemSold(EventData eventData)
    {
        if (eventData is SellEventData)
        {
            SellEventData e = eventData as SellEventData;
            shopModel.myInventory.Remove(e.item);
            ChangeMoneyAmount(e.price);
            Debug.Log("Item sold " + e.item.name);
        }
        else
        {
            throw new System.ArgumentOutOfRangeException("eventData", "EventData is not SellEventData");
        }
    }

    public void OnItemUpgradeStart(EventData eventData)
    {
        if (eventData is UpgradeStartEventData)
        {
            UpgradeStartEventData e = eventData as UpgradeStartEventData;
            if (HasEnoughMoney(e.price))
            {
                EventQueue.eventQueue.AddEvent(new ScreenGridChangeEventData());
                EventQueue.eventQueue.AddEvent(new UpgradeEndEventData(e.item, e.price));
            }
        }
        else
        {
            throw new System.ArgumentOutOfRangeException("eventData", "EventData is not UpgradeStartEventData");
        }
    }

    public void OnItemUpgradeEnd(EventData eventData)
    {
        if (eventData is UpgradeEndEventData)
        {
            UpgradeEndEventData e = eventData as UpgradeEndEventData;
            if (e.item is IUpgradeable)
            {
                IUpgradeable u = e.item as IUpgradeable;
                u.Upgrade();
            }
        }
        else
        {
            throw new System.ArgumentOutOfRangeException("eventData", "EventData is not UpgradeEndEventData");
        }
    }
}
