using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquip : MonoBehaviour
{
    private Equipment Equipment;
    private int SlotIndex;



    void Start()
    {
        Equipment= GameObject.Find("/Entities/Player/Equipment").gameObject.GetComponent<Equipment>();
        SlotIndex = transform.GetSiblingIndex();

    }


    public void SlotEquipItem()
    {
        Equipment.SlotPressed(SlotIndex, false);

    }
}
