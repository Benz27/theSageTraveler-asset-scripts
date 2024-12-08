using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    private PlayerEquipment Equipment;

    public string SlotType;
    public int Quantity;
    public int ItemID;
    public string Type;
    private bool picked = false;

    private void Start()
    {
        GameObject Player = GameObject.Find("/Entities/Player").gameObject;
        Equipment = Player.transform.Find("Equipment").gameObject.GetComponent<PlayerEquipment>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            
            if (!picked)
            {
             
                picked = true;
                //Equipment.PickUpItem(ItemID, Quantity, Type, SlotType);
                Destroy(gameObject);
            }
           
        }
    }
}
