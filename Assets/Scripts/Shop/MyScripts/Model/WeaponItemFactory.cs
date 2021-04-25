using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItemFactory : ItemAbstractFactory
{
    int chanceForArmor = 30;
    int chanceForWeapon = 60;

    public WeaponItemFactory() { }
    public override MyItem MakeItem()
    {

        WeaponItem newItem = new WeaponItem("Weapon", "items_" + Random.Range(73, 81), TypeOfItem.Weapon, 80);
        newItem.SetWeaponStats(Random.Range(60, 100), Random.Range(50, 70), Random.Range(10, 15));
        newItem.SetUpgradePrice(Random.Range(10, 30));
        return newItem;

    }
}
