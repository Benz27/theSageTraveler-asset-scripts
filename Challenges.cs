using System;
using Random = System.Random;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenges : MonoBehaviour
{
    
    
    [NonSerialized] public ChallengeHitbox ChallengeHitbox;
    public GameObject QuestionTrigger;
    private ChallengeScript ChallengeScript;
    Dictionary<int, string[]> MultipleChoices = new Dictionary<int, string[]>(){
                //Quarter/Unit Number, Topic Number, Question, answer1, answer2, answer3, answer4, index of correct answer, if question is used
                {1, new string[] { "1", "1", "Which of the choices is larger than 120?", "130", "109","110","50","0","false"}},
                {2, new string[] { "1", "1", "Choose the correct opperator for the following. 30 _ 20", "<", "=", ">", "!=","2","false"}},
                {3, new string[] { "1", "1", "Which of the choices is an odd number?", "1", "2","4","6","0","false"}},
                {4, new string[] { "1", "1", "Which of the choices is an even number?", "3", "7","6","9","2","false"}},
                {5, new string[] { "1", "1", "Which of the choices is lesser than 50?", "100", "99","51","20","3","false"}},
                {6, new string[] { "1", "1", "Which of the choices is lesser than 20?", "30", "50","10","50","2","false"}},
                {7, new string[] { "1", "1", "Which of them is larger than 110?", "130", "109","110","50","0","false"}},
                {8, new string[] { "1", "1", "Which of them is larger than 160?", "170", "109","110","50","0","false"}},
                {9, new string[] { "1", "1", "Choose the correct opperator for the following. 10 _ 5", ">", "<","=","None of these","0","false"}},
                {10, new string[] { "1", "1", "What is 12 + 3?", "5", "10","9","15","3","false"}},
                {11, new string[] { "1", "1", "What is 12 - 2?", "10", "11","12","13","0","false"}},
                {12, new string[] { "1", "1", "What is 2 X 5?", "5", "10","1","7","1","false"}},
                {13, new string[] { "1", "1", "Which of the choices is in ascending order?", "1, 2, 3", "3, 2, 1","2, 1, 3","4, 6, 5","0","false"}},
                {14, new string[] { "1", "1", "What is 1 + 1?", "1", "0","2","3","2","false"}},
                {15, new string[] { "1", "1", "Which of the choices is larger than 5?", "1", "2","3","6","3","false"}},
                {16, new string[] { "1", "1", "Which of the choices is larger than 190?", "200", "180","110","50","0","false"}},
                {17, new string[] { "1", "1", "Choose the correct opperator for the following. 40 _ 20", "<", "=", ">", "!=","2","false"}},
                {18, new string[] { "1", "1", "Which of the choices is an odd number?", "3", "4","8","6","0","false"}},
                {19, new string[] { "1", "1", "Which of the choices is an even number?", "1", "7","2","9","2","false"}},
                {20, new string[] { "1", "1", "Which of the choices is lesser than 50?", "51", "52","53","49","3","false"}},
                {21, new string[] { "1", "1", "Which of the choices is lesser than 5?", "8", "7","4","6","2","false"}},
                {22, new string[] { "1", "1", "Which of them is larger than 110?", "111", "109","110","50","0","false"}},
                {23, new string[] { "1", "1", "Which of them is larger than 200?", "250", "140","110","23","0","false"}},
                {24, new string[] { "1", "1", "Choose the correct opperator for the following. 10 _ 15", ">", "<","=","None of these","1","false"}},
                {25, new string[] { "1", "1", "What is 12 + 12?", "5", "21","22","24","3","false"}},
                {26, new string[] { "1", "1", "What is 12 - 12?", "0", "1","2","3","0","false"}},
                {27, new string[] { "1", "1", "What is 5 X 5?", "30", "25","20","15","1","false"}},
                {28, new string[] { "1", "1", "Which of the choices is in ascending order?", "4, 5, 6", "6, 7, 1","2, 1, 3","4, 1, 5","0","false"}},
                {29, new string[] { "1", "1", "What is 10 + 10?", "10", "50","20","30","2","false"}},
                {30, new string[] { "1", "1", "Which of the choices is larger than 10?", "11", "9","8","7","3","false"}}
                

    };
    Dictionary<int, int> Numbering = new Dictionary<int, int>();

    private void Start()
    {
        SetQuestions();

    }

    private void SetQuestions()
    {

        for(int i=0;i< 13; i++)
        {
            Numbering.Add(i + 1, RandomQuestion(MultipleChoices.Count));
        }
    }

    void NumberingLog()
    {
        foreach(KeyValuePair<int, int> entry in Numbering)
        {
            Debug.Log(entry);
        }

    }
    private void SetQuestionIndividual(int num)
    {

        Numbering[num] = RandomQuestion(MultipleChoices.Count);
 
    }

    public void AnswerIsCorrect(bool ans, int QuestionNumber)
    {
     
        ChallengeHitbox.BoolBehave(ans);
        MultipleChoiceUsedQuestion(QuestionNumber);
        
        //if (!ans)
        //{
        //    SetQuestionIndividual(ChallengeHitbox.MyQuestionNumber);
        //}
    }

    public void getquestion(int num)
    {
  
        SetMultipleChoice(num);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);

    }

    public void closequestion()
    {

        gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }

    public void TargetBehave(bool bve)
    {
        ChallengeHitbox.BoolBehave(bve);
    }

    void SetMultipleChoice(int num)
    {
      
        int QuestionNumber = Numbering[num];

        ChallengeScript = gameObject.transform.GetChild(0).gameObject.GetComponent<ChallengeScript>();

        
        string[] answertext = { "", "", "", "" };

        for (int i = 0; i < 4; i++)
        {
            answertext[i] = MultipleChoices[QuestionNumber][3 + i];
        }

        ChallengeScript.SetChallenge(QuestionNumber, int.Parse(MultipleChoices[QuestionNumber][7]), MultipleChoices[QuestionNumber][2], answertext);
        Debug.Log("SET");

    }

    void MultipleChoiceUsedQuestion(int QuestionNumber)
    {
        MultipleChoices[QuestionNumber][8] = "true";
    }

    int RandomQuestion(int max)
    {
        Random rnd = new Random();
        int ID = rnd.Next(1, max);
        bool repeat = true;
        while (repeat)
        {
           
            if(MultipleChoices[ID][8] == "true")
            {
                ID = rnd.Next(1, max);

            }
            else
            {
                if (Numbering.ContainsValue(ID))
                {
                    ID = rnd.Next(1, max);
                }
                else
                {
                    repeat = false;
                }
            }

        }
        


        return ID;
    }

}
