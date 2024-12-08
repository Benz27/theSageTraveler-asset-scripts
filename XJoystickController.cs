using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XJoystickController : MonoBehaviour
{

    private GameObject ControllerObj;
    [NonSerialized] public float AttackDirection;
    [NonSerialized] public bool isAttacking;
    public CharacterController2D CharacterController2D;
    public Camera MainCam;
    public TouchInput TouchInput;
    Vector2 ControllerPos, relativePosition, mousePosRelToCam, finalPos;
    //float finalPosOnContX;
    //float finalPosOnContY;
    void Start()
    {

        ControllerObj = gameObject.transform.GetChild(0).gameObject;
        relativePosition = transform.position - MainCam.transform.position;
        //relativePosition = transform.position;
        JoyStickBehavior(false);
    }



    public void ControllerMoved()
    {
        JoyStickBehavior(true);
    }


    public void ControllerEnded()
    {
        JoyStickBehavior(false);
    }

    public void ControllerBegan()
    {
        JoyStickBehavior(true);
    }

    private void JoyStickBehavior(bool Moved)
    {
        float loc_AttackDirection = 0f;
        bool loc_isAttacking = false;
        ControllerPos = transform.position;
        finalPos = new Vector2(0f, 0f);
        if (Moved)
        {
            loc_isAttacking = true;

                mousePosRelToCam = TouchInput.TouchPosRelToCam;
                finalPos = mousePosRelToCam - relativePosition;
                finalPos.x -= MainCam.transform.position.x;
                finalPos.y -= MainCam.transform.position.y;
                ControllerPos.x = mousePosRelToCam.x;
                
              
                if (finalPos.x > 0.2)
                {
                    loc_AttackDirection = 1f;
                }

                if (finalPos.x < 0.2)
                {
                    loc_AttackDirection = -1f;
                }

                if (finalPos.x > 1)
                {
                    ControllerPos.x -= (mousePosRelToCam.x - (MainCam.transform.position.x + 1)) - relativePosition.x;
                }

                if (finalPos.x < -1)
                {
                    ControllerPos.x -= (mousePosRelToCam.x - (MainCam.transform.position.x - 1)) - relativePosition.x;
                }
               
        }
        
        //ControllerObj.transform.localPosition = finalPos;
        AttackDirection = loc_AttackDirection;
        isAttacking = loc_isAttacking;
        ControllerObj.transform.position = ControllerPos;
        CharacterController2D.SetAttackingDirection(AttackDirection, isAttacking);

    }
}
