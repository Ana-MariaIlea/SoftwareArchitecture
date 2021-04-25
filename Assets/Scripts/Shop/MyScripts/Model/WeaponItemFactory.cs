using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItemFactory : ItemAbstractFactory
{

    public WeaponItemFactory() { }
    public override MyItem MakeItem()
    {
        int chance = Random.Range(1, 100);
        WeaponItem newItem;

        if (chance < 30)
        {
            newItem = new WeaponItem("Weapon Weak", "items_" + Random.Range(73, 76), TypeOfItem.Weapon, Random.Range(20, 50));
            newItem.SetWeaponStats(Random.Range(20, 30), Random.Range(10, 20), Random.Range(4, 10));
            newItem.SetUpgradePrice(Random.Range(2, 10));
            return newItem;
        }
        else if (chance < 70)
        {
            newItem = new WeaponItem("Weapon Good", "items_" + Random.Range(77, 79), TypeOfItem.Weapon, Random.Range(50, 90));
            newItem.SetWeaponStats(Random.Range(30, 45), Random.Range(20, 40), Random.Range(10, 20));
            newItem.SetUpgradePrice(Random.Range(10, 20));
            return newItem;
        }
        else 
        {
            newItem = new WeaponItem("Weapon Excelent", "items_" + Random.Range(79, 81), TypeOfItem.Weapon, Random.Range(90, 110));
            newItem.SetWeaponStats(Random.Range(50, 70), Random.Range(50, 70), Random.Range(20, 30));
            newItem.SetUpgradePrice(Random.Range(20, 40));
            return newItem;
        }

    }
}
