using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " New Equipment Object", menuName = "Inventory/Items/Equipment")]
public class EquipmentObject : ItemObject
{
    public float attackBonus;
    public float defenseBonus;
    private void Awake()
    {
        type = ItemType.Equipment;
    }
}
