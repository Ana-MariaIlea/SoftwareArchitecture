using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory:ItemAbstractFactory
{
    int chanceForArmor=30;
    int chanceForWeapon=60;

    public ItemFactory() { }
    public override MyItem MakeItem()
    {
        int chance = Random.Range(1, 100);
        if (chance < chanceForArmor)
        {
            ArmorItem newItem;
            newItem = SetupNewArmorItem(chance);
            return newItem;
        }
        else if (chance < chanceForWeapon)
        {
            WeaponItem newItem = new WeaponItem("Weapon", "items_" + Random.Range(73, 81), TypeOfItem.Weapon, 80);
            newItem.SetWeaponStats(80, 60, 20);
            newItem.SetUpgradePrice(30);
            return newItem;
        }
        else
        {
            PotionItem newItem = new PotionItem("Potion", "items_" + Random.Range(130, 136), TypeOfItem.Potion, 50);
            newItem.SetPotionStats(40, 30, 10);
            return newItem;
        }

    }

    private static ArmorItem SetupNewArmorItem(int chance)
    {
        ArmorItem newItem;
        int chanceProc = Random.Range(1, 100);
        if (chanceProc < 30)
        {
            newItem = new ArmorItem("Armour", "items_" + 106, TypeOfItem.Armor, Random.Range(20, 50));
            newItem.SetArmorStats(Random.Range(20, 30), Random.Range(10, 20), Random.Range(4, 10));
            newItem.SetUpgradePrice(Random.Range(2, 10));
        }
        else if (chance < 55)
        {
            newItem = new ArmorItem("Armour", "items_" + 107, TypeOfItem.Armor, Random.Range(50, 90));
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
