using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionItem : MyItem, IUpgradeable, IPotionItem
{
    int healthChange;
    int staminaChange;
    int effectTime;

    public PotionItem(string name, string iconName, TypeOfItem type, int pbasePrice) : base(name, iconName, type, pbasePrice)
    {
    }

    public int HealthChange => healthChange;

    public int StaminaChange => staminaChange;

    public int EffectTime => effectTime;

    public void SetPotionStats(int health, int stamina, int time)
    {
        this.healthChange = health;
        this.staminaChange = stamina;
        this.effectTime = time;
    }

    public void Upgrade()
    {
        this.healthChange += 15;
        this.staminaChange += 10;
        this.effectTime += 5;
    }



}
