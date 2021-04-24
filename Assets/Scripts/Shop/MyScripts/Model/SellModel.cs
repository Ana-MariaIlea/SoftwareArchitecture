using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellModel : ShopModel
{
    public SellModel(float pPriceModifier, int pItemCount, int pMoney) : base(pPriceModifier, pItemCount, pMoney)
    {

    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                 ConfirmSelectedItem()
    //------------------------------------------------------------------------------------------------------------------------        

    public override void ConfirmSelectedItem()
    {
        EventQueue.eventQueue.AddEvent(new ScreenGridChangeEventData());
        EventQueue.eventQueue.AddEvent(new SellEventData(myInventory.GetItemByIndex(selectedItemIndex), myInventory.GetItemByIndex(selectedItemIndex).price));
    }
}
