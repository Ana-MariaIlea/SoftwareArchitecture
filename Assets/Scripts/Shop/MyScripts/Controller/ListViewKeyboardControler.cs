using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListViewKeyboardControler : ShopController
{

    private int currentItemIndex = 0;//The current item index is changed whenever the focus is moved with keyboard keys

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  Initialize()
    //------------------------------------------------------------------------------------------------------------------------
    //Override Initialize to set up additional information needed by this concrete controller: number of columns in the view
    public override ShopController Initialize(ShopModel pShopModel)
    {
        base.Initialize(pShopModel);//Call base.Initialize to set up the model
        currentItemIndex = model.GetSelectedItemIndex();//Synchronize the current item index with the model
        return this;
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  HandleInput()
    //------------------------------------------------------------------------------------------------------------------------
    //Currently hardcoded to AWSD to move focus and K to confirm the selected item
    public override void HandleInput()
    {
        //Move the focus to the left if possible
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentItemIndex--;
            if (currentItemIndex < 0)
            {
                currentItemIndex = 0;
            }
            EventQueue.eventQueue.AddEvent(new ScreenGridChangeEventData());
        }

        //Move the focus to the right if possible
        if (Input.GetKeyDown(KeyCode.S))
        {
            currentItemIndex++;
            if (currentItemIndex >= this.Model.myInventory.GetItemCount())
            {
                currentItemIndex = this.Model.myInventory.GetItemCount() - 1;
            }
            EventQueue.eventQueue.AddEvent(new ScreenGridChangeEventData());
        }

        //Select the item
        SelectItemByIndex(currentItemIndex);

        //Confirm the selected item when K is pressed
        if (Input.GetKeyDown(KeyCode.B))
        {
            ConfirmSelectedItem();
        }
    }
}
