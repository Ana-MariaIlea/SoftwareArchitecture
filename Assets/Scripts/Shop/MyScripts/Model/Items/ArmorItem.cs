using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorItem : MyItem, IUpgradeable, IArmorItem
{
    int physicalDamageReduction;
    int elementalDamageReduction;
    int staminIncrease;


    public ArmorItem(string name, string iconName, TypeOfItem type, int pbasePrice) : base(name, iconName, type, pbasePrice)
    { }

    public int PhysicalDamageReduction => physicalDamageReduction;

    public int ElementalDamageReduction => elementalDamageReduction;

    public int StaminIncrease => staminIncrease;

    public void SetArmorStats(int physical, int elemental, int stamina)
    {
        this.physicalDamageReduction = physical;
        this.elementalDamageReduction = elemental;
        this.staminIncrease = stamina;
    }

    public void Upgrade()
    {
        this.physicalDamageReduction += 10;
        this.elementalDamageReduction += 10;
        this.staminIncrease += 10;
    }


}
