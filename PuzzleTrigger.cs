using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    // Start is called before the first frame update
   
   [NonSerialized] public int PuzzleTriggerID;
    public ObstacleBehavior Target;
    private int tries = 3;
    public int interval = 40;
    private int cooldown;
    private bool activatecooldown = false;
    private GameObject HealthBar;
    private GameObject CooldownBar;
    private float XCBSizeDiff = 0f;
    private float XCBSize = 0f;
    public bool Required = true;
    bool PuzzleFailed = false;
    public Collider2D MyCollider;
    float CDXScale = 0f;




    Timer Timer;
    //float TXCBSizeDiff = 0f;
    //float TXCBSize = 1f;
    float TInterval = 0f;
    bool OnGoing = false;


    private void Awake()
    {
        cooldown = interval;

        //ExitPanel = GameObject.Find("GUI/Canvas/GameOverPanel");
        //QuestionButton = Control.GetComponent<QuestionButton>();

        //
        CooldownBar = transform.GetChild(0).gameObject;
        HealthBar = transform.GetChild(1).gameObject;
        XCBSizeDiff = CooldownBar.transform.localScale.x/interval ;
        CDXScale = CooldownBar.transform.localScale.x;



    }




    public void BoolBehave(bool bve)
    {
        MyCollider.enabled = false;
        SetOnGoing(false);
        if (bve)
        {
            Target.Activate(true);
            //MyCollider.enabled = false;
            CooldownBar.SetActive(false); 
            HealthBar.SetActive(false);
   
        }
        else
        {
            CooldownBar.transform.localScale = new Vector3(0f, 0.122529f, 1f);

            tries -= 1;
            HealthBar.transform.GetChild(tries).gameObject.SetActive(false);

            if (tries>0)
            {

                activatecooldown = true;
            }
            else
            {
                Target.Activate(false);
                CooldownBar.SetActive(false);
                HealthBar.SetActive(false);
                //MyCollider.enabled = false;
                PuzzleFailed = true;

            }
           
        }

    }

    public void SetTimer(Timer timer)
    {
        Timer = timer;
        TInterval = Timer.GetInterval();

        //TXCBSizeDiff = CooldownBar.transform.localScale.x / Timer.GetInterval();


    }

    void SetCDBarVal()
    {
        float Diff = CDXScale * (Timer.GetTime() / TInterval);

        CooldownBar.transform.localScale = new Vector3(Diff, 0.122529f, 1f);





    }

   private void TryCooldown()
    {
 
            cooldown -= 1;

            XCBSize += XCBSizeDiff;
            CooldownBar.transform.localScale = new Vector3(XCBSize, 0.122529f, 1f);
            if (cooldown <= 0)
            {
                XCBSize = 0;
                MyCollider.enabled = true;
                activatecooldown = false;
                cooldown = interval;
            }
       
    }

    private void FixedUpdate()
    {
        if (activatecooldown)
        {
            TryCooldown();
            return;
        }

        if (OnGoing)
        {
            SetCDBarVal();
        }
    }

    //
    public bool[] GetPuzzleStatus()
    {
        return new bool[2] { PuzzleFailed, Required };
    }



    public void SetOnGoing(bool status)
    {
        OnGoing = status;
    }

    public bool isOnGoing()
    {
        return OnGoing;
    }

}
