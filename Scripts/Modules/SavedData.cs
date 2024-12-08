using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class SavedData : MonoBehaviour
{


    string JsonPath = "/SaveFile/Json/SaveData/";
    string JFInGame = "InGame.json";
    string JFGame = "Game.json";
    string JFItemList = "ItemList.json";
    string JFShop = "Shop.json";
    string JFGameStatus = "Status.json";
    string JFStageQuestions = "Questions.json";




    string JFInGamePath;
    string JFGamePath;
    string JFItemListPath;
    string JFShopPath;
    string JFGameStatusPath;
    string JFStageQuestionsPath;


    Constants Constants = new Constants();
    void Awake()
    {

        string persistentDataPath = Application.persistentDataPath +"/";


        JFItemListPath = persistentDataPath + JFItemList;
        JFShopPath = persistentDataPath + JFShop;
        JFInGamePath = persistentDataPath + JFInGame;
        JFGamePath = persistentDataPath + JFGame;
        JFGameStatusPath = persistentDataPath + JFGameStatus;
        JFStageQuestionsPath = persistentDataPath + JFStageQuestions;


        

    }










    public void WriteAll()
    {

  
        string persistentDataPath = Application.persistentDataPath + "/Def";
        if (!File.Exists(persistentDataPath + JFGame))
        {
            File.WriteAllText(persistentDataPath + JFItemList, Constants.ItemList);
            File.WriteAllText(persistentDataPath + JFShop, Constants.ShopData);
            File.WriteAllText(persistentDataPath + JFInGame, Constants.InGameData);
            File.WriteAllText(persistentDataPath + JFGame, Constants.GameData);
            File.WriteAllText(persistentDataPath + JFGameStatus, Constants.Status);
            File.WriteAllText(persistentDataPath + JFStageQuestions, Constants.StageQuestions);
        }

        persistentDataPath = Application.persistentDataPath + "/";
        if (!File.Exists(persistentDataPath + JFGame))
        {
            File.WriteAllText(persistentDataPath + JFItemList, Constants.ItemList);
            File.WriteAllText(persistentDataPath + JFShop, Constants.ShopData);
            File.WriteAllText(persistentDataPath + JFInGame, Constants.InGameData);
            File.WriteAllText(persistentDataPath + JFGame, Constants.GameData);
            File.WriteAllText(persistentDataPath + JFGameStatus, Constants.Status);
            File.WriteAllText(persistentDataPath + JFStageQuestions, Constants.StageQuestions);
        }
        //File.WriteAllText(persistentDataPath + JFItemList, Constants.ItemList);
        //File.WriteAllText(persistentDataPath + JFShop, Constants.ShopData);
        //File.WriteAllText(persistentDataPath + JFInGame, Constants.InGameData);
        //File.WriteAllText(persistentDataPath + JFGame, Constants.GameData);
        //File.WriteAllText(persistentDataPath + JFGameStatus, Constants.Status);

    }





    public void ResetAll()
    {
        string persistentDataPath = Application.persistentDataPath + "/";
        File.WriteAllText(persistentDataPath + JFItemList, Constants.ItemList);
        File.WriteAllText(persistentDataPath + JFShop, Constants.ShopData);
        File.WriteAllText(persistentDataPath + JFInGame, Constants.InGameData);
        File.WriteAllText(persistentDataPath + JFGame, Constants.GameData);
        File.WriteAllText(persistentDataPath + JFGameStatus, Constants.Status);
        File.WriteAllText(persistentDataPath + JFStageQuestions, Constants.StageQuestions);
    }






    //InGameData

    public void SaveInGameData(InGameData InGameData)
    {
        File.WriteAllText(JFInGamePath, JsonConvert.SerializeObject(InGameData));




    }

    public InGameData LoadInGameData()
    {

        if (JFInGamePath == null)
        {
            JFInGamePath = Application.persistentDataPath + "/" + JFInGame;
        }


        if (!File.Exists(JFInGamePath)) // Check if file exists
        {
            SetInGameDataDefaults();

        }

        string json = File.ReadAllText(JFInGamePath);
        InGameData InGameData = JsonConvert.DeserializeObject<InGameData>(json);




        return InGameData;
    }

    void SetInGameDataDefaults()
    {
        //InGameData InGameData = new InGameData
        //{
        //    Character = DefaultCharacter(),
        //    InventoryInfo = DefualtInventoryInfo(),
        //    ActiveLevel = DefaultActiveLevel(),

        //};
        //SaveInGameData(InGameData);

        File.WriteAllText(JFInGamePath, File.ReadAllText(Application.persistentDataPath + "/Def" + JFInGame));
    }

    //Character

    Character DefaultCharacter()
    {
        Character Character = new Character
        {
            Health = 50,
            Coins = 0

        };

        return Character;

    }



    //InventoryInfo

    InventoryInfo DefualtInventoryInfo()
    {
        InventoryInfo InventoryInfo = new InventoryInfo()
        {
            ItemInfo = new()
            {
                //new ItemInfo
                //{
                //    ItemID = 1,
                //    SlotIndex = 0
                //}
            }
        };

        return InventoryInfo;
    }




    //ActiveLevel

    ActiveLevel DefaultActiveLevel()
    {
        ActiveLevel ActiveLevel = new ActiveLevel()
        {
            CurrentLevel = 0,
            Position = { }
        };

        return ActiveLevel;
    }




    public float[] GetActiveLevelLastPos()
    {



        return new float[0];
    }





    //GameData


    public void SaveGameData(GameData GameData)
    {
        File.WriteAllText(JFGamePath, JsonConvert.SerializeObject(GameData));
    }



    void SetGameDataDefaults()
    {
        //GameData GameData = new GameData()
        //{
        //    UnlockedStages = new int[]
        //    {
        //        0
        //    },

        //    StageList = new StageList
        //    {
        //        Stage = new Stage[]
        //        {
        //            new Stage
        //            {
        //                StageLevel = 0,
        //                StageName = "Hostile Forest",
        //                UnLocked = true,
        //                ShowCutScene = true,
        //                StageRecordStack = new StageRecordStack
        //                {
        //                    StageRecord = new List<StageRecord>
        //                    {

        //                    }
        //                }
        //            },
        //            new Stage
        //            {
        //                StageLevel = 1,
        //                StageName = "Scary Cave",
        //                UnLocked = false,
        //                ShowCutScene = true,
        //                StageRecordStack = new StageRecordStack
        //                {
        //                    StageRecord = new List<StageRecord>
        //                    {

        //                    }
        //                }
        //            }
        //        }
        //    }
        //};




        //SaveGameData(GameData);

        File.WriteAllText(JFGamePath, File.ReadAllText(Application.persistentDataPath + "/Def" + JFGame));
    }

    public GameData LoadGameData()
    {
        if (JFGamePath == null)
        {
            JFGamePath = Application.persistentDataPath + "/" + JFGame;
        }


        if (!File.Exists(JFGamePath)) // Check if file exists
        {
            SetGameDataDefaults();

        }
        string json = File.ReadAllText(JFGamePath);
        GameData GameData = JsonConvert.DeserializeObject<GameData>(json);


        return GameData;
    }

    //ItemList

    public void SaveItemList(ItemList ItemList)
    {
        File.WriteAllText(JFItemListPath, JsonConvert.SerializeObject(ItemList));
    }



    void SetItemListDefaults()
    {
        //ItemList ItemList = new()
        //{

        //};
        //ItemList = JsonConvert.DeserializeObject<ItemList>(Application.persistentDataPath + "/Def" + JFItemList);
        //SaveItemList(ItemList);

        File.WriteAllText(JFItemListPath, File.ReadAllText(Application.persistentDataPath + "/Def" + JFItemList));
    }

    public ItemList LoadItemList()
    {

        if (JFItemListPath == null)
        {
            JFItemListPath = Application.persistentDataPath + "/" + JFItemList;
        }

        if (!File.Exists(JFItemListPath)) // Check if file exists
        {
            SetItemListDefaults();
            //File.WriteAllText(JFItemListPath, Constants.ItemList);


        }
        string json = File.ReadAllText(JFItemListPath);
        ItemList ItemList = JsonConvert.DeserializeObject<ItemList>(json);


        return ItemList;
    }


    //Shop
    public void SaveShopData(ShopData ShopData)
    {
        File.WriteAllText(JFShopPath, JsonConvert.SerializeObject(ShopData));
        
    }



    void SetShopDataDefaults()
    {
        //ShopData ShopData = new()
        //{
            
        //};
        //ShopData = JsonConvert.DeserializeObject<ShopData>(Application.persistentDataPath + "/Def" + JFShop);
        File.WriteAllText(JFShopPath, File.ReadAllText(Application.persistentDataPath + "/Def" + JFShop));
        //SaveShopData(ShopData);
    }

    public ShopData LoadShopData()
    {

        if (JFShopPath == null)
        {
            JFShopPath = Application.persistentDataPath + "/" + JFShop;
        }

        if (!File.Exists(JFShopPath)) // Check if file exists
        {
            SetShopDataDefaults();

        }
        string json = File.ReadAllText(JFShopPath);
        ShopData ShopData = JsonConvert.DeserializeObject<ShopData>(json);


        return ShopData;
    }





    //GameStatus
    public void SaveGameStatus(GameStatus GameStatus)
    {
        File.WriteAllText(JFGameStatusPath, JsonConvert.SerializeObject(GameStatus));
    }



    void SetGameStatusDefaults()
    {
        //GameStatus GameStatus = new()
        //{
        //    ShowStages = false,
        //    ShowIntro = false,
        //    ShowTutorial = false
        //};

        //SaveGameStatus(GameStatus);

        File.WriteAllText(JFGameStatusPath, File.ReadAllText(Application.persistentDataPath + "/Def" + JFGameStatus));
    }

    public GameStatus LoadGameStatus()
    {

        if (JFGameStatusPath == null)
        {
            JFGameStatusPath = Application.persistentDataPath + "/" + JFGameStatus;
        }

        if (!File.Exists(JFGameStatusPath)) // Check if file exists
        {
            SetGameStatusDefaults();

        }
        string json = File.ReadAllText(JFGameStatusPath);
        GameStatus GameStatus = JsonConvert.DeserializeObject<GameStatus>(json);


        return GameStatus;
    }




    //StageQuestions
    public void SaveStageQuestions(StageQuestions StageQuestions)
    {
        File.WriteAllText(Application.persistentDataPath + "/" + JFStageQuestions, JsonConvert.SerializeObject(StageQuestions));
    }



    void SetStageQuestionsDefaults()
    {
        //StageQuestions StageQuestions = new()
        //{
        //    Chapter = new()
        //    {
        //        new Chapter
        //        {
        //            QuestionPool = new()
        //            {
        //                new PuzzleQuestion()
        //                {
        //                    Question = "Answer is A.",
        //                    Choices = new string[] { "A", "B", "C", "D" },
        //                    Answer = 0
        //                }
        //            }
        //        },
        //        new Chapter
        //        {
        //            QuestionPool = new()
        //            {
        //                new PuzzleQuestion()
        //                {
        //                    Question = "Answer is B.",
        //                    Choices = new string[] { "A", "B", "C", "D" },
        //                    Answer = 1
        //                }
        //            }
        //        },
        //        new Chapter
        //        {
        //            QuestionPool = new()
        //            {
        //                new PuzzleQuestion()
        //                {
        //                    Question = "Answer is C.",
        //                    Choices = new string[] { "A", "B", "C", "D" },
        //                    Answer = 2
        //                }
        //            }
        //        },
        //        new Chapter
        //        {
        //            QuestionPool = new()
        //            {
        //                new PuzzleQuestion()
        //                {
        //                    Question = "Answer is D.",
        //                    Choices = new string[] { "A", "B", "C", "D" },
        //                    Answer = 3
        //                }
        //            }
        //        },
        //    }

        //};

        File.WriteAllText(JFStageQuestionsPath, File.ReadAllText(Application.persistentDataPath + "/" + JFStageQuestions));

        //SaveGameStatus(GameStatus);

        //File.WriteAllText(JFStageQuestionsPath, File.ReadAllText(Application.persistentDataPath + "/Def" + JFStageQuestions));
    }

    public StageQuestions LoadStageQuestions()
    {

        if (JFStageQuestionsPath == null)
        {
            JFStageQuestionsPath = Application.persistentDataPath + "/" + JFStageQuestions;
        }

        if (!File.Exists(JFStageQuestionsPath))
        {
            SetGameStatusDefaults();

        }
        string json = File.ReadAllText(JFStageQuestionsPath);
        StageQuestions StageQuestions = JsonConvert.DeserializeObject<StageQuestions>(json);


        return StageQuestions;
    }
}
