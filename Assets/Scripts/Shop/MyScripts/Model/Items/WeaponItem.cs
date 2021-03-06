﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MyItem, IUpgradeable, IWeaponItem
{
    int physicalAttack;
    int elementalAttack;
    int damageReducedWhenBock;
    int upgradePrice;


    public WeaponItem(string name, string iconName, TypeOfItem type, int pbasePrice) : base(name, iconName, type, pbasePrice)
    {
    }

    public int PhysicalAttack => physicalAttack;

    public int ElementalAttack => elementalAttack;

    public int DamageReducedWhenBock => damageReducedWhenBock;
    public int UpgradePrice => upgradePrice;

    public void SetWeaponStats(int physical, int elemental, int block)
    {
        this.physicalAttack = physical;
        this.elementalAttack = elemental;
        this.damageReducedWhenBock = block;
    }
    public void SetUpgradePrice(int p)
    {
        this.upgradePrice = p;
    }
    public void Upgrade()
    {
        this.physicalAttack += 15;
        this.elementalAttack += 15;
        this.damageReducedWhenBock += 5;
    }

}
