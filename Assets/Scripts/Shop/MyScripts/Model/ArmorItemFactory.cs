using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorItemFactory : ItemAbstractFactory
{
    int chanceForArmor = 30;
    int chanceForWeapon = 60;

    public ArmorItemFactory() { }
    public override MyItem MakeItem()
    {
        ArmorItem newItem = new ArmorItem("Armour", "items_" + Random.Range(106, 109), TypeOfItem.Armor, 100);
        newItem.SetArmorStats(Random.Range(80, 100), Random.Range(70, 90), Random.Range(10, 30));
        newItem.SetUpgradePrice(Random.Range(20,50));
        return newItem;
    }
}
