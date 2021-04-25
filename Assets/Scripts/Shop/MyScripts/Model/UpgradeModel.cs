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
        if (myInventory.GetItemByIndex(selectedItemIndex) is IUpgradeable)
        {
            EventQueue.eventQueue.AddEvent(new ScreenGridChangeEventData());
            IUpgradeable i = myInventory.GetItemByIndex(selectedItemIndex) as IUpgradeable;
            EventQueue.eventQueue.AddEvent(new UpgradeStartEventData(myInventory.GetItemByIndex(selectedItemIndex), i.UpgradePrice));
        }
    }
}
