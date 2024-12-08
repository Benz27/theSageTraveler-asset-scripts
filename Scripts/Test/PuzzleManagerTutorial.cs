using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Random = System.Random;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class PuzzleManagerTutorial : MonoBehaviour
{
    // Start is called before the first frame update

    [NonSerialized] public PuzzleTrigger ActivePuzzleTrigger;
    [SerializeField] MultipleChoice MultipleChoice;
    [SerializeField] GameObject PuzzlePanelCollection;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject ExitPanel;
    [SerializeField] Timer Timer;
    [SerializeField] GameOver GameOver;



    [SerializeField] GameObject Clicker;
    [SerializeField] GameObject Pointer;
    [SerializeField] GameObject MPClickerOBJ;
    bool MPClicker = false;



    List<int> PuzzleTriggerIDList = new List<int>();

    List<QuestionPoolOBJ> QuestionPool = new List<QuestionPoolOBJ>();
    List<int> ActiveQuestions = new List<int>();


    List<string> Quesitions = new List<string>() { "Find the sum of 1 + 1.",
                                                        "What is the sum of 2 + 2?",
                                                    "What is the sum of 3 + 3?",
                                                    "1 + 2 is?",
                                                    "Find the difference of 5 - 4.",
                                                        "What is the sum of 2 + 3?",
                                                        "What is the sum of 2 + 4?" };
    List<int> Answers = new List<int>() { 0, 0, 0, 1, 2, 3, 2 };
    List<string[]> Choices = new List<string[]>() {
  new string[] { "2", "3", "4", "5" },
  new string[] { "4", "5", "6", "7" },
  new string[] { "6", "7", "8", "9" },
  new string[] { "2", "3", "1", "0" },
  new string[] { "5", "2", "1", "6" },
  new string[] { "1", "2", "4", "5" },
    new string[] { "1", "2", "6", "5" }
 };

    public class QuestionPoolOBJ
    {
        public string Question { get; set; }
        public int Answer { get; set; }
        public string[] Choices { get; set; }
    }

    public UnityEvent Correct;
    public UnityEvent InCorrect;

    void Start()
    {

        if (Correct == null)
            Correct = new UnityEvent();
        if (InCorrect == null)
            InCorrect = new UnityEvent();


        GameObject[] PuzzleTriggers = GameObject.FindGameObjectsWithTag("PuzzleTrigger");
        int ID = 0;
        GenerateQuestions();
        foreach (GameObject Obj in PuzzleTriggers)
        {
            Obj.GetComponent<PuzzleTrigger>().PuzzleTriggerID = ID;
            PuzzleTriggerIDList.Add(ID);
            ActiveQuestions.Add(RandomizeQuestion(QuestionPool.Count));
            ID++;
        }


    }


    int RandomizeQuestion(int max)
    {
        Random rnd = new Random();
        int ID = rnd.Next(1, max);

        for (int i = 0; i < ActiveQuestions.Count; i++)
        {
            if (ActiveQuestions[i] == ID)
            {
                ID = rnd.Next(1, max);
                i = 0;
            }
        }

        return ID;

    }


    void GenerateQuestions()
    {


            for (int i = 0; i < Quesitions.Count; i++)
            {
                QuestionPoolOBJ TempQuestionPool = new QuestionPoolOBJ();

                TempQuestionPool.Question = Quesitions[i];
                TempQuestionPool.Answer = Answers[i];
                TempQuestionPool.Choices = Choices[i];










                QuestionPool.Add(TempQuestionPool);
            }
            return;
   




    }




    public void GiveMPAnswer(int answer)
    {

        int QuestionNumber = ActiveQuestions[ActivePuzzleTrigger.PuzzleTriggerID];
        bool AnswerIsCorrect = (answer == QuestionPool[QuestionNumber].Answer);
        ActivePuzzleTrigger.BoolBehave(AnswerIsCorrect);

        if (!AnswerIsCorrect)
        {
            InCorrect.Invoke();
        }

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
            Clicker.SetActive(false);
            MPClickerOBJ.SetActive(false);
            Pointer.SetActive(false);
            MPClicker = true;
        }



        CloseMPPanel();
    }

    public void CloseMPPanel()
    {
        if (!MPClicker)
        {
            Clicker.SetActive(true);
        }

        PuzzlePanelCollection.transform.GetChild(0).gameObject.SetActive(false);

    }

    public void SetMPPanel()
    {

        //SetMultipleChoice();
        //PuzzlePanelCollection.transform.GetChild(0).gameObject.SetActive(true);

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

    public void SetMultipleChoice()
    {

        int QuestionNumber = ActiveQuestions[ActivePuzzleTrigger.PuzzleTriggerID];

        MultipleChoice.SetQuestionPanel(QuestionPool[QuestionNumber].Question, QuestionPool[QuestionNumber].Choices);



        if (!MPClicker)
        {
            Clicker.SetActive(false);
            if (QuestionPool[QuestionNumber].Answer == 0)
            {
                MPClickerOBJ.transform.localPosition = new Vector3(-101.88f, -127f, 0f);
            }
            else if (QuestionPool[QuestionNumber].Answer == 1)
            {
                MPClickerOBJ.transform.localPosition = new Vector3(103.55f, -127f, 0f);
            }
            else if (QuestionPool[QuestionNumber].Answer == 2)
            {
                MPClickerOBJ.transform.localPosition = new Vector3(-101.88f, -174.5f, 0f);
            }
            else if (QuestionPool[QuestionNumber].Answer == 3)
            {
                MPClickerOBJ.transform.localPosition = new Vector3(103.55f, -174.5f, 0f);
            }

        }
    }

    //DONT REMOVE MAY USE LATER

    //string json = "{\"Employee1\":{\"Name\":\"John Doe\"},\"Employee2\":{\"Name\":\"Johny Bravo\"}}";

    //Dictionary<string, QuestionPool> employees = JsonConvert.DeserializeObject<Dictionary<string, QuestionPool>>(json);

    //Debug.Log("Employee 1 Name: " + employees["Employee1"].Name);
    //Debug.Log("Employee 2 Name: " + employees["Employee2"].Name);
    //string QuestionPoolJSON = @"[{
    //                Question:""Sample question 1"",
    //                Answer:0,
    //                Choices:[""A"",""B"",""C"",""D""]
    //                },
    //                {
    //                Question:""Sample question 2"",
    //                Answer:0,
    //                Choices:[""A"",""B"",""C"",""D""]
    //                }
    //                ]";
    //for (int i = 0; i < QuestionPool.Count; i++)
    //{
    //    Debug.Log(QuestionPool[i].Choices[QuestionPool[i].Answer]);
    //}
}
