using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

using TMPro;
public class Shop : MonoBehaviour
{

    [SerializeField] GameObject CheckOutPanel;
    [SerializeField] TextMeshProUGUI Price;
    [SerializeField] TextMeshProUGUI Message;
    [SerializeField] GameObject YesButton;
    [SerializeField] Image Icon;




    [SerializeField] GameObject ItemTemplate;
    [SerializeField] Transform ShopScrollView;
    [SerializeField] SavedData SavedData;
    [SerializeField] TextMeshProUGUI Coins;



    Dictionary<int, ItemProperties> ItemInfo;
    Dictionary<int, ShopItemData> ShopItemInfo;
    Dictionary<string, Sprite> ItemSprites = new Dictionary<string, Sprite>();
    ShopData ShopData;
    ItemList ItemList;
    InGameData InGameData;
    InventoryInfo InventoryInfo;

    ShopItem ActiveShopItem;


 

    void Awake()
    {
        ItemList = SavedData.LoadItemList();
        Sprite[] sprites = Resources.LoadAll("Images/Entities/Items", typeof(Sprite)).Cast<Sprite>().ToArray();
        foreach (Sprite sp in sprites)
        {
            ItemSprites.Add(sp.name, sp);

        }

        FetchSavedData();
    }


    public void FetchSavedData()
    {
        ItemInfo = new Dictionary<int, ItemProperties>();
        ShopItemInfo = new Dictionary<int, ShopItemData>();

        ShopData = SavedData.LoadShopData();
        InGameData = SavedData.LoadInGameData();
        InventoryInfo = InGameData.InventoryInfo;
        Coins.text = "" + InGameData.Character.Coins;


        foreach (Transform child in ShopScrollView)
        {
            Destroy(child.gameObject);
        }

        foreach (ItemData item in ItemList.ListOfItems)
        {
            ItemInfo.Add(item.ID, item.ItemProperties);


        }

        foreach (ShopItemData shopItem in ShopData.ShopItemList)
        {


            //ShopItem SItem = ItemTemplate.GetComponent<ShopItem>();
            //SItem.SetShopItem(shopItem.ID, ItemSprites[ItemInfo[shopItem.ID].SpriteName], shopItem.Price, shopItem.Available);








            GameObject NewItem = Instantiate(ItemTemplate, ShopScrollView);

            NewItem.GetComponent<ShopItem>().SetShopItem(shopItem.ID, ItemSprites[ItemInfo[shopItem.ID].SpriteName], shopItem.Price, shopItem.Available);

            ShopItemInfo.Add(shopItem.ID, shopItem);



        }
        
  
        
    }









    public void CheckOut(ShopItem shopItem)
    {
        ActiveShopItem = shopItem;
        int ID = shopItem.ID;
        int coins = InGameData.Character.Coins;
        ShopItemData SItemData = ShopItemInfo[ID];
        ItemProperties item = ItemInfo[ID];

        Icon.sprite = ItemSprites[ItemInfo[ID].SpriteName];
        Price.text = ""+SItemData.Price;



        if (coins >= SItemData.Price)
        {
            Message.text = "Do you wish to buy the " + item.Name + "?";
            YesButton.SetActive(true);
        }
        else
        {
            Message.text = "You need " + (SItemData.Price - coins) +" more coins to buy the "+ item.Name + ".";
            YesButton.SetActive(false);
        }

        CheckOutPanel.SetActive(true);
    }





    public void BuyItem()
    {
        int ItemID = ActiveShopItem.ID;

        int AvailableSlot = -1;
       

        if(InventoryInfo.ItemInfo.Count > 0)
        {
            List<ItemInfo> sortedList = InventoryInfo.ItemInfo.OrderBy(x => x.SlotIndex).ToList();
            foreach (ItemInfo ItemInfo in sortedList)
            {

                if (ItemInfo.SlotIndex - 1 != AvailableSlot)
                {
                    AvailableSlot = ItemInfo.SlotIndex;
                    break;

                }
                AvailableSlot++;
                if (ItemInfo == sortedList.Last())
                {
                    AvailableSlot++;
                }


            }
        }
        else
        {
            AvailableSlot = 0;
        }
        


        InventoryInfo.ItemInfo.Add(new ItemInfo()
        {
            ItemID = ItemID,
            SlotIndex = AvailableSlot
        });

        InGameData.Character.Coins -= ShopItemInfo[ItemID].Price;
        ShopItemInfo[ItemID].Available = false;


        ShopData NewShopData = new()
        {
            ShopItemList = new()
            {

            }
        };
        foreach (ShopItemData shopItem in ShopItemInfo.Values)
        {
            NewShopData.ShopItemList.Add(shopItem);
        }

        ShopData = NewShopData;
        ////InGameData.InventoryInfo.ItemInfo.Add(new ItemInfo { ID });



            SavedData.SaveShopData(ShopData);
            SavedData.SaveInGameData(InGameData);


            FetchSavedData();


        ActiveShopItem = null;
        CheckOutPanel.SetActive(false);
    }
}
