 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = System.Random;
public class StageScore : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameControl GameControl;
    [SerializeField] CanvasGroup BackGroundImage;
    [SerializeField] CanvasGroup MainContent;
    [SerializeField] GameObject Content;
    [SerializeField] GameObject Item;
    //(localPosition) X: -0.57, Y: 72.09 (+= -72.09), Z: 0.00 
    [SerializeField] TextMeshProUGUI PuzzleNumber;
    [SerializeField] TextMeshProUGUI Message;
    [SerializeField] TextMeshProUGUI TotalGradeMessage;
    [SerializeField] Image Medal;
    [SerializeField] Image Score;
    [SerializeField] ScrollRect ScrollArea;


    [SerializeField] Sprite[] StarsTemplate;
    [SerializeField] Sprite[] MedalsTemplate;

    [SerializeField] GameObject PuzzleInfo;
    [SerializeField] TextMeshProUGUI Question;
    [SerializeField] TextMeshProUGUI[] Choices;
    [SerializeField] Image[] ChoicesBGIMG;
    [SerializeField] Sprite[] ChoicesBGIMGTemplate;
    [SerializeField] Image MPScore;

    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] Image TimerFill;




    List<QuestionPool> QuestionPool = new List<QuestionPool>();

    StageInfo StageInfo = new();

    //PMDeclaration
//    List<int> PuzzleTriggerIDList = new List<int>();




//    List<int> ActiveQuestions = new List<int>();

//    List<string> Quesitions = new List<string>() { "if tenths is 1 and onces is 7 what is their equivalent number?", "if onces is 1, hundredths is 3 and tenths is 3 what is their equivalent number?", "8 onces, 2 tenths and 6 hundredths is equivalent to which number?", "2 onces, 6 hundredths and 2 tenths is equivalent to which number?", "5 onces and 6 tenths is equivalent to which number?", "5 tenths, 4 onces and 7 hundredths is equivalent to which number?", "if onces is 2 and tenths is 8 what is their equivalent number?", "if tenths is 8 and onces is 7 what is their equivalent number?", "8 onces and 8 tenths is equivalent to which number?", "if tenths is 8, hundredths is 5 and onces is 7 what is their equivalent number?", "if onces is 2, hundredths is 2 and tenths is 7 what is their equivalent number?", "if tenths is 5 and onces is 8 what is their equivalent number?", "7 tenths and 5 onces is equivalent to which number?", "if hundredths is 4, tenths is 6 and onces is 2 what is their equivalent number?", "if onces is 3 and tenths is 8 what is their equivalent number?", "7 onces, 1 tenths and 6 hundredths is equivalent to which number?", "5 tenths and 4 onces is equivalent to which number?", "5 tenths, 8 hundredths and 4 onces is equivalent to which number?", "1 tenths and 3 onces is equivalent to which number?", "if tenths is 3, onces is 5 and hundredths is 3 what is their equivalent number?", "if tenths is 4, onces is 5 and hundredths is 2 what is their equivalent number?", "if tenths is 5 and onces is 2 what is their equivalent number?", "6 onces and 7 tenths is equivalent to which number?", "if onces is 6, tenths is 7 and hundredths is 4 what is their equivalent number?", "if tenths is 5 and onces is 3 what is their equivalent number?", "1 onces, 8 hundredths and 4 tenths is equivalent to which number?", "if tenths is 4 and onces is 6 what is their equivalent number?", "if tenths is 2 and onces is 6 what is their equivalent number?", "1 tenths, 8 hundredths and 5 onces is equivalent to which number?", "7 tenths, 2 onces and 3 hundredths is equivalent to which number?", "if tenths is 1 and onces is 8 what is their equivalent number?", "if hundredths is 1, tenths is 1 and onces is 2 what is their equivalent number?", "4 onces, 8 hundredths and 4 tenths is equivalent to which number?", "7 tenths, 7 onces and 3 hundredths is equivalent to which number?", "3 hundredths, 7 onces and 2 tenths is equivalent to which number?", "7 tenths and 1 onces is equivalent to which number?", "8 hundredths, 7 tenths and 7 onces is equivalent to which number?", "6 tenths, 2 hundredths and 7 onces is equivalent to which number?", "3 tenths, 7 hundredths and 3 onces is equivalent to which number?" };
//    List<string[]> mpChoices = new List<string[]>() {
//new string[] {"17","9","63","21"},new string[] {"331","308","297","306"},new string[] {"628","608","608","623"},new string[] {"622","578","606","626"},new string[] {"46","81","65","49"},new string[] {"754","782","754","744"},new string[] {"81","82","80","69"},new string[] {"82","87","98","104"},new string[] {"131","125","88","67"},new string[] {"587","580","617","592"},new string[] {"272","262","232","275"},new string[] {"58","93","94","37"},new string[] {"75","125","72","69"},new string[] {"462","510","474","439"},new string[] {"83","49","65","80"},new string[] {"604","622","617","631"},new string[] {"90","25","54","33"},new string[] {"854","804","850","849"},new string[] {"10","37","13","2"},new string[] {"288","291","335","285"},new string[] {"246","263","203","245"},new string[] {"49","28","50","52"},new string[] {"76","109","96","106"},new string[] {"429","476","436","441"},new string[] {"53","26","43","87"},new string[] {"847","867","841","840"},new string[] {"17","70","76","46"},new string[] {"12","44","26","11"},new string[] {"833","842","853","815"},new string[] {"401","372","419","333"},new string[] {"5","2","58","18"},new string[] {"159","112","128","155"},new string[] {"868","844","837","833"},new string[] {"394","363","366","377"},new string[] {"371","345","327","321"},new string[] {"94","85","71","73"},new string[] {"838","878","850","877"},new string[] {"267","313","240","310"},new string[] {"733","697","778","721"}
// };
//    List<int> Answers = new List<int>() { 0, 0, 0, 0, 2, 0, 1, 1, 2, 0, 0, 0, 0, 0, 0, 2, 2, 0, 2, 2, 3, 3, 0, 1, 0, 2, 3, 2, 3, 1, 3, 1, 1, 3, 2, 2, 3, 0, 0 };



    private void OnEnable()
    {



        StageInfo = GameControl.StageInfo;
        //StageInfo.Level = 0;
        //StageInfo.Name = "Cave of the Lost";

        //GenPuzzleManager();
        BackGroundImage.alpha = 0;
        MainContent.alpha = 0;
        StartCoroutine(BackGroundFadeIn());

        //Debug.Log(Item.transform.localPosition);


    }


    IEnumerator BackGroundFadeIn()
    {

        BackGroundImage.alpha = 0;
        BackGroundImage.interactable = true;
        while (BackGroundImage.alpha < 1)
        {
            BackGroundImage.alpha += Time.deltaTime / 1f;
            yield return null;
        }
        //StartCoroutine(ContentFadeIn());
        yield break;
    }

    IEnumerator ContentFadeIn()
    {

        MainContent.alpha = 0;
        MainContent.interactable = true;
        while (MainContent.alpha < 1)
        {
            MainContent.alpha += Time.deltaTime / 0.5f;
            yield return null;
        }
        yield break;
    }



    public void SetStageScore(List<QuestionPool> locQuestionpool)
    {

        QuestionPool = locQuestionpool;

        //(localPosition) X: -0.57, Y: 72.09 (+= -72.09), Z: 0.00 
        Message.text = StageInfo.Name + " Completeded!";

        TotalGradeMessage.text = "Your total grade for completing " + StageInfo.Name;

        int totalGrade = 0;
        int iteration = 0;

        float ItemY = 72.09f;

        
        for (int i = 0 ; i < locQuestionpool.Count; i++)
        {
            if (locQuestionpool[i].Required)
            {
                Score.sprite = StarsTemplate[locQuestionpool[i].Grade];
                PuzzleNumber.text = "#" + (iteration + 1);
                GameObject NewItem = Instantiate(Item);
                NewItem.GetComponent<StageScoreItem>().ID = i;
                NewItem.GetComponent<StageScoreItem>().PNum = ""+(iteration + 1);
                NewItem.transform.SetParent(Content.transform);
                NewItem.transform.localPosition = new Vector2(-0.57f, ItemY);
                NewItem.transform.localScale = new Vector3(1, 1, 1);
                NewItem.name = "Item";
                NewItem.SetActive(true);
                ItemY -= 72.09f;

                totalGrade += locQuestionpool[i].Grade;
                iteration++;
            }
        }

        int average = totalGrade / iteration;
        Medal.sprite = MedalsTemplate[average];
        ScrollArea.verticalNormalizedPosition = 1f;


        StageRecord StageRecord = new StageRecord()
        {
            TotalGrade = average,
            QuestionPool = locQuestionpool
        };



        GameControl.SetStageRecord(StageRecord);
        StartCoroutine(ContentFadeIn());
    }

    public void ClosePIPanel()
    {
        PuzzleInfo.SetActive(false);
    }

    public void SetPIPanel(string PNUm, int index)
    {

        Question.text = "#"+PNUm + ". "+ QuestionPool[index].Question;

        for(int i = 0; i < Choices.Length; i++)
        {
            Choices[i].text = QuestionPool[index].Choices[i];
            ChoicesBGIMG[i].sprite = ChoicesBGIMGTemplate[2];
        }

        MPScore.sprite = StarsTemplate[QuestionPool[index].Grade];
        TimerText.text = "" + (int)QuestionPool[index].Timer;
        TimerFill.fillAmount = QuestionPool[index].Timer / QuestionPool[index].Interval;

        for (int i = 0; i < QuestionPool[index].PlayerAnswers.Count; i++)
        {

            if(QuestionPool[index].PlayerAnswers[i] == QuestionPool[index].Answer)
            {
                ChoicesBGIMG[QuestionPool[index].PlayerAnswers[i]].sprite = ChoicesBGIMGTemplate[0];
            }
            else
            {
                ChoicesBGIMG[QuestionPool[index].PlayerAnswers[i]].sprite = ChoicesBGIMGTemplate[1];
            }
            
        }


        PuzzleInfo.SetActive(true);
    }




    //PuzzleManager

    //void GenPuzzleManager()
    //{
    //    int ID = 0;

    //    for (int i =0; i<5 ;i++)
    //    {

    //        PuzzleTriggerIDList.Add(ID);


    //        ActiveQuestions.Add(RandomizeQuestion(Quesitions.Count));


    //        ID++;
    //    }
    //}

    //int RandomizeQuestion(int max)
    //{
    //    Random rnd = new Random();
    //    int ID = rnd.Next(1, max);

    //    for (int i = 0; i < ActiveQuestions.Count; i++)
    //    {
    //        if (ActiveQuestions[i] == ID)
    //        {
    //            ID = rnd.Next(1, max);
    //            i = 0;
    //        }
    //    }

    //    GenerateQuestions(ID);
    //    return ID;

    //}

    //void GenerateQuestions(int i)
    //{
    //    QuestionPool TempQuestionPool = new();

    //    TempQuestionPool.Question = Quesitions[i];
    //    TempQuestionPool.Answer = Answers[i];
    //    TempQuestionPool.Choices = mpChoices[i];


    //    TempQuestionPool.PlayerAnswers = new int[] { Answers[i] };
    //    TempQuestionPool.Timer = 12f;
    //    TempQuestionPool.Interval = 15f;
    //    TempQuestionPool.Grade = 1;
    //    TempQuestionPool.Tries = 1;

    //    TempQuestionPool.Done = true;
    //    TempQuestionPool.Required = true;

    //    QuestionPool.Add(TempQuestionPool);
    //}
}
