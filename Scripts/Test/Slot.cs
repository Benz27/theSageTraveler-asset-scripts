using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Slot : MonoBehaviour
{

    public int ID;
    TouchInput TouchInput;
    ItemOnDrag ItemOnDrag;
    [SerializeField] GameObject ItemOnDragOBJ;
    [SerializeField] PlayerEquipment PlayerEquipment;
    [SerializeField] GameObject HomeOBJ;
    Vector2 mousePosRelToCam;

    [SerializeField] bool isEqpSlot = false;

    private void Awake()
    {
        ItemOnDrag = ItemOnDragOBJ.GetComponent<ItemOnDrag>();
        TouchInput = gameObject.GetComponent<TouchInput>();
    }

    public void Tapped()
    {
        if (isEqpSlot)
        {
            PlayerEquipment.SetEqpSlot(gameObject);
            return;
        }
        PlayerEquipment.SetInvSlot(gameObject);

    }


    public void Holding()
    {

        if (ItemOnDrag.GetSenderID() == -1 && transform.childCount > 0 && PlayerEquipment.GetInvActive())
        {
            ItemOnDrag.SetSenderID(ID);
            transform.SetParent(ItemOnDragOBJ.transform);
            //transform.GetChild(0).transform.position = new Vector2(transform.position.x, transform.position.y);
        }

        if (ItemOnDrag.GetSenderID() == ID)
        {
            if (!PlayerEquipment.GetInvActive())
            {
                CancelPlace();
                return;
            }


            mousePosRelToCam = TouchInput.TouchPosRelToCam;
            //ControllerObj.transform.localPosition = finalPos;
            transform.GetChild(0).transform.position = new Vector3(mousePosRelToCam.x, mousePosRelToCam.y, transform.GetChild(0).position.z);

        }

    }

    public void Place()
    {
        transform.SetParent(HomeOBJ.transform);
        if (transform.childCount > 0 && PlayerEquipment.GetInvActive())
        {
            ItemOnDrag.ResetSenderID();
            Collider2D collider = Physics2D.OverlapPoint(TouchInput.TouchPosRelToCam);
            Transform item = transform.GetChild(0);
            if (collider != null && collider.gameObject.GetComponent<Slot>())
            {
                Slot cSlotComp = collider.gameObject.GetComponent<Slot>();

                if (cSlotComp.ID != ID)
                {
                    if(collider.transform.childCount > 0)
                    {
                        Transform citem = collider.transform.GetChild(0);
                        citem.SetParent(transform);
                        citem.position = new Vector3(transform.position.x, transform.position.y, citem.position.z);
                        PlayerEquipment.RegisterChildinArray(transform.gameObject);
                    }

                    item.SetParent(collider.transform);
                    item.position = new Vector3(collider.transform.position.x, collider.transform.position.y, item.position.z);
                    PlayerEquipment.RegisterChildinArray(collider.gameObject);
                    return;
                }
            }

            item.SetParent(transform);
            item.position = new Vector3(transform.position.x, transform.position.y, item.position.z);
            
        }


    }

    void CancelPlace()
    {
        transform.SetParent(HomeOBJ.transform);
        ItemOnDrag.ResetSenderID();
        Transform item = transform.GetChild(0);
        item.SetParent(transform);
        item.position = new Vector3(transform.position.x, transform.position.y, item.position.z);
    }


}
