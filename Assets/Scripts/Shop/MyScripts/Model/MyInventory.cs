using System;
using System.Collections;
using System.Collections.Generic;

public class MyInventory
{
    private List<MyItem> itemList = new List<MyItem>(); //Items in the inventory
    private ItemFactory factory = new ItemFactory();
    //Set up the inventory with item count and money
    public MyInventory(int pItemCount)
    {
        PopulateInventory(pItemCount);
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  GetItems()
    //------------------------------------------------------------------------------------------------------------------------        
    //Returns a list with all current items in the shop.
    public List<MyItem> GetItems()
    {
        return new List<MyItem>(itemList); 
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  GetItemCount()
    //------------------------------------------------------------------------------------------------------------------------        
    //Returns the number of items
    public int GetItemCount()
    {
        return itemList.Count;
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  GetItemByIndex()
    //------------------------------------------------------------------------------------------------------------------------        
    //Attempts to get an item, specified by index, returns null if unsuccessful. Depends on how you set up your shop, it might be
    //a good idea to return a copy of the original item.
    public MyItem GetItemByIndex(int index)
    {
        if (index >= 0 && index < itemList.Count)
        {
            return itemList[index];
        }
        else
        {
            return null;
        }
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                  GetItemByIndex()
    //------------------------------------------------------------------------------------------------------------------------        
    //Returns a list of items for a specific type
    public List<MyItem> GetItemsByType(TypeOfItem type)
    {
        List<MyItem> customList = new List<MyItem>();
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].type == type)
            {
                customList.Add(itemList[i]);
            }
        }

        return customList;
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                 AddItem()
    //------------------------------------------------------------------------------------------------------------------------        
    //Adds an item to the inventory's item list.
    public void AddItem(MyItem item)
    {
        itemList.Add(item);
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                 RemoveItem()
    //------------------------------------------------------------------------------------------------------------------------        
    //Attempts to remove an item, fails silently.
    public void Remove(MyItem item)
    {
        if (itemList.Contains(item))
        {
            itemList.Remove(item);
        }
    }

    //------------------------------------------------------------------------------------------------------------------------
    //                                                 RemoveItemByIndex()
    //------------------------------------------------------------------------------------------------------------------------        
    //Attempts to remove an item, specified by index, fails silently.
    public void RemoveItemByIndex(int index)
    {
        if (index >= 0 && index < itemList.Count)
        {
            itemList.RemoveAt(index);
        }
    }


    //------------------------------------------------------------------------------------------------------------------------
    //                                                  PopulateInventory()
    //------------------------------------------------------------------------------------------------------------------------
    private void PopulateInventory(int itemCount)
    {
        
        for (int index = 0; index < itemCount; index++)
        {
            MyItem item = factory.MakeItem();
            itemList.Add(item);
        }
    }
}
