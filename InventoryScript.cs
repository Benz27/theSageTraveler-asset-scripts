using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Equipment Equipment;
    private int SlotIndex;

    void Start()
    {
        Equipment = GameObject.Find("/Entities/Player/Equipment").gameObject.GetComponent<Equipment>();
        SlotIndex = transform.GetSiblingIndex();
    }

    public void InvSlotPressed()
    {
        Equipment.SlotPressed(SlotIndex, true);


    }



}
