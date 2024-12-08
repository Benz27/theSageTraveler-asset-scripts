using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public PuzzleManager PuzzleManager;
    public int answer;

    public void SendAnswer()
    {
        PuzzleManager.GiveMPAnswer(answer);
    }
}
