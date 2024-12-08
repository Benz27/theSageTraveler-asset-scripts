
using System.Collections.Generic;


public class ShopData
{
    public List<ShopItemData> ShopItemList { get; set; }
}

public class ShopItemData
{
    public int ID { get; set; }
    public int Price { get; set; }
    public bool Available { get; set; }
}

