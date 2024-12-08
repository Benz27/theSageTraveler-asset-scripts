using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButtonTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public PuzzleManagerTutorial PuzzleManagerTutorial;
    public int answer;

    public void SendAnswer()
    {
        PuzzleManagerTutorial.GiveMPAnswer(answer);
    }
}
