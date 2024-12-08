using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionButton : MonoBehaviour
{
    // Start is called before the first frame update
    public PuzzleManager PuzzleManager;

    public void CloseQuestion()
    {

        PuzzleManager.CloseMPPanel();

    }
    public void AppearQuestion()
    {

        PuzzleManager.SetMPPanel();

    }

    //private void OnMouseDown()
    //{
    //    AppearQuestion();
    //}

}