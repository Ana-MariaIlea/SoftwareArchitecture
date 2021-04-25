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
            newItem = SetupNewArmorItem();
            return newItem;
        }
        else if (chance < chanceForWeapon)
        {
            WeaponItem newItem;
            newItem = SetupNewWaeponItem();
            return newItem;
        }
        else
        {
            PotionItem newItem;
            newItem = SetupNewPotionItem();
            return newItem;
        }

    }

    private static PotionItem SetupNewPotionItem()
    {
        PotionItem newItem;
        int chanceProcP = Random.Range(1, 100);
        if (chanceProcP < 30)
        {
            newItem = new PotionItem("Potion Weak", "items_" + Random.Range(73, 76), TypeOfItem.Potion, Random.Range(20, 50));
            newItem.SetPotionStats(Random.Range(20, 30), Random.Range(10, 20), Random.Range(4, 10));
            return newItem;
        }
        else if (chanceProcP < 70)
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

    private static WeaponItem SetupNewWaeponItem()
    {
        WeaponItem newItem;
        int chanceProcW = Random.Range(1, 100);
        if (chanceProcW < 30)
        {
            newItem = new WeaponItem("Weapon Weak", "items_" + Random.Range(73, 76), TypeOfItem.Weapon, Random.Range(20, 50));
            newItem.SetWeaponStats(Random.Range(20, 30), Random.Range(10, 20), Random.Range(4, 10));
            newItem.SetUpgradePrice(Random.Range(2, 10));
            return newItem;
        }
        else if (chanceProcW < 70)
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

    private static ArmorItem SetupNewArmorItem()
    {
        ArmorItem newItem;
        int chanceProcA = Random.Range(1, 100);
        if (chanceProcA < 30)
        {
            newItem = new ArmorItem("Armour Weak", "items_" + 106, TypeOfItem.Armor, Random.Range(20, 50));
            newItem.SetArmorStats(Random.Range(20, 30), Random.Range(10, 20), Random.Range(4, 10));
            newItem.SetUpgradePrice(Random.Range(2, 10));
            return newItem;
        }
        else if (chanceProcA < 55)
        {
            newItem = new ArmorItem("Armour Average", "items_" + 107, TypeOfItem.Armor, Random.Range(50, 90));
            newItem.SetArmorStats(Random.Range(30, 45), Random.Range(20, 40), Random.Range(10, 20));
            newItem.SetUpgradePrice(Random.Range(10, 20));
            return newItem;
        }
        else if (chanceProcA < 80)
        {
            newItem = new ArmorItem("Armour Good", "items_" + 108, TypeOfItem.Armor, Random.Range(90, 110));
            newItem.SetArmorStats(Random.Range(50, 70), Random.Range(50, 70), Random.Range(20, 30));
            newItem.SetUpgradePrice(Random.Range(20, 40));
            return newItem;
        }
        else
        {
            newItem = new ArmorItem("Armour Excelent", "items_" + 109, TypeOfItem.Armor, Random.Range(110, 150));
            newItem.SetArmorStats(Random.Range(80, 100), Random.Range(70, 90), Random.Range(30, 40));
            newItem.SetUpgradePrice(Random.Range(40, 60));
            return newItem;
        }

        return newItem;
    }
}
