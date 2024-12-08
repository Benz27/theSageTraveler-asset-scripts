using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class ChallengeScript : MonoBehaviour
{
    // Start is called before the first frame update

    private int rightans;

    public TextMeshProUGUI Choice1;
    public TextMeshProUGUI Choice2;
    public TextMeshProUGUI Choice3;
    public TextMeshProUGUI Choice4;
    public TextMeshProUGUI QuestionText;
    private int QuestionIndex;
    public Challenges Challenges;


    public void SetChallenge(int QuestionNumber, int ans, string question, string[] answertext)
    {
        Choice1.text = answertext[0];
        Choice2.text = answertext[1];
        Choice3.text = answertext[2];
        Choice4.text = answertext[3];
        QuestionIndex = QuestionNumber;
        QuestionText.text = question;
        rightans = ans;
    }

    public void GetAnswer(int ans)
    {
        if(ans == rightans)
        {
            Challenges.AnswerIsCorrect(true, QuestionIndex);
        }
        else
        {
            Challenges.AnswerIsCorrect(false, QuestionIndex);
        }
        CloseMe();
    }
   public void CloseMe()
    {
        gameObject.SetActive(false);
    }
}
