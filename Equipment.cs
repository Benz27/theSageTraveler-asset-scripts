using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
using System.IO;
public class Equipment : MonoBehaviour
{
    // Start is called before the first frame update
    [NonSerialized] public int[] IntenvoryItemID = new int[10];
    [NonSerialized] public int[] ItemSlotID = new int[10];
    private int SlotInUse = -1;
    private int InventorySlotInUse = -1;
    private int PrevSlotInUse;
    [NonSerialized] public int ItemSelectedID;
    [NonSerialized] public int InventoryItemSelectedID;
    private Image[] SlotSprites = new Image[10];
    private Image[] SlotOutlineSprites = new Image[10];
    public Image InventoryLogoSprite;
    public Sprite DefaultSlotSprite;
    public GameObject ItemEquipped;
    public Animator Animator;
    public Sprite[] SlotTemplate;
    public Sprite[] InvButtonTemplates;

    public GameObject PlayerInventorySlot;
    public GameObject PlayerInventoryEquipSlot;

    private Sprite sprite;
    public BoxCollider2D HandWeaponHitBox;
    public GameObject AttackButton;
    private bool InventoryActive = false;
    private bool Attack = false;
    public GameObject Inventory;
    public GameObject GamgeObject_Sword;
    private GameObject CurrentEquippedGameObject;
    private HandWeaponProperties HandWeaponProperties;
    private bool AttackCooldownFinished = true;
    private int AttackCooldown;
    private int AttackCooldownInterval = 5;

    Dictionary<int, string[]> ItemProperties; //<ItemID, [Name, Type, SlotType, ?Damage]>
    Dictionary<int, string[]> InventorySlot = new Dictionary<int, string[]>(); //<ItemInstanceID, [ItemID, Quantity]>

    Dictionary<string, Sprite> ItemSprites = new Dictionary<string, Sprite>(); //<ItemInstanceID, [ItemID, Quantity]>

    Dictionary<string, Vector2[]> PolygonColliderPathsList = new Dictionary<string, Vector2[]>();


    public class PolygonPath
    {
        public float[][] pathArr;
    }
    public PolygonPath currPolyPath = new PolygonPath();

    void Awake()
    {
        SetSlots();
        ItemProperties = new Dictionary<int, string[]>(){
                //Name, Type, Slot Type, Sprite filename without file extension, Weapon Damage(Optional), Close Weapon X Scale(Optional),
                //Close Weapon Y Scale(Optional), Cooldown, LastingAttack, Host GameObject Name
                {4, new string[] { "Bow", "RangeWeapon", "Single", "bow", "15","30","10"}},
                {2, new string[] { "Sword", "HandWeapon", "Single", "sword", "15", "0.75", "0.9615385", "0", "10","GamgeObject_Sword","sword"}},
                {1, new string[] { "DiamondSword", "HandWeapon", "Single", "diamondsword", "28", "0.85", "1.2", "0", "10","GamgeObject_Sword", "diamondsword" }},
                {3, new string[] { "GoldenSword", "HandWeapon", "Single", "goldensword", "24", "1.1", "1.6", "0", "10","GamgeObject_Sword","goldensword"}}
        };

        Sprite[] sprites = Resources.LoadAll("Images/Entities/Items", typeof(Sprite)).Cast<Sprite>().ToArray();
        foreach (Sprite sp in sprites)
        {
            ItemSprites.Add(sp.name, sp);

        }

        SetPolygonCollPath();

    }

    private void FixedUpdate()
    {
        if (Attack)
        {
            if (!AttackCooldownFinished)
            {
                AttackCooldown -= 1;
                if (AttackCooldown <= 0)
                {
                    AttackCooldownFinished = true;
                    AttackCooldown = AttackCooldownInterval;
                    Attack = false;
                }
            }
        }
    }

    //Slot and Inventory---------------------------------------------
    //Slot---
    public void InventoryPressed()
    {
        InventoryActive = !InventoryActive;
        int ind = 0;
        if (InventoryActive)
        {
            ind = 1;
        }
        Inventory.SetActive(InventoryActive);
        InventoryLogoSprite.sprite = InvButtonTemplates[ind];
        
    }

    public void PickUpItem(int ItemId, int Quantity, string Type, string SlotType)
    {
        int i = 0;
        int ID = IDGen();
        foreach (int slot in IntenvoryItemID)
        {
            if (slot == 0)
            {
                if (ItemExist(ItemId) && SlotType == "Multiple")
                {
                    //add quantity instead of slotype is multiple. if slotype is single then added to new slot
                    //int PreviousQuantity = ItemQuantity[ItemId];
                    //ItemQuantity[ItemId] = Quantity + PreviousQuantity;

                    var Key = InventorySlot.FirstOrDefault(x => x.Value[0] == ItemId.ToString()).Key;

                    int PreviousQuantity = int.Parse(InventorySlot[Key][1]);
                    int totalquantity = Quantity + PreviousQuantity;
                    InventorySlot[Key][1] = totalquantity.ToString();
                }

                else if ((ItemExist(ItemId) && SlotType == "Single") || !ItemExist(ItemId))
                {
                    IntenvoryItemID[i] = ID;
                    //ItemQuantity.Add(ItemId, Quantity);
                    //ItemType.Add(ItemId, Type);
                    //ItemSlotType.Add(ItemId, SlotType);
                    InventorySlot.Add(ID, new string[] { ItemId.ToString(), Quantity.ToString() });
                }

                SetSlotSprite(ID);
                return;
            }
            i++;
        }
    }

    public void SetSlotSprite(int ItemInstanceId)
    {
        bool SlotAvailable = false;
        int i = 0;
        foreach (int slot in ItemSlotID)
        {
            if (slot == 0)
            {
                ItemSlotID[i] = ItemInstanceId;
                SlotAvailable = true;
                break;
            }
            i++;
        }
        if (SlotAvailable)
        {
            sprite = ItemSprites[ItemProperties[int.Parse(InventorySlot[ItemInstanceId][0])][3]];

            SlotSprites[i].sprite = sprite;


        }
    }


    public void HoldItem(int SlotIndex)
    {
       
    }



    public void EquipItem(int SlotIndex)
    {
        bool Equip = true;
        if (SlotInUse == SlotIndex)
        {
            Equip = false;
        }
        UnEquip();

        if (Equip && ItemSlotID[SlotIndex] > 0)
        {

            PrevSlotInUse = SlotInUse;
            if (PrevSlotInUse != -1)
            {
                SlotOutlineSprites[PrevSlotInUse].sprite = SlotTemplate[0];
            }
            SlotInUse = SlotIndex;
            SlotOutlineSprites[SlotInUse].sprite = SlotTemplate[1];
            SetEquipment(SlotIndex);
        }
        else
        {
            PrevSlotInUse = SlotInUse;

            if (PrevSlotInUse > -1)
            {
                SlotOutlineSprites[PrevSlotInUse].sprite = SlotTemplate[0];
            }
 
            SlotInUse = -1;
            ItemSelectedID = 0;

        }
        
    }

    private void SetEquipment(int SlotIndex)
    {

        int ItemID = int.Parse(InventorySlot[ItemSlotID[SlotIndex]][0]);
        string ItemType = ItemProperties[ItemID][1];
        ItemSelectedID = ItemID;

        SetComponents(ItemID, ItemType);
    }



    public bool ItemExist(int ItemId)
    {
        //int index = Array.IndexOf(IntenvoryItemID, ItemId);
        if (InventorySlot.FirstOrDefault(x => x.Value[0] == ItemId.ToString()).Key > 0)
        {
            return true;
        }
        return false;
    }

    private void UnEquip()
    {
   
        AttackButton.SetActive(false);
        if (CurrentEquippedGameObject != null)
        {
            CurrentEquippedGameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
    }



    int IDGen()
    {
        Random rnd = new Random();
        int ID = rnd.Next(10000, 99999);
        
        for (int i = 0; i < IntenvoryItemID.Length; i++)
        {
            if (IntenvoryItemID[i] == ID)
            {
                ID = rnd.Next(10000, 99999);
                i = 0;
            }

        }

        return ID;
    }

    public void SlotPressed(int SlotIndex, bool isInventorySlot)
    {
        if (!isInventorySlot && InventoryItemSelectedID == 0)
        {
            EquipItem(SlotIndex);
            return;
        }

        
        if (ItemSelectedID != 0 && InventoryItemSelectedID != 0)
        {
            SwapItem(SlotIndex);
            return;
        }

        if ((isInventorySlot && ItemSelectedID != 0) || (!isInventorySlot && InventoryItemSelectedID != 0))
        {
            PlaceItem(SlotIndex, isInventorySlot);
            return;
        }
    }

    //Inventory---
    public void SelectFromInventory()
    {

    }

    private void UnSelectFromInventory()
    {
        InventoryItemSelectedID = 0;
    }

    private void SwapItem(int SlotIndex)
    {

            int Holder = ItemSlotID[SlotInUse];
            ItemSlotID[SlotInUse] = ItemSlotID[SlotIndex];
            ItemSlotID[SlotIndex] = Holder;

            SetSlotSprite(ItemSlotID[SlotInUse]);
            SetSlotSprite(ItemSlotID[SlotIndex]);

            SetEquipment(SlotIndex);

    }


    private void PlaceItem(int SlotIndex, bool isInventorySlot)
    {
        int ID = ItemSelectedID;
        int Slot = InventorySlotInUse;
        if (isInventorySlot)
        {
            ID = InventoryItemSelectedID;
            Slot = SlotInUse;
        }

        ItemSlotID[Slot] = 0;
        ItemSlotID[SlotIndex] = ID;

        SetSlotSprite(ItemSlotID[SlotInUse]);
        SetSlotSprite(ItemSlotID[SlotIndex]);

        SetEquipment(SlotIndex);
    }


    private void DeleteItem()
    {

    }

    private void TransferItemByQuantity()
    {

    }

    //Slot sprite functions

    void SetSlots()
    {
      
        GameObject EquipSlots = GameObject.Find("/GUI/Canvas/SlotBar/Slots").gameObject;
        int IV = 0;
        for (int i=0; i < EquipSlots.transform.childCount; i++, IV++)
        {

            SlotOutlineSprites[i] = EquipSlots.transform.GetChild(i).gameObject.GetComponent<Image>();
            SlotSprites[i] = EquipSlots.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Image>();
        }

        GameObject InventorySlots = GameObject.Find("/GUI/Canvas/Inventory/InventorySlots").gameObject;

        for (int i = 0; i < InventorySlots.transform.childCount; i++)
        {
            SlotOutlineSprites[i + IV] = InventorySlots.transform.GetChild(i).gameObject.GetComponent<Image>();
            SlotSprites[i + IV] = InventorySlots.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Image>();
        }


    }



    //Setting Equipment Components---------------------------------------------

    private void SetComponents(int ItemID, string ItemType)
    {
        //float Xscale = float.Parse(ItemProperties[ItemID][5]);
        //float Yscale = float.Parse(ItemProperties[ItemID][6]);

        //HandWeaponHitBox.size = new Vector3(Xscale, Yscale, 1);
        //HandWeaponHitBox.GetComponent<HandWeaponProperties>().damage = float.Parse(ItemProperties[ItemID][4]);

        string HostGameObj= ItemProperties[ItemID][9];


        switch (HostGameObj)
        {
            case "GamgeObject_Sword":

                CurrentEquippedGameObject = GamgeObject_Sword;
                HandWeaponProperties = CurrentEquippedGameObject.GetComponent<HandWeaponProperties>();
                CurrentEquippedGameObject.GetComponent<SpriteRenderer>().sprite = ItemSprites[ItemProperties[ItemID][3]];
                CurrentEquippedGameObject.GetComponent<PolygonCollider2D>().SetPath(0, PolygonColliderPathsList[ItemProperties[ItemID][10]]);
                CurrentEquippedGameObject.SetActive(true);
                HandWeaponProperties.damage = float.Parse(ItemProperties[ItemID][4]);
                HandWeaponProperties.knockback = float.Parse(ItemProperties[ItemID][4]);
                break;

        }


            //
        if (ItemType == "HandWeapon")
        {
            AttackButton.SetActive(true);

        }


    }





    //weapon attacks
    public void HandWeaponAttack()
    {
        if (!Attack)
        {
            //AttackCooldown = int.Parse(ItemProperties[ItemEquippedID][7]);
            //AttackLength = int.Parse(ItemProperties[ItemEquippedID][8]);
            //ItemEquipped.SetActive(true);

            Animator.SetBool("OverHeadAttack", true);
            Attack = true;
        }

    }
    
    public void AttackEnded()
    {
        
        Animator.SetBool("OverHeadAttack", false);
        AttackCooldown = AttackCooldownInterval;
        AttackCooldownFinished = false;
        Attack = false;

    }

    public void OverHeadAttackPeak()
    {
        CurrentEquippedGameObject.GetComponent<PolygonCollider2D>().enabled = true;
    }

    public void OverHeadAttackEnded()
    {
        CurrentEquippedGameObject.GetComponent<PolygonCollider2D>().enabled = false;
    }







    private void FindAndSavePolygonCollPath(GameObject gameObj)
    {
        string path = Application.dataPath + "/Resources/Json/PolygonPaths.json";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Log \n\n");
        }


        Vector2[] pathArr = gameObj.GetComponent<PolygonCollider2D>().GetPath(0);
        int length = pathArr.Length;
        string Vect = "";
        for (int i = 0; i < length; i++)
        {
            if (i == length - 1)
            {
                Vect += "\nnew Vector2(" + pathArr[i][0] + "f, " + pathArr[i][1] + "f)";
            }
            else
            {
                Vect += "\nnew Vector2(" + pathArr[i][0] + "f, " + pathArr[i][1] + "f),";
            }

        }

        string content = Vect;
        //@"""" + SpriteName + @""": {"+ Vect + "}";

        //        : {
        //            ["""",""""],
        //              ["""",""""]}
        //    }
        //";
        File.AppendAllText(path, content);
    }




    private void SetPolygonCollPath()
    {
        //sword
        Vector2[] Sword = new Vector2[22]
        {
            new Vector2(-0.14f, -0.295f),
            new Vector2(-0.11f, -0.235f),
            new Vector2(-0.12f, -0.155f),
            new Vector2(0.33f, 0.145f),
            new Vector2(0.44f, 0.265f),
            new Vector2(0.44f, 0.295f),
            new Vector2(0.34f, 0.295f),
            new Vector2(0.27f, 0.265f),
            new Vector2(0.18f, 0.205f),
            new Vector2(-0.22f, -0.065f),
            new Vector2(-0.26f, 0.005f),
            new Vector2(-0.31f, 0.015f),
            new Vector2(-0.34f, -0.045f),
            new Vector2(-0.27f, -0.105f),
            new Vector2(-0.42f, -0.175f),
            new Vector2(-0.44f, -0.205f),
            new Vector2(-0.44f, -0.285f),
            new Vector2(-0.43f, -0.295f),
            new Vector2(-0.33f, -0.295f),
            new Vector2(-0.21f, -0.205f),
            new Vector2(-0.18f, -0.285f),
            new Vector2(-0.15f, -0.295f)
        };

        //goldsword
        Vector2[] GoldenSword = new Vector2[27]
        {
           new Vector2(-0.255f, -0.315f),
           new Vector2(-0.205f, -0.315f),
           new Vector2(-0.145f, -0.255f),
           new Vector2(-0.145f, -0.215f),
           new Vector2(-0.155f, -0.195f),
           new Vector2(0.195f, 0.045f),
           new Vector2(0.455f, 0.225f),
           new Vector2(0.495f, 0.265f),
           new Vector2(0.545f, 0.345f),
           new Vector2(0.545f, 0.375f),
           new Vector2(0.525f, 0.385f),
           new Vector2(0.455f, 0.385f),
           new Vector2(0.365f, 0.345f),
           new Vector2(-0.265f, -0.095f),
           new Vector2(-0.255f, -0.055f),
           new Vector2(-0.335f, -0.025f),
           new Vector2(-0.395f, -0.085f),
           new Vector2(-0.375f, -0.185f),
           new Vector2(-0.445f, -0.225f),
           new Vector2(-0.545f, -0.285f),
           new Vector2(-0.565f, -0.295f),
           new Vector2(-0.565f, -0.335f),
           new Vector2(-0.555f, -0.385f),
           new Vector2(-0.485f, -0.415f),
           new Vector2(-0.475f, -0.415f),
           new Vector2(-0.395f, -0.335f),
           new Vector2(-0.315f, -0.265f)
        };


        // Diamond Sword
        Vector2[] DiamondSword = new Vector2[34]
       {
            new Vector2(-0.18f, -0.405f),
            new Vector2(-0.04f, -0.305f),
            new Vector2(0.04f, -0.225f),
            new Vector2(0.13f, -0.095f),
            new Vector2(0.16f, -0.015f),
            new Vector2(0.25f, 0.045f),
            new Vector2(0.39f, 0.165f),
            new Vector2(0.41f, 0.175f),
            new Vector2(0.43f, 0.195f),
            new Vector2(0.54f, 0.295f),
            new Vector2(0.54f, 0.415f),
            new Vector2(0.52f, 0.425f),
            new Vector2(0.44f, 0.435f),
            new Vector2(0.42f, 0.435f),
            new Vector2(0.36f, 0.395f),
            new Vector2(0.26f, 0.355f),
            new Vector2(0.11f, 0.235f),
            new Vector2(0.01f, 0.145f),
            new Vector2(-0.08f, 0.145f),
            new Vector2(-0.19f, 0.095f),
            new Vector2(-0.35f, 0.015f),
            new Vector2(-0.37f, -0.045f),
            new Vector2(-0.43f, -0.035f),
            new Vector2(-0.45f, -0.155f),
            new Vector2(-0.39f, -0.225f),
            new Vector2(-0.52f, -0.285f),
            new Vector2(-0.54f, -0.305f),
            new Vector2(-0.54f, -0.375f),
            new Vector2(-0.52f, -0.425f),
            new Vector2(-0.49f, -0.435f),
            new Vector2(-0.42f, -0.435f),
            new Vector2(-0.3f, -0.325f),
            new Vector2(-0.27f, -0.385f),
            new Vector2(-0.24f, -0.395f)
       };


        PolygonColliderPathsList.Add("sword", Sword);
        PolygonColliderPathsList.Add("goldensword", GoldenSword);
        PolygonColliderPathsList.Add("diamondsword", DiamondSword);
    }

}
