using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory
{
    int chanceForArmor=30;
    int chanceForWeapon=60;

    public ItemFactory() { }
    public MyItem MakeItem()
    {
        int chance = Random.Range(1, 100);
        if (chance < chanceForArmor)
        {
            ArmorItem newItem = new ArmorItem("armour", "items_" + Random.Range(106, 109), TypeOfItem.Armor, 100);
            newItem.SetArmorStats(100, 80, 20);
            return newItem;
        }
        else if (chance < chanceForWeapon)
        {
            WeaponItem newItem = new WeaponItem("Weapon", "items_" + Random.Range(73, 81), TypeOfItem.Weapon, 80);
            newItem.SetWeaponStats(80, 60, 20);
            return newItem;
        }
        else
        {
            PotionItem newItem = new PotionItem("Potion", "items_" + Random.Range(130, 136), TypeOfItem.Potion, 50);
            newItem.SetPotionStats(40, 30, 10);
            return newItem;
        }

    }
}
