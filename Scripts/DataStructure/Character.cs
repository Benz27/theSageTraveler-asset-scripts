using System.Collections.Generic;

    public class Character
    {
        public int Health { get; set; }
        public int Coins { get; set; }
    }

    public class ItemInfo
    {
        public int ItemID { get; set; }
        public int SlotIndex { get; set; }
    }

    public class InventoryInfo
    {
        public List<ItemInfo> ItemInfo { get; set; }
    //public ItemInfo[] ItemInfo { get; set; }
    }
   

