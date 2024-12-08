using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
public class StageMenu : MonoBehaviour
{

    [SerializeField] SavedData SavedData;
    InGameData InGameData;
    GameData GameData;


    [SerializeField] GameObject LoadingObject;
    [SerializeField] GameObject MainCamera;

    [SerializeField] Sprite[] MedalsTemplate;
    [SerializeField] Sprite[] StageImages;
    [SerializeField] GameObject Content;

    [SerializeField] GameObject Item;

    [SerializeField] GameObject Lock;
    [SerializeField] Image StageImage;
    [SerializeField] TextMeshProUGUI StageName;
    [SerializeField] Button Button;
    [SerializeField] Image Medal;
    [SerializeField] AudioSource musicSource;

    //[SerializeField] Button HFButton;
    //[SerializeField] Button SCButton;
    
    //[SerializeField] GameObject HFLock;
    //[SerializeField] GameObject SCLock;


    //[SerializeField] GameObject HFMedalGOBJ;
    //[SerializeField] GameObject SCMedalGOBJ;
    //[SerializeField] Image HFMedal;
    //[SerializeField] Image SCMedal;



    private void Awake()
    {
        Loading();
        
        
        SetStages();
        Loaded();
    }

    void SetStages()
    {
        GameData = SavedData.LoadGameData();
        for (int i=0; i < GameData.StageList.Stage.Length; i++)
        {
            Stage stage = GameData.StageList.Stage[i];
            StageImage.sprite = StageImages[i];
            StageName.text = stage.StageName;


            //if (stage.UnLocked)
            //{
            //    Lock.SetActive(!stage.UnLocked);
            //    Button.enabled = stage.UnLocked;

            //}

            Lock.SetActive(!stage.UnLocked);
            Button.gameObject.SetActive(stage.UnLocked);


            //Debug.Log(stage.StageRecordStack.StageRecord.Count);


            if (stage.StageRecordStack.StageRecord.Count > 0)
            {

                StageRecord Bestrecord = new() {
                    TotalGrade = -1
                    
                };


                foreach (StageRecord stageRecord in stage.StageRecordStack.StageRecord)
                {
                    if(Bestrecord.TotalGrade < stageRecord.TotalGrade)
                    {
                        Bestrecord = stageRecord;
                    }

                }

                Medal.sprite = MedalsTemplate[Bestrecord.TotalGrade];







            }

            Medal.gameObject.SetActive(stage.StageRecordStack.StageRecord.Count > 0);


            GameObject NewItem = Instantiate(Item);
            NewItem.GetComponent<StageItem>().StageIndex = i;
            NewItem.transform.SetParent(Content.transform);
            NewItem.transform.localScale = new Vector3(1f, 1f, 1f);

            NewItem.transform.SetAsLastSibling();

            Transform NITransform = NewItem.transform;

            NewItem.transform.localPosition = new Vector3(NITransform.localPosition.x, NITransform.localPosition.y, -117.0003f);
            

        }
    }


    public void GoToGame(int Level)
    {
        InGameData = SavedData.LoadInGameData();
        musicSource.Stop();
        Loading();
        InGameData.ActiveLevel.CurrentLevel = Level;
        int SceneNum = 1;
        if (GameData.StageList.Stage[Level].ShowCutScene)
        {
            GameData.StageList.Stage[Level].ShowCutScene = false;
            SceneNum = 4;
        }


        SavedData.SaveInGameData(InGameData);
        SavedData.SaveGameData(GameData);




        SceneManager.LoadScene(SceneNum);

        //SceneManager.LoadScene(1);
    }


    public void SetToStage1()
    {
        GoToGame(0);

    }

    public void SetToStage2()
    {
        GoToGame(1);
    }


    public void SetToStage3()
    {
        GoToGame(2);
    }



    void Loaded()
    {
        MainCamera.SetActive(true);
        LoadingObject.SetActive(false);
    }

    void Loading()
    {
        LoadingObject.SetActive(true);
        MainCamera.SetActive(false);
    }


    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }

}
