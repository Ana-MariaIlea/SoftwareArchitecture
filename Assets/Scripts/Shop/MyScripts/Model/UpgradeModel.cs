using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeModel : BuyModel
{
    public UpgradeModel(float pPriceModifier, int pItemCount, int pMoney) : base(pPriceModifier, pItemCount, pMoney)
    {

    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                 ConfirmSelectedItem()
    //------------------------------------------------------------------------------------------------------------------------        

    public override void ConfirmSelectedItem()
    {
        EventQueue.eventQueue.AddEvent(new ScreenGridChangeEventData());
        EventQueue.eventQueue.AddEvent(new UpgradeStartEventData(myInventory.GetItemByIndex(selectedItemIndex), myInventory.GetItemByIndex(selectedItemIndex).price));
    }
}
