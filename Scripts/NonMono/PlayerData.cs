using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

public class PlayerData_
{
    //Player
    public class PlayerInfo
    {
        public int Health { get; set; }
        public InventoryInfo InventoryInfo { get; set; }
    }

    public class ItemInfo
    {
        public int ItemID { get; set; }
        public int SlotIndex { get; set; }
    }

    public class InventoryInfo
    {
        public ItemInfo[] ItemInfo { get; set; }
    }

    //Game
    public class GameProgress
    {
        public CurrentProgress CurrentProgress { get; set; }
        public int[] FinishedStages { get; set; }
    }
    //1
    public class CurrentProgress
    {
        public int CurrentLevel { get; set; }
        public float[][] Position { get; set; }
    }
    //2
    


    //SaveData

    public class SaveData
    {
        public PlayerInfo PlayerInfo { get; set; }
        public GameProgress GameProgress { get; set; }
    }



    public PlayerInfo GetSaveData(int SlotNum)
    {
        return new PlayerInfo();
    }

}
