using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerEquipment PlayerEquipment;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            GameObject Slot = PlayerEquipment.GetAvailableSlot();
            if(Slot != null)
            {
                PlayerEquipment.InsertItem(Slot, collision.gameObject.GetComponent<Item>().ItemID);
                Destroy(collision.gameObject);
            }

        }
    }

    public void ColliderSetActive(bool Act)
    {
        gameObject.GetComponent<Collider2D>().enabled = Act;
    }




}
