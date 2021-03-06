﻿using System;
using System.Collections.Generic;

/// <summary>
///This class holds the model of our Shop. It contains an inventory, a price modifier, and an index to select the items.
///In its current setup, view and controller need to get data via polling. Advisable is, to apply observer pattern or
///set up an event system for better integration with View and Controller.
/// </summary>
public abstract class ShopModel
{
    //public Inventory inventory { get; } // Getter of the inventory, the views might need this to set up the display.
    public MyInventory myInventory { get; set; } // Getter of the inventory, the views might need this to set up the display.
    protected float priceModifier; //Modifies the item's price based on its base price
    protected int selectedItemIndex = 0; //selected item index


    //------------------------------------------------------------------------------------------------------------------------
    //                                                  ShopModel()
    //------------------------------------------------------------------------------------------------------------------------        
    public ShopModel(float pPriceModifier, int pItemCount, int pMoney)
    {
       // inventory = new Inventory(pItemCount, pMoney); 
        myInventory = new MyInventory(pItemCount); 
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  GetSelectedItem()
    //------------------------------------------------------------------------------------------------------------------------        
    //Returns the selected item
    public MyItem GetSelectedItem()
    {
        if (selectedItemIndex >= 0 && selectedItemIndex < myInventory.GetItemCount())
        {
            return myInventory.GetItemByIndex(selectedItemIndex);
        }
        else
        {
            throw new ArgumentOutOfRangeException("selectedItemIndex", "selectedItemIndex is out of range");
        }
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  SelectItemByIndex()
    //------------------------------------------------------------------------------------------------------------------------        
    //Attempts to select the item, specified by 'index', fails silently
    public void SelectItemByIndex(int index)
    {

        if (index >= 0 && index < myInventory.GetItemCount())
        {
            selectedItemIndex = index;
        }
        else
        {
            throw new ArgumentOutOfRangeException("index","Index is out of range");
        }
    }


    //------------------------------------------------------------------------------------------------------------------------
    //                                                  SelectItem(Item item)
    //------------------------------------------------------------------------------------------------------------------------
    public void SelectItem(MyItem item)
    {
        if (item != null)
        {
            int index = myInventory.GetItems().IndexOf(item);
            if (index >= 0)
            {
                selectedItemIndex = index;
            }
        }
    }
    //------------------------------------------------------------------------------------------------------------------------
    //                                                  UpgradeItem(MyItem item)
    //------------------------------------------------------------------------------------------------------------------------
    public void UpgradeItem(MyItem item)
    {
        if (item != null&&item is IUpgradeable)
        {
            IUpgradeable u = item as IUpgradeable;
            u.Upgrade();
        }
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  GetSelectedItemIndex()
    //------------------------------------------------------------------------------------------------------------------------
    //returns the index of the current selected item
    public int GetSelectedItemIndex()
    {
        return selectedItemIndex;
    }

    public void ReplaceInventory(MyInventory inv)
    {
        myInventory = inv;
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  Confirm()
    //------------------------------------------------------------------------------------------------------------------------        
    //Concrete classes to implement 
    public abstract void ConfirmSelectedItem();
}

