using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using Random = System.Random;

public class MultipleChoice : MonoBehaviour
{
    // Start is called before the first frame update



    public TextMeshProUGUI Choice1;
    public TextMeshProUGUI Choice2;
    public TextMeshProUGUI Choice3;
    public TextMeshProUGUI Choice4;
    public TextMeshProUGUI QuestionText;

    public Button[] ChoicesButtons; // Replace this with your array of buttons

    List<Vector2> MPChoicesDefaultLocPos = new();


    public void SetQuestionPanel(string question, string[] answertext)
    {
        Choice1.text = answertext[0];
        Choice2.text = answertext[1];
        Choice3.text = answertext[2];
        Choice4.text = answertext[3];

        QuestionText.text = question;
    }


    void SetMPCHVectors()
    {
        foreach (Button choice in ChoicesButtons)
        {
            MPChoicesDefaultLocPos.Add(choice.transform.localPosition);

            //Debug.Log(choice.transform.localPosition);
        }
    }

    public void CloseMe()
    {
        gameObject.SetActive(false);
    }

    public void SetChoicesEnebled(bool status)
    {
        foreach (Button button in ChoicesButtons)
        {
            button.interactable = status;
        }
    }

    public void ShuffleChoices()
    {
        if(MPChoicesDefaultLocPos.Count == 0)
        {
            SetMPCHVectors();
        }


        List<Vector2> CHLocalPos = MPChoicesDefaultLocPos;
        Random rand = new();

        for (int i = CHLocalPos.Count - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);

            Vector2 temp = CHLocalPos[i];
            CHLocalPos[i] = CHLocalPos[j];
            CHLocalPos[j] = temp;

        }

        for (int i = 0; i < ChoicesButtons.Length; i++)
        {

            ChoicesButtons[i].transform.localPosition = CHLocalPos[i];

        }
    }




}
