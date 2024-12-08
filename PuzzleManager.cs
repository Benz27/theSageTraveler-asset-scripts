using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using Random = System.Random;
using UnityEngine.Events;
public class PuzzleManager : MonoBehaviour
{
    // Start is called before the first frame update

    PuzzleTrigger ActivePuzzleTrigger;
    [SerializeField] MultipleChoice MultipleChoice;
    [SerializeField] GameObject[] MPChoices;


    [SerializeField] GameObject PuzzlePanelCollection;
    [SerializeField] GameObject Player;

    [SerializeField] Timer Timer;
    [SerializeField] GameObject StageScore;
    [SerializeField] GameObject GUI;
    [SerializeField] SavedData SavedData;
    [SerializeField] GameOver GameOver;


    Chapter Chapter;
    InGameData InGameData;


    List<int> PuzzleTriggerIDList = new List<int>();
    
    List<QuestionPool> QuestionPool = new List<QuestionPool>();


    List<int> ActiveQuestions = new List<int>();

    List<string> Quesitions = new List<string>() { "if tenths is 1 and onces is 7 what is their equivalent number?", "if onces is 1, hundredths is 3 and tenths is 3 what is their equivalent number?", "8 onces, 2 tenths and 6 hundredths is equivalent to which number?", "2 onces, 6 hundredths and 2 tenths is equivalent to which number?", "5 onces and 6 tenths is equivalent to which number?", "5 tenths, 4 onces and 7 hundredths is equivalent to which number?", "if onces is 2 and tenths is 8 what is their equivalent number?", "if tenths is 8 and onces is 7 what is their equivalent number?", "8 onces and 8 tenths is equivalent to which number?", "if tenths is 8, hundredths is 5 and onces is 7 what is their equivalent number?", "if onces is 2, hundredths is 2 and tenths is 7 what is their equivalent number?", "if tenths is 5 and onces is 8 what is their equivalent number?", "7 tenths and 5 onces is equivalent to which number?", "if hundredths is 4, tenths is 6 and onces is 2 what is their equivalent number?", "if onces is 3 and tenths is 8 what is their equivalent number?", "7 onces, 1 tenths and 6 hundredths is equivalent to which number?", "5 tenths and 4 onces is equivalent to which number?", "5 tenths, 8 hundredths and 4 onces is equivalent to which number?", "1 tenths and 3 onces is equivalent to which number?", "if tenths is 3, onces is 5 and hundredths is 3 what is their equivalent number?", "if tenths is 4, onces is 5 and hundredths is 2 what is their equivalent number?", "if tenths is 5 and onces is 2 what is their equivalent number?", "6 onces and 7 tenths is equivalent to which number?", "if onces is 6, tenths is 7 and hundredths is 4 what is their equivalent number?", "if tenths is 5 and onces is 3 what is their equivalent number?", "1 onces, 8 hundredths and 4 tenths is equivalent to which number?", "if tenths is 4 and onces is 6 what is their equivalent number?", "if tenths is 2 and onces is 6 what is their equivalent number?", "1 tenths, 8 hundredths and 5 onces is equivalent to which number?", "7 tenths, 2 onces and 3 hundredths is equivalent to which number?", "if tenths is 1 and onces is 8 what is their equivalent number?", "if hundredths is 1, tenths is 1 and onces is 2 what is their equivalent number?", "4 onces, 8 hundredths and 4 tenths is equivalent to which number?", "7 tenths, 7 onces and 3 hundredths is equivalent to which number?", "3 hundredths, 7 onces and 2 tenths is equivalent to which number?", "7 tenths and 1 onces is equivalent to which number?", "8 hundredths, 7 tenths and 7 onces is equivalent to which number?", "6 tenths, 2 hundredths and 7 onces is equivalent to which number?", "3 tenths, 7 hundredths and 3 onces is equivalent to which number?" };
    List<string[]> Choices = new List<string[]>() {
new string[] {"17","9","63","21"},new string[] {"331","308","297","306"},new string[] {"628","608","608","623"},new string[] {"622","578","606","626"},new string[] {"46","81","65","49"},new string[] {"754","782","754","744"},new string[] {"81","82","80","69"},new string[] {"82","87","98","104"},new string[] {"131","125","88","67"},new string[] {"587","580","617","592"},new string[] {"272","262","232","275"},new string[] {"58","93","94","37"},new string[] {"75","125","72","69"},new string[] {"462","510","474","439"},new string[] {"83","49","65","80"},new string[] {"604","622","617","631"},new string[] {"90","25","54","33"},new string[] {"854","804","850","849"},new string[] {"10","37","13","2"},new string[] {"288","291","335","285"},new string[] {"246","263","203","245"},new string[] {"49","28","50","52"},new string[] {"76","109","96","106"},new string[] {"429","476","436","441"},new string[] {"53","26","43","87"},new string[] {"847","867","841","840"},new string[] {"17","70","76","46"},new string[] {"12","44","26","11"},new string[] {"833","842","853","815"},new string[] {"401","372","419","333"},new string[] {"5","2","58","18"},new string[] {"159","112","128","155"},new string[] {"868","844","837","833"},new string[] {"394","363","366","377"},new string[] {"371","345","327","321"},new string[] {"94","85","71","73"},new string[] {"838","878","850","877"},new string[] {"267","313","240","310"},new string[] {"733","697","778","721"}
 };
    List<int> Answers = new List<int>() { 0, 0, 0, 0, 2, 0, 1, 1, 2, 0, 0, 0, 0, 0, 0, 2, 2, 0, 2, 2, 3, 3, 0, 1, 0, 2, 3, 2, 3, 1, 3, 1, 1, 3, 2, 2, 3, 0, 0 };

    public UnityEvent Correct;
    public UnityEvent InCorrect;
    void Awake()
    {
        if (Correct == null)
            Correct = new UnityEvent();
        if (InCorrect == null)
            InCorrect = new UnityEvent();



        InGameData = SavedData.LoadInGameData();
        Chapter = SavedData.LoadStageQuestions().Chapter[InGameData.ActiveLevel.CurrentLevel];

        GameObject[] PuzzleTriggers = GameObject.FindGameObjectsWithTag("PuzzleTrigger");
        int ID = 0;
        
        foreach (GameObject Obj in PuzzleTriggers)
        {
            Obj.GetComponent<PuzzleTrigger>().PuzzleTriggerID = ID;
            PuzzleTriggerIDList.Add(ID);


            ActiveQuestions.Add(RandomizeQuestion(Quesitions.Count));


            ID++;
        }

       
    }


    public void SetActivePuzzleTrigger(PuzzleTrigger PuzzleTrigger)
    {
        ActivePuzzleTrigger = PuzzleTrigger;
    }

    int RandomizeQuestion(int max)
    {
        Random rnd = new Random();
        int ID = rnd.Next(1, max);

        for (int i = 0; i < ActiveQuestions.Count; i++)
        {
           if(ActiveQuestions[i] == ID)
            {
                ID = rnd.Next(1, max);
                i = 0;
            }
        }


        GenerateQuestions(ID);
        return ID;

    }



    void GenerateQuestions(int i)
    {
        QuestionPool TempQuestionPool = new();

       

        //TempQuestionPool.Question = Quesitions[i];
        //TempQuestionPool.Answer = Answers[i];
        //TempQuestionPool.Choices = Choices[i];

        TempQuestionPool.Question = Chapter.QuestionPool[i].Question;
        TempQuestionPool.Answer = Chapter.QuestionPool[i].Answer;
        TempQuestionPool.Choices = Chapter.QuestionPool[i].Choices;


        TempQuestionPool.PlayerAnswers = new List<int>();
        TempQuestionPool.Timer = 0f;
        TempQuestionPool.Interval = 0f;
        TempQuestionPool.Grade = 0;
        TempQuestionPool.Tries = 0;

        TempQuestionPool.Done = false;
        TempQuestionPool.Required = false;

        QuestionPool.Add(TempQuestionPool);
    }




    void GenerateQuestions_old()
    {

  
            for (int i = 0; i < Quesitions.Count; i++)
            {
                QuestionPool TempQuestionPool = new();

                TempQuestionPool.Question = Quesitions[i];
                TempQuestionPool.Answer = Answers[i];
                TempQuestionPool.Choices = Choices[i];


                TempQuestionPool.PlayerAnswers = new List<int>();
                TempQuestionPool.Timer = 0f;
                TempQuestionPool.Interval = 0f;
                TempQuestionPool.Grade = 0;
                TempQuestionPool.Tries = 0;

                TempQuestionPool.Done = false;
                TempQuestionPool.Required = false;


                QuestionPool.Add(TempQuestionPool);

            }

       




    }




    public void GiveMPAnswer(int answer)
    {
        Timer.StopTimer();
        //int QuestionNumber = ActiveQuestions[ActivePuzzleTrigger.PuzzleTriggerID];
            int QuestionNumber = ActivePuzzleTrigger.PuzzleTriggerID;
            bool AnswerIsCorrect = (answer == QuestionPool[QuestionNumber].Answer);
            ActivePuzzleTrigger.BoolBehave(AnswerIsCorrect);


        if (!AnswerIsCorrect)
        {
            InCorrect.Invoke();
        }

            QuestionPool[QuestionNumber].PlayerAnswers.Add(answer);
            QuestionPool[QuestionNumber].Tries += 1;


            bool[] PuzzleTriggerStatus = ActivePuzzleTrigger.GetPuzzleStatus();

            //Puzzle Failed, Required, Is the answer correct
            if (PuzzleTriggerStatus[0] && PuzzleTriggerStatus[1] && !AnswerIsCorrect)
            {
            GameOver.PuzzleFailed();


        }
            else if (!PuzzleTriggerStatus[0] && PuzzleTriggerStatus[1] && AnswerIsCorrect)
            {
                Player.GetComponent<Player>().healthUp(5);
                Correct.Invoke();

            QuestionPool[QuestionNumber].Done = true;
            QuestionPool[QuestionNumber].Required = PuzzleTriggerStatus[1];
        }



            CloseMPPanel();
            ComputeTotalGrade(QuestionNumber);
    }


    void ComputeTotalGrade(int index)
    {






        if (QuestionPool[index].Done)
        {
            float[] TimerValue = Timer.GetTimerValue();
            int TimeGrade = ComputePuzzleTimeGrade(TimerValue);
            int TriesGrade = QuestionPool[index].Tries;
            int FinalGrade = ((3 - (TriesGrade - 1)) + TimeGrade) / 2;
            QuestionPool[index].Timer = TimerValue[0];
            QuestionPool[index].Interval = TimerValue[1];
            QuestionPool[index].Grade = FinalGrade;

            Debug.Log((3 - (TriesGrade - 1))+", "+TimeGrade + ", " +FinalGrade);
        }
    }

    public void SendScore()
    {
        GUI.SetActive(false);
        StageScore.SetActive(true);
        StageScore.GetComponent<StageScore>().SetStageScore(QuestionPool);
    }
                                                                                                                

    int ComputePuzzleTimeGrade(float[] timerValue)
    {
        float Platinum = 75f;
        float Gold = 60f;
        float Silver = 35f;
        //float Bronze = 1f;

        float percentage = (timerValue[0] / timerValue[1]) * 100;

        if (percentage >= Platinum)
        {
            return 3;
        }

        if (percentage >= Gold)
        {
            return 2;
        }
        if (percentage >= Silver)
        {
            return 1;
        }

        return 0;


    }


    public void CloseMPPanel()
    {

            
        PuzzlePanelCollection.transform.GetChild(0).gameObject.SetActive(false);
      
    }

    public void SetMPPanel()
    {

        if (!ActivePuzzleTrigger.isOnGoing())
        {

            MultipleChoice.SetChoicesEnebled(true);
            SetMultipleChoice();
            ActivePuzzleTrigger.SetTimer(Timer);
            Timer.StartTimer();
            ActivePuzzleTrigger.SetOnGoing(true);
        }


     

       
        PuzzlePanelCollection.transform.GetChild(0).gameObject.SetActive(true);


    }

    public void SetMultipleChoice()
    {

        //int QuestionNumber = ActiveQuestions[ActivePuzzleTrigger.PuzzleTriggerID];
        MultipleChoice.ShuffleChoices();
        int QuestionNumber = ActivePuzzleTrigger.PuzzleTriggerID;
        MultipleChoice.SetQuestionPanel(QuestionPool[QuestionNumber].Question, QuestionPool[QuestionNumber].Choices);



        
    }

    public void TimerOut()
    {
        //ActivePuzzleTrigger.BoolBehave(false);
        MultipleChoice.SetChoicesEnebled(false);

        StartCoroutine(DelayMPClosing());
        //Debug.Log(ActivePuzzleTrigger.GetPuzzleStatus()[0]);


    }

    private IEnumerator DelayMPClosing()
    {
        // Wait for one second
        yield return new WaitForSeconds(0.5f);

        // Enable the collider component
        CloseMPPanel();
        ActivePuzzleTrigger.BoolBehave(false);
        if (ActivePuzzleTrigger.GetPuzzleStatus()[0])
        {



            GameOver.PuzzleFailed();
            PuzzlePanelCollection.transform.GetChild(0).gameObject.SetActive(false);
       
        }
    }





    //DONT REMOVE MAY USE LATER


    //void JSONData() {
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


  


}
