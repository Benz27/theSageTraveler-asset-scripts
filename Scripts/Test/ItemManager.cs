using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<int, ItemProperties> ItemInfo = new Dictionary<int, ItemProperties>(); //<ItemID, [Name, Type, SlotType, ?Damage]>
    //Dictionary<int, string[]> ItemProperties; //<ItemID, [Name, Type, SlotType, ?Damage]>
    Dictionary<string, Sprite> ItemSprites = new Dictionary<string, Sprite>();
    Dictionary<int, List<Vector2>> PolygonColliderPathsList = new Dictionary<int, List<Vector2>>();

    [SerializeField] SavedData SavedData;
    [SerializeField] GameObject AttackButton;
    [SerializeField] GameObject HandWeapon;

    ItemList ItemList;







    //void Awake()
    //{


        
    //}


    public void SetItemList()
    {
        ItemList = SavedData.LoadItemList();

        foreach (ItemData item in ItemList.ListOfItems)
        {
            ItemInfo.Add(item.ID, item.ItemProperties);

            List<Vector2> PolPath = new List<Vector2>();

            foreach (ItemVector2D vector2D in item.ItemProperties.ItemPolygonPath.ItemVector2D)
            {
                PolPath.Add(new Vector2(vector2D.X, vector2D.Y));


            }

            PolygonColliderPathsList.Add(item.ID, PolPath);


        }



        //ItemProperties = new Dictionary<int, string[]>(){

        //        {4, new string[] { "Bow", "RangeWeapon", "Single", "bow", "15","30","10"}},
        //        {2, new string[] { "Sword", "HandWeapon", "Single", "sword", "15", "0.75", "0.9615385", "0", "10","sword"}},
        //        {1, new string[] { "DiamondSword", "HandWeapon", "Single", "diamondsword", "28", "0.85", "1.2", "0", "10" ,"diamondsword"}},
        //        {3, new string[] { "GoldenSword", "HandWeapon", "Single", "goldensword", "24", "1.1", "1.6", "0", "10","goldensword"}}
        //};

        Sprite[] sprites = Resources.LoadAll("Images/Entities/Items", typeof(Sprite)).Cast<Sprite>().ToArray();
        foreach (Sprite sp in sprites)
        {
            ItemSprites.Add(sp.name, sp);

        }
    }





    public Sprite GetSprite(int ItemID)
    {
        //return ItemSprites[ItemProperties[ItemID][3]];
        return ItemSprites[ItemInfo[ItemID].SpriteName];
    }

    public void UnSetComponents()
    {
        HandWeapon.SetActive(false);
        AttackButton.SetActive(false);
    }



    public void SetComponents(int ItemID)
    {
        //float Xscale = float.Parse(ItemProperties[ItemID][5]);
        //float Yscale = float.Parse(ItemProperties[ItemID][6]);

        //HandWeaponHitBox.size = new Vector3(Xscale, Yscale, 1);
        //HandWeaponHitBox.GetComponent<HandWeaponProperties>().damage = float.Parse(ItemProperties[ItemID][4]);



        //switch (HostGameObj)
        //{
        //    case "GamgeObject_Sword":

        //        //CurrentEquippedGameObject = GamgeObject_Sword;
        //        //HandWeaponProperties = CurrentEquippedGameObject.GetComponent<HandWeaponProperties>();
        //        //CurrentEquippedGameObject.GetComponent<SpriteRenderer>().sprite = ItemSprites[ItemProperties[ItemID][3]];
        //        //CurrentEquippedGameObject.GetComponent<PolygonCollider2D>().SetPath(0, PolygonColliderPathsList[ItemProperties[ItemID][10]]);
        //        //CurrentEquippedGameObject.SetActive(true);
        //        //HandWeaponProperties.damage = float.Parse(ItemProperties[ItemID][4]);
        //        //HandWeaponProperties.knockback = float.Parse(ItemProperties[ItemID][4]);


        //        break;

        //}
        UnSetComponents();

        switch (ItemInfo[ItemID].Type)
        {
            case "HandWeapon":


                //HandWeapon.GetComponent<SpriteRenderer>().sprite = ItemSprites[ItemProperties[ItemID][3]];
                //HandWeapon.GetComponent<PolygonCollider2D>().SetPath(0, PolygonColliderPathsList[ItemProperties[ItemID][9]]);
                //HandWeapon.GetComponent<HandWeapon>().damage = float.Parse(ItemProperties[ItemID][4]);
                //HandWeapon.GetComponent<HandWeapon>().knockback = float.Parse(ItemProperties[ItemID][4]);

                HandWeapon.GetComponent<SpriteRenderer>().sprite = ItemSprites[ItemInfo[ItemID].SpriteName];
                HandWeapon.GetComponent<PolygonCollider2D>().SetPath(0, PolygonColliderPathsList[ItemID]);
                HandWeapon.GetComponent<HandWeapon>().damage = ItemInfo[ItemID].Damage;
                HandWeapon.GetComponent<HandWeapon>().knockback = ItemInfo[ItemID].KnockBack;
                HandWeapon.SetActive(true);
                AttackButton.SetActive(true);

                break;

        }




    }

}
