﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int money;
    public ShopModel ShopModel => shopModel; //A getter to access shopModel.

    private ShopModel shopModel; //Model in MVC pattern

    // Start is called before the first frame update
    void Start()
    {
        shopModel = new BuyModel(2f, 16, 500); //Right now use magic values to set up the shop
    }

    public void ChangeMoneyAmount(int amount)
    {
        money += amount;
    }
}
