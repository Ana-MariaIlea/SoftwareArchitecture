using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int money;
    public MyInventory inventory;

    public void ChangeMoneyAmount(int amount)
    {
        money += amount;
    }
}
