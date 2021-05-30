using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Item[] items;
    public int gold;

    private void Awake()
    {
        items = DataHolder.items;
        gold = DataHolder.gold;
    }
}
