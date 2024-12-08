using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StageScoreItem : MonoBehaviour
{
    [NonSerialized] public int ID;
    [NonSerialized] public string PNum;

    [SerializeField] StageScore StageScore;

    public void SetPIPanel()
    {
        StageScore.SetPIPanel(PNum,ID);
    }



}
