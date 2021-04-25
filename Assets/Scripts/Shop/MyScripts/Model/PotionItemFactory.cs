using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionItemFactory : ItemAbstractFactory
{

    public PotionItemFactory() { }
    public override MyItem MakeItem()
    {
        PotionItem newItem = new PotionItem("Potion", "items_" + Random.Range(130, 136), TypeOfItem.Potion, 50);
        newItem.SetPotionStats(Random.Range(30, 50), Random.Range(50, 70), Random.Range(5, 10));
        return newItem;
    }
}
