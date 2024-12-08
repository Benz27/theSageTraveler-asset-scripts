using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionButtonTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public PuzzleManagerTutorial PuzzleManagerTutorial;

    public void CloseQuestion()
    {

        PuzzleManagerTutorial.CloseMPPanel();

    }
    public void AppearQuestion()
    {

        PuzzleManagerTutorial.SetMPPanel();

    }
}
