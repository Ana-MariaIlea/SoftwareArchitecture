using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfItem
{
    Weapon,
    Armor,
    Potion
}

public class MyItem : IBreakable
{
    public string name;
    public string iconName;
    public TypeOfItem type;

    public int price;

    int duralbility;


    public MyItem(string name, string iconName, TypeOfItem type, int pbasePrice)
    {
        this.name = name;
        this.iconName = iconName;
        this.type = type;
        this.price = pbasePrice;
    }

    public int Durability => throw new System.NotImplementedException();

    public void Deteriorate()
    {
        duralbility--;
    }

    public void SetDurability(int d)
    {
        duralbility=d;
    }

}
