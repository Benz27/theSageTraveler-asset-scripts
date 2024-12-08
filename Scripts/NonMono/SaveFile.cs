

using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;



public class SaveFile
{
    class PlayerInfo
    {
        public int Health { get; set; }

        public InventoryInfo InventoryInfo { get; set; }
    }

    class ItemInfo
    {
        public int ItemID { get; set; }
        public int SlotIndex { get; set; }
    }


    class InventoryInfo
    {
        public ItemInfo[] ItemInfo { get; set; }

    }
    public void WriteJSONFromFile()
    {
        // Read the JSON file into a string

        string json = File.ReadAllText("person.json");
        var playerInfo = JsonConvert.DeserializeObject<PlayerInfo>(json);

        // Modify the PlayerInfo object
        playerInfo.Health = 90;
        playerInfo.InventoryInfo.ItemInfo[0].SlotIndex = 1;
        playerInfo.InventoryInfo.ItemInfo[1].SlotIndex = 2;
        playerInfo.InventoryInfo.ItemInfo[2].SlotIndex = 0;

        // Serialize the modified PlayerInfo object to JSON
        json = JsonConvert.SerializeObject(playerInfo);

        // Save the JSON string to the file
        File.WriteAllText("person.json", json);
    }

    public void GetSaveFile(string path)
    {
        string json = File.ReadAllText(path);
        var playerInfo = JsonConvert.DeserializeObject<PlayerInfo>(json);


    }





    public void SaveToFile(string path)
    {
        string json = File.ReadAllText(path);
        var playerInfo = JsonConvert.DeserializeObject<PlayerInfo>(json);

        // Modify the PlayerInfo object
        playerInfo.Health = 90;
        playerInfo.InventoryInfo.ItemInfo[0].SlotIndex = 1;
        playerInfo.InventoryInfo.ItemInfo[1].SlotIndex = 2;
        playerInfo.InventoryInfo.ItemInfo[2].SlotIndex = 0;

        // Serialize the modified PlayerInfo object to JSON
        json = JsonConvert.SerializeObject(playerInfo);

        // Save the JSON string to the file
        File.WriteAllText("person.json", json);
    }





}
