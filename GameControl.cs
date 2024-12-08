using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine.Events;

public class GameControl : MonoBehaviour
{
    public PlayerProgress PlayerProgress;
    public GameObject LoadingObject;
    public GameObject MainCamera;
    public Image Background;
    public Sprite[] BackgroundImages;
    public StageScript StageScript;
    public GameObject Player;
    public GameObject Stages;
    public AudioClip[] AudioClip;
    public AudioSource AudioSource;
    public PuzzleManager PuzzleManager;
    GameStatus GameStatus;


    Player PlayerCOMP;

    [NonSerialized] public StageInfo StageInfo = new();

    [SerializeField] string[] StageNames;


    [SerializeField] SavedData SavedData;



    InGameData InGameData;
    GameData GameData;

    StageRecord StageRecord;
    readonly string[] PrefabPath = { "Prefabs/Stages/Stage1/Stage1", "Prefabs/Stages/Stage2/Stage2", "Prefabs/Stages/Stage3/Stage3", "Prefabs/Stages/Stage4/Stage4" };
    //int CurrentStageIndex = 0;


    private void Awake()
    {
        PlayerCOMP = Player.GetComponent<Player>();
        InGameData = SavedData.LoadInGameData();
        GameData = SavedData.LoadGameData();
        GameStatus = SavedData.LoadGameStatus();

        if (Time.timeScale < 1f){
            Time.timeScale = 1f;
        }


        //LoadingObject.SetActive(true);
        //MainCamera.SetActive(false);




        //PlayerPosArr = new Vector3[3]
        //{
        //       new Vector3(-1.02f, -0.59f, 88.46f),
        //       new Vector3(412.95f, -121.13f, 88.46f),
        //       new Vector3(495.83f, -42.79f, 88.46f),
        //};

        //MainCamPosArr = new Vector3[3]
        //{
        //       new Vector3(-1.12f, -0.10f, -10.00f),
        //       new Vector3(412.74f, -120.44f, -10.00f),
        //       new Vector3(495.62f, -42.10f, -10.00f),
        //};
        //GetSaveData();



        if (SceneManager.GetActiveScene().name == "Game")
        {
            GetSaveData();
            AudioSource.Stop();
            LoadStage(InGameData.ActiveLevel.CurrentLevel);


            //Non prefab
            //SetStage(3);
            //PrefabOBJLoaded();
            //AudioSource.Play();
            //SetCamera();
            return;
        }

        AudioSource.Stop();
        SetCamera();
        AudioSource.Play();
        Background.sprite = BackgroundImages[0];



        //Debug.Log(Player.transform.position + ", Player");
        //Debug.Log(MainCamera.transform.position + ", MainCamera");

        //GoToStage1();
    }

    void SetUpPlayer()
    {

        PlayerCOMP.SetHealth(InGameData.Character.Health);
        PlayerProgress.SetCoins(InGameData.Character.Coins);







        //PlayerEquipment.SetUpInventory(SavedData.GetInventoryInfo());


    }


    public void SetStageRecord(StageRecord loc_StageRecord)
    {
        StageRecord = loc_StageRecord;
    }


    void GetSaveData()
    {


        //PlayerPrefs.SetInt("CurrentStage", 0);






        SetUpPlayer();

        StageInfo.Level = InGameData.ActiveLevel.CurrentLevel;
        StageInfo.Name = StageNames[StageInfo.Level];


    }



    

    void SetCamera()
    {
        LoadingObject.SetActive(false);
        MainCamera.SetActive(true);
    }


    public void ToGame()
    {
        SceneManager.LoadScene(1);
    }
     

    void PrefabOBJLoaded()
    {
        MainCamera.SetActive(true);
        LoadingObject.SetActive(false);
    }

    void BackToLoading()
    {
        LoadingObject.SetActive(true);
        MainCamera.SetActive(false);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void SetPlayerMainCamPosition(Vector3 PlayerPos, Vector3 MainCamPos)
    {
        Player.transform.position = PlayerPos;
        MainCamera.transform.position = MainCamPos;
    }




    //public void GoToStage1()
    //{
    //    //StageScript.StageLoad();
    //    SetPlayerMainCamPosition(PlayerPosArr[0], MainCamPosArr[0]);


    //    Background.sprite = BackgroundImages[0];
    //    AudioSource.clip = AudioClip[0];
    //}

    //public void GoToStage2()
    //{
    //    //SetPlayerMainCamPosition(PlayerPosArr[1], MainCamPosArr[1]);
    //    Background.sprite = BackgroundImages[1];
    //}

    //public void GoToStage3()
    //{
    //    SetPlayerMainCamPosition(PlayerPosArr[2], MainCamPosArr[2]);
    //    Background.sprite = BackgroundImages[2];
    //}



    void SaveData()
    {
        //PlayerPrefs.SetInt("CurrentStage", StageInfo.Level + 1);




        GameData.StageList.Stage[StageInfo.Level].StageRecordStack.StageRecord.Add(StageRecord);
        InGameData.Character.Coins = PlayerProgress.GetCoins();





        if (GameData.StageList.Stage.Length > StageInfo.Level + 1)
        {
            GameData.StageList.Stage[StageInfo.Level + 1].UnLocked = true;
        }

        
        SavedData.SaveGameData(GameData);
        SavedData.SaveInGameData(InGameData);





    }

    public void StageFinished()
    {
        
        PuzzleManager.SendScore();
        PlayerCOMP.DisablePlayer();
        SaveData();

    }

    public void LoadCutScene()
    {



        BackToLoading();
        GameStatus.ShowStages = true;
        SavedData.SaveGameStatus(GameStatus);
        SceneManager.LoadScene(0);


    }

    public void Exit()
    {



        BackToLoading();
        GameStatus.ShowStages = false;
        SavedData.SaveGameStatus(GameStatus);
        SceneManager.LoadScene(0);


    }



    void SetStage(int index)
    {
        Vector2 SpawnPos;

        StageScript.StageLoad(index);

        if (SavedData.GetActiveLevelLastPos().Length > 0)
        {
            SpawnPos = new Vector2(SavedData.GetActiveLevelLastPos()[0], SavedData.GetActiveLevelLastPos()[1]);
        }
        else
        {
            SpawnPos = StageScript.GetSpawnPos();
        }

        

        SetPlayerMainCamPosition(new Vector3(SpawnPos.x, SpawnPos.y, 88.46f), new Vector3(SpawnPos.x, SpawnPos.y, -10.00f));
        //Debug.Log(Player.transform.position + " " + SpawnPos);

        Background.sprite = BackgroundImages[index];
        AudioSource.clip = AudioClip[index];
    }

    private void LoadStage(int index)
    {
        
        GameObject prefab = Resources.Load<GameObject>(PrefabPath[index]);


        if (prefab != null)
        {
            GameObject instance = Instantiate(prefab);
            instance.transform.parent = Stages.transform;
            instance.transform.localPosition = new Vector3(0f, 0f, 0f);

            SetStage(index);
            PrefabOBJLoaded();
            AudioSource.Play();
            //Debug.Log("Prefab instantiated successfully.");

   
        }
        else
        {
            
            Debug.LogError("Failed to load prefab.");
            BackToLoading();
        }
    }


    //void JSONData()
    //{
    //    PlayerPrefs.SetInt("HighScore", 100);
    //    PlayerPrefs.SetFloat("Volume", 0.5f);
    //    PlayerPrefs.SetString("PlayerName", "John");

    //    string json = "{\"Employee1\":{\"Name\":\"John Doe\"},\"Employee2\":{\"Name\":\"Johny Bravo\"}}";

    //    Dictionary<string, QuestionPool> employees = JsonConvert.DeserializeObject<Dictionary<string, QuestionPool>>(json);

    //    Debug.Log("Employee 1 Name: " + employees["Employee1"].Name);
    //    Debug.Log("Employee 2 Name: " + employees["Employee2"].Name);
    //    string QuestionPoolJSON = @"[{
    //                    Question:""Sample question 1"",
    //                    Answer:0,
    //                    Choices:[""A"",""B"",""C"",""D""]
    //                    },
    //                    {
    //                    Question:""Sample question 2"",
    //                    Answer:0,
    //                    Choices:[""A"",""B"",""C"",""D""]
    //                    }
    //                    ]";
    //    for (int i = 0; i < QuestionPool.Count; i++)
    //    {
    //        Debug.Log(QuestionPool[i].Choices[QuestionPool[i].Answer]);
    //    }
    //}


    //Save file



}
