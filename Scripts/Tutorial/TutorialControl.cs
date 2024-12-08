using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine.Events;

public class TutorialControl : MonoBehaviour
{

    public GameObject LoadingObject;
    public GameObject MainCamera;
    public Image Background;
    public Sprite[] BackgroundImages;
    public PlayerProgress PlayerProgress;

    public GameObject Player;
    public AudioClip AudioClip;
    public AudioSource AudioSource;
    public PuzzleManagerTutorial PuzzleManagerTutorial;
    public GameObject ExitPanel;



    Player PlayerCOMP;

    [NonSerialized] public StageInfo StageInfo = new();

    [SerializeField] string[] StageNames;


    [SerializeField] SavedData SavedData;



    InGameData InGameData;

    GameStatus GameStatus;
    //int CurrentStageIndex = 0;


    private void Awake()
    {
        PlayerCOMP = Player.GetComponent<Player>();
        InGameData = SavedData.LoadInGameData();
        GameStatus = SavedData.LoadGameStatus();

        if (Time.timeScale < 1f)
        {
            Time.timeScale = 1f;
        }


        AudioSource.Stop();
        SetCamera();
        AudioSource.Play();
        Background.sprite = BackgroundImages[0];
        
    }

    void SetUpPlayer()
    {

        PlayerCOMP.SetHealth(InGameData.Character.Health);
        PlayerProgress.SetCoins(InGameData.Character.Coins);







        //PlayerEquipment.SetUpInventory(SavedData.GetInventoryInfo());


    }


    void SetCamera()
    {
        LoadingObject.SetActive(false);
        MainCamera.SetActive(true);
    }


    public void ToMain()
    {

        SceneManager.LoadScene(0);
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



        GameStatus.ShowTutorial = false;
        GameStatus.ShowStages = true;

        InventoryInfo InventoryInfo = new InventoryInfo()
        {
            ItemInfo = new()
            {
                new ItemInfo
                {
                    ItemID = 1,
                    SlotIndex = 0
                }
            }
        };
        
        InGameData.InventoryInfo = InventoryInfo;

        SavedData.SaveGameStatus(GameStatus);
        SavedData.SaveInGameData(InGameData);




    }

    public void TutorialFinished()
    {

        ExitPanel.SetActive(true);

    }


    public void GoToMain()
    {
        SaveData();
        BackToMain();
    }


    public void BackToMain()
    {



        BackToLoading();
       
        SceneManager.LoadScene(0);


    }





    void SetTutorial()
    {

        AudioSource.clip = AudioClip;
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
