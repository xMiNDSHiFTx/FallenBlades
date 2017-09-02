using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item 
{
    #region Variables
    public EquipmentSlot equipSlot;

    public int armorModifier;
    public int damageModifier;

    #endregion

    #region Unity Methods
    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();

    }
    #endregion
}

public enum EquipmentSlot { Head, Chest, Greaves, Weapon, Shield, Feet}
