using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnDrag : MonoBehaviour
{
    int SenderSlotID = -1;

   [NonSerialized] public Vector3 DefPosition;


    private void Awake()
    {
        DefPosition = transform.position;
    }



    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.GetComponent<Slot>())
    //    {
    //        int ID = collision.gameObject.GetComponent<Slot>().ID;
    //        if (ID != SenderSlotID)
    //        {
    //            RecieverSlotID = ID;

    //        }
    //    }

    //}


    //void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (RecieverSlotID != -1)
    //    {
    //        RecieverSlotID = -1;
    //    }

    //}








    public void SetSenderID(int ID)
    {
        SenderSlotID = ID;
    }

    public int GetSenderID()
    {
        return SenderSlotID;
    }

    public void ResetSenderID()
    {
        SenderSlotID = -1;
    }


}
