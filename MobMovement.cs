using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MobMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;
    public MobProperties MobProperties;
    //public Animator animator;
    float horizontalMove = 0f;
    
    bool jump = false;
    bool crouch = false;
    bool allowmove = true;
    private int leapingCooldown;
    private bool leaped = false;
    [NonSerialized] public GameObject ObjectToChase;
    public GameObject Radar;

    public bool Onradar = false;
    public bool log;

    //
    public bool isLeaping = false;
    public int leapingCooldownInterval = 50;
    public float runSpeed = 40f;
    //

    private delegate void FunctionToActivate();
    private FunctionToActivate ActionMove;

    private void Awake()
    {
        ObjectToChase = GameObject.FindGameObjectWithTag("Player");
        switch (isLeaping)
        {
            case true:
                ActionMove = LeapingMove;
                leapingCooldown = leapingCooldownInterval;
                break;
            case false:
                ActionMove = NormalMove;
                break;

        }
    }

    private int GetToTargetLocation()
    {
        int x = -1;
        if ((gameObject.transform.position.x - ObjectToChase.transform.position.x) < 0)
        {
            x = 1;
        }

        return x;
    }



    void Update()
    {


        if (allowmove)
        {
            ActionMove();
        }

       
    }


    public void NormalMove()
    {
        if (Onradar)
        {
            horizontalMove = GetToTargetLocation() * runSpeed;
        }
        else
        {
            horizontalMove = 0;
        }
    }

    public void LeapingMove()
    {

        if (!leaped)
        {

            if (Onradar)
            {
                leapingCooldown = leapingCooldownInterval;
                jump = true;
                horizontalMove = GetToTargetLocation() * runSpeed;
            }
            else
            {
                jump = false;
                horizontalMove = 0;
            }
        }
        
    }

    public void OnLanding()
    {

        leaped = true;
    }



    void FixedUpdate()
    {
        if (leaped && isLeaping)
        {
            jump = false;
            horizontalMove = 0;
            leapingCooldown -= 1;
            if (leapingCooldown == 0)
            {
                leaped = false;
            }
        }

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false;

        

    }

 

    public void hurt(float push, int damage)
    {
        controller.Hurt(push, 340f);
        MobProperties.hit(damage);
    }

}
