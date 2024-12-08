using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StageItem : MonoBehaviour
{

    [SerializeField] StageMenu StageMenu;
    [NonSerialized] public int StageIndex;

    public void SetToStage()
    {
        StageMenu.GoToGame(StageIndex);

    }


}
