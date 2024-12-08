using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class ShopItem : MonoBehaviour
{
    [SerializeField] Image Icon;
    [SerializeField] TextMeshProUGUI PriceText;
    [SerializeField] GameObject BuyButton;
    [SerializeField] GameObject SoldButton;
    [SerializeField] Shop Shop;


    [NonSerialized] public int Price;
    [NonSerialized] public bool Available;
    [NonSerialized] public int ID;

    public void SetShopItem(int ItemID, Sprite ItemSprite, int ItemPrice, bool isAvailable)
    {
        ID = ItemID;
        Icon.sprite = ItemSprite;
        Price = ItemPrice;
        PriceText.text = ""+ ItemPrice;
        Available = isAvailable;
        ItemAvailable(Available);
    }

    public void BuyItem()
    {
        Shop.CheckOut(this);

    }

    void ItemAvailable(bool available)
    {
        BuyButton.SetActive(available);
        SoldButton.SetActive(!available);
    }



}
