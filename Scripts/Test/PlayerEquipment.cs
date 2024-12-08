using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
using System.IO;
using System.Collections;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] ItemPicker ItemPicker;
    [SerializeField] ItemManager ItemManager;

    [SerializeField] GameObject InventoryOBJ;
    [SerializeField] GameObject EquipmentSlotOBJ;


    GameObject EquipmentSlots;
    GameObject InventorySlots;
    [SerializeField] int MaxColumn, MaxRow, RowGapDiff, ColumnGapDiff;
    [SerializeField] Vector2 StartingCoordinates;

    [SerializeField] GameObject InventoryButton;
    [SerializeField] Sprite[] InvBtnSprites;
    [SerializeField] Sprite[] EqpSlotSprites;
    [SerializeField] Sprite[] InvSlotSprites;


    GameObject ActiveEqpSlot;
    GameObject ActiveInvSlot;
    GameObject BaseItem;
    bool[] AllSlots; 
    bool InvActive = false;

    [SerializeField] SavedData SavedData;


    //column value increases, row value decreases
    void Awake()
    {

        EquipmentSlots = EquipmentSlotOBJ.transform.Find("Slots").gameObject;
        InventorySlots = InventoryOBJ.transform.Find("InventorySlots").gameObject;
        BaseItem = transform.GetChild(0).gameObject;
        GenerateInventorySlots();
        RegisterEqpSlots();
        ItemManager.SetItemList();
        SetUpInventory(SavedData.LoadInGameData().InventoryInfo);


    }

    void RegisterEqpSlots()
    {
        AllSlots = new bool[EquipmentSlots.transform.childCount + InventorySlots.transform.childCount];

        for(int i = 0;i< EquipmentSlots.transform.childCount; i++)
        {

           
            
                AllSlots[EquipmentSlots.transform.GetChild(i).gameObject.GetComponent<Slot>().ID] = (EquipmentSlots.transform.GetChild(i).transform.childCount > 0);
            
            
        }

        for (int i = 0; i < InventorySlots.transform.childCount; i++)
        {

          
            
                AllSlots[InventorySlots.transform.GetChild(i).gameObject.GetComponent<Slot>().ID] = (InventorySlots.transform.GetChild(i).transform.childCount > 0);
            

        }


    }

    void GenerateInventorySlots()
    {
        GameObject BaseSlot = InventorySlots.transform.GetChild(0).gameObject;

        int SlotCurrCount = 5;
        float YPos = StartingCoordinates.y, XPOs = StartingCoordinates.x;
        for (int Row = 0; Row < MaxRow; Row++)
        {
            for (int Col = 0; Col < MaxColumn; Col++)
            {
                SlotCurrCount++;
                GameObject Slot = Instantiate(BaseSlot);
                Slot.name = "Slot" + SlotCurrCount;
                Slot.transform.SetParent(InventorySlots.transform);
                Slot.GetComponent<Slot>().ID = SlotCurrCount - 1;
                Slot.transform.localPosition = new Vector3(XPOs, YPos, BaseSlot.transform.position.z);
                Slot.transform.rotation = BaseSlot.transform.rotation;
                Slot.transform.localScale = BaseSlot.transform.localScale;
                XPOs += ColumnGapDiff;
                    
            }
            XPOs = StartingCoordinates.x;
            YPos -= RowGapDiff;
        }
        Destroy(BaseSlot);
    }

    GameObject FindSlot(int SlotIndex)
    {
        if(SlotIndex < 5)
        {
            return EquipmentSlots.transform.GetChild(SlotIndex).gameObject;
        }
        return InventorySlots.transform.GetChild(SlotIndex).gameObject;
    }

    public void InsertItem(GameObject Slot, int ItemID)
    {
  
            GameObject Item = Instantiate(BaseItem);
            Item.transform.SetParent(Slot.transform);
            Item.transform.position = new Vector3(Slot.transform.position.x, Slot.transform.position.y, Slot.transform.position.z);
            Item.name = ItemID.ToString();
            Item.GetComponent<Image>().sprite = ItemManager.GetSprite(ItemID);
            Item.SetActive(true);
            AllSlots[Slot.GetComponent<Slot>().ID] = true;
            
        
    }

    public void SetUpInventory(InventoryInfo InventoryInfo)
    {




        



        foreach (ItemInfo Item in InventoryInfo.ItemInfo)
        {
            Debug.Log(Item.SlotIndex + ""+ Item.ItemID);
            InsertItem(FindSlot(Item.SlotIndex), Item.ItemID);


        }
    }

    public GameObject GetAvailableSlot()
    {
        for (int i = 0; i < EquipmentSlots.transform.childCount; i++)
        {
            if (!AllSlots[EquipmentSlots.transform.GetChild(i).gameObject.GetComponent<Slot>().ID])
            {
                return EquipmentSlots.transform.GetChild(i).gameObject;
            }
        }

        for (int i = 0; i < InventorySlots.transform.childCount; i++)
        {
            if (!AllSlots[InventorySlots.transform.GetChild(i).gameObject.GetComponent<Slot>().ID])
            {
                return InventorySlots.transform.GetChild(i).gameObject;
            }
        }
        return null;
    }

    public void InventerySetActive()
    {
        InvActive = !InvActive;

        InventoryOBJ.SetActive(InvActive);

        InventoryButton.GetComponent<Image>().sprite = InvBtnSprites[BooltoInt(InvActive)];

        if (!InvActive && ActiveInvSlot != null)
        {
            UnSetInvSlot();
        }
    }

    int BooltoInt(bool Status)
    {
        if (Status)
        {
            return 1;
        }
        return 0;
    }

    public bool GetInvActive()
    {
        return InvActive;
    }

    public void SetEqpSlot(GameObject loc_gameObject)
    {
        if (ActiveEqpSlot != null)
        {
            if (ActiveEqpSlot.GetComponent<Slot>().ID == loc_gameObject.GetComponent<Slot>().ID)
            {
                UnSetEqpSlot();
                return;
            }
            else
            {
                UnSetEqpSlot();
                
            }
        }

        ActiveEqpSlot = loc_gameObject;
        ActiveEqpSlot.GetComponent<Image>().sprite = EqpSlotSprites[1];

        if (ActiveEqpSlot.transform.childCount > 0)
        {
            Equip();
        }
        
    }

    public void UnSetEqpSlot()
    {
        ActiveEqpSlot.GetComponent<Image>().sprite = EqpSlotSprites[0];
        ActiveEqpSlot = null;
        ItemManager.UnSetComponents();
    }

    void Equip()
    {
        ItemManager.SetComponents(int.Parse(ActiveEqpSlot.transform.GetChild(0).name));
    }

    public void SetInvSlot(GameObject loc_gameObject)
    {
        if (ActiveInvSlot != null)
        {
            if (ActiveInvSlot.GetComponent<Slot>().ID == loc_gameObject.GetComponent<Slot>().ID)
            {
                UnSetInvSlot();
                
                return;
            }
            else
            {
                UnSetInvSlot();

            }
        }

        ActiveInvSlot = loc_gameObject;
        ActiveInvSlot.GetComponent<Image>().sprite = InvSlotSprites[1];

    }

    public void UnSetInvSlot()
    {

        ActiveInvSlot.GetComponent<Image>().sprite = InvSlotSprites[0];
        ActiveInvSlot = null;

    }

    public void RegisterChildinArray(GameObject loc_gameObject)
    {
        AllSlots[loc_gameObject.GetComponent<Slot>().ID] = (loc_gameObject.transform.childCount > 0);
    }



}
