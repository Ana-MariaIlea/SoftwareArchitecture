using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Shop 
{
    public MyInventory inventory { get; }
    public MyInventory playerInventory;
    public MyInventory currentInventory;
    protected int selectedItemIndex = 0; 


    //------------------------------------------------------------------------------------------------------------------------
    //                                                  ShopModel()
    //------------------------------------------------------------------------------------------------------------------------        
    public Shop(int pItemCount)
    {
        inventory = new MyInventory(pItemCount);
    }

    public void SetCurrentInventory(MyInventory inv)
    {
        currentInventory = inv;
    }
    //------------------------------------------------------------------------------------------------------------------------
    //                                                  GetSelectedItem()
    //------------------------------------------------------------------------------------------------------------------------        
    //Returns the selected item
    public MyItem GetSelectedItem()
    {
        if (selectedItemIndex >= 0 && selectedItemIndex < currentInventory.GetItemCount())
        {
            return currentInventory.GetItemByIndex(selectedItemIndex);
        }
        else
        {
            return null;
        }
    }

 

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  SelectItemByIndex()
    //------------------------------------------------------------------------------------------------------------------------        
    //Attempts to select the item, specified by 'index', fails silently
    public void SelectItemByIndex(int index)
    {
        if (index >= 0 && index < currentInventory.GetItemCount())
        {
            selectedItemIndex = index;
        }
    }


    //------------------------------------------------------------------------------------------------------------------------
    //                                                  SelectItem(Item item)
    //------------------------------------------------------------------------------------------------------------------------
    //Attempts to select the given item, fails silently
    public void SelectItem(MyItem item)
    {
        if (item != null)
        {
            int index = currentInventory.GetItems().IndexOf(item);
            if (index >= 0)
            {
                selectedItemIndex = index;
            }
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

    public abstract void ConfirmActionSelectedItem();
   
}
