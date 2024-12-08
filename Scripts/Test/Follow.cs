using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{


    int RecieverSlotID = -1;
    int SenderSlotID = -1;



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Slot>())
        { 
            int ID = collision.gameObject.GetComponent<Slot>().ID;
            if (ID != SenderSlotID)
            {
                RecieverSlotID = ID;

            }
        }
        
        //Debug.Log("Collide");
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (RecieverSlotID != -1)
        {
            RecieverSlotID = -1;
        }

        //Debug.Log("Collide");
    }

    public void SenderID(int ID)
    {
        SenderSlotID = ID;
    }
}
