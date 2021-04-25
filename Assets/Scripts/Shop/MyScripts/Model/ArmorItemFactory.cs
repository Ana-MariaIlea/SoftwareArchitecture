using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorItemFactory : ItemAbstractFactory
{

    public ArmorItemFactory() { }
    public override MyItem MakeItem()
    {
        int chance = Random.Range(1, 100);
        ArmorItem newItem;
        if (chance < 30)
        {
            newItem = new ArmorItem("Armour", "items_" + 106, TypeOfItem.Armor, Random.Range(20, 50));
            newItem.SetArmorStats(Random.Range(20, 30), Random.Range(10, 20), Random.Range(4, 10));
            newItem.SetUpgradePrice(Random.Range(2, 10));
        }
        else if (chance < 55)
        {
            newItem = new ArmorItem("Armour", "items_" +107, TypeOfItem.Armor, Random.Range(50, 90));
            newItem.SetArmorStats(Random.Range(30, 45), Random.Range(20, 40), Random.Range(10, 20));
            newItem.SetUpgradePrice(Random.Range(10, 20));
        }
        else if (chance < 80)
        {
            newItem = new ArmorItem("Armour", "items_" + 108, TypeOfItem.Armor, Random.Range(90, 110));
            newItem.SetArmorStats(Random.Range(50, 70), Random.Range(50, 70), Random.Range(20, 30));
            newItem.SetUpgradePrice(Random.Range(20, 40));
        }
        else
        {
            newItem = new ArmorItem("Armour", "items_" + 109, TypeOfItem.Armor, Random.Range(110, 150));
            newItem.SetArmorStats(Random.Range(80, 100), Random.Range(70, 90), Random.Range(30, 40));
            newItem.SetUpgradePrice(Random.Range(40, 60));
        }
        return newItem;
    }
}
