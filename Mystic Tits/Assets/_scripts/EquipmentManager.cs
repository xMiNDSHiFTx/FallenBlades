﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquipmentManager : MonoBehaviour 
{
    #region Singleton
    public static EquipmentManager instance;
    void Awake()
    {
        instance = this;    
    }
    #endregion

    Equipment[] currentEquipment;

    public delegate void OnEquipmentChange(Equipment newItem, Equipment oldItem);
    public OnEquipmentChange onEquipmentChange;

    Inventory inventory;

    #region Unity Methods
    void Start()
    {
        inventory = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
            
    }

    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if(currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if(onEquipmentChange != null)
        {
            onEquipmentChange.Invoke(newItem, oldItem);
        }
        currentEquipment[slotIndex] = newItem;
    }

    public void Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
                                    
            currentEquipment[slotIndex] = null;

            if (onEquipmentChange != null)
            {
                onEquipmentChange.Invoke(null, oldItem);
            }
        }
    }

    public void UnequipAll ()
    {
        for(int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }
    #endregion
}
