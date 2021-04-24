using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public ShopModel ShopModel => shopModel; //A getter to access shopModel.

    private ShopModel shopModel; //Model in MVC pattern

    // Start is called before the first frame update
    void Start()
    {
        shopModel = new BuyModel(2f, 16, 500); //Right now use magic values to set up the shop
        EventQueue.eventQueue.AddEvent(new LoadShopInventory(shopModel));
        EventQueue.eventQueue.Subscribe(EventType.BUYEND, OnRemoveItemFromInventory);
    }

    public void OnRemoveItemFromInventory(EventData eventData)
    {
        BuyEndEventData e = eventData as BuyEndEventData;
        shopModel.myInventory.Remove(e.item);
        Debug.Log("Item added " + e.item.name);

    }
}
