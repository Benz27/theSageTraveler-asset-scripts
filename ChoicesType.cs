using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;using System;

public class ChoicesType : MonoBehaviour
{

    string Question;
    List<string> Choices = new List<string>();
    int Answer = 0;

    public UnityEvent OnAnsTrue;
    public UnityEvent OnAnsFalse;

    void Awake()
    {
        if (OnAnsTrue == null)
            OnAnsTrue = new UnityEvent();

        if (OnAnsFalse == null)
            OnAnsFalse = new UnityEvent();

    }

    public bool AnswerSet(int Choice)
    {
        if (Choice == Answer)
        {

            OnAnsTrue.Invoke();

        }
        else
        {
            OnAnsFalse.Invoke();
        }

        return (Choice == Answer);
    }






}
