public class GameData
{
    public int[] UnlockedStages { get; set; }
    public StageList StageList { get; set; }
}

public class StageList
{
    public Stage[] Stage { get; set; }
}

public class InGameData
{
    public Character Character { get; set; }
    public InventoryInfo InventoryInfo { get; set; }
    public ActiveLevel ActiveLevel { get; set; }
}
