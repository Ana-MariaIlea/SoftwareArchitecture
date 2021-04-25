using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionItemFactory : ItemAbstractFactory
{

    public PotionItemFactory() { }
    public override MyItem MakeItem()
    {
        int chance = Random.Range(1, 100);
        PotionItem newItem;

        if (chance < 30)
        {
            newItem = new PotionItem("Potion Weak", "items_" + Random.Range(73, 76), TypeOfItem.Potion, Random.Range(20, 50));
            newItem.SetPotionStats(Random.Range(20, 30), Random.Range(10, 20), Random.Range(4, 10));
            return newItem;
        }
        else if (chance < 70)
        {
            newItem = new PotionItem("Potion Good", "items_" + Random.Range(77, 79), TypeOfItem.Potion, Random.Range(50, 90));
            newItem.SetPotionStats(Random.Range(30, 45), Random.Range(20, 40), Random.Range(10, 20));
            return newItem;
        }
        else
        {
            newItem = new PotionItem("Potion Excelent", "items_" + Random.Range(79, 81), TypeOfItem.Potion, Random.Range(90, 110));
            newItem.SetPotionStats(Random.Range(50, 70), Random.Range(50, 70), Random.Range(20, 30));
            return newItem;
        }
    }
}
