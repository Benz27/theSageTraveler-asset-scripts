using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickController : MonoBehaviour
{

    private GameObject ControllerObj;
    private bool ControllerMoving = false;
    [NonSerialized] public float horizontalMove;
    [NonSerialized] public bool jump;
    public TouchInput TouchInput;

    private bool jumped = false;
    public Camera MainCam;
    Vector2 ControllerPos, relativePosition, mousePosRelToCam, finalPos;
    //float finalPosOnContX;
    //float finalPosOnContY;
    void Awake()
    {
        ControllerObj = gameObject.transform.GetChild(0).gameObject;
        relativePosition = transform.position - MainCam.transform.position;
        JoyStickBehavior(false);
        //relativePosition = transform.position;
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
        float loc_horizontalMove = 0f;
        bool loc_jump = false;
        ControllerPos = transform.position;
        finalPos = new Vector2(0f, 0f);

        if (Moved)
        {
            mousePosRelToCam = TouchInput.TouchPosRelToCam;
            finalPos = mousePosRelToCam - relativePosition;
            finalPos.x -= MainCam.transform.position.x;
            finalPos.y -= MainCam.transform.position.y;
            ControllerPos = mousePosRelToCam;
            loc_horizontalMove = -1f;
            if (finalPos.x > 0)
            {
                loc_horizontalMove = 1f;
            }

            if (finalPos.y > 0.3)
            {
                if (!jumped)
                {
                    jumped = true;
                    loc_jump = true;
                }
            }
            else
            {
                jumped = false;
            }

            if (finalPos.x > 1)
            {
                ControllerPos.x -= (mousePosRelToCam.x - (MainCam.transform.position.x + 1)) - relativePosition.x;
            }

            if (finalPos.x < -1)
            {
                ControllerPos.x -= (mousePosRelToCam.x - (MainCam.transform.position.x - 1)) - relativePosition.x;
            }

            if (finalPos.y > 1)
            {
                ControllerPos.y -= (mousePosRelToCam.y - (MainCam.transform.position.y + 1)) - relativePosition.y;
            }

            if (finalPos.y < -1)
            {
                ControllerPos.y -= (mousePosRelToCam.y - (MainCam.transform.position.y - 1)) - relativePosition.y;
            }
        }
        else
        {
            jumped = false;
        }
        //ControllerObj.transform.localPosition = finalPos;
        horizontalMove = loc_horizontalMove;
        jump = loc_jump;
        ControllerObj.transform.position = ControllerPos;

    }

    private void JoyStickBehavior_Backup()
    {
        float loc_horizontalMove = 0f;
        bool loc_jump = false;
        ControllerPos = transform.position;
        finalPos = new Vector2(0f, 0f);

        if (ControllerMoving)
        {
            Vector2 mousePos = Input.mousePosition;
            {
                mousePosRelToCam = MainCam.ScreenToWorldPoint(mousePos);
                finalPos = mousePosRelToCam - relativePosition;
                finalPos.x -= MainCam.transform.position.x;
                finalPos.y -= MainCam.transform.position.y;
                ControllerPos = mousePosRelToCam;
                loc_horizontalMove = -1f;
                if (finalPos.x > 0)
                {
                    loc_horizontalMove = 1f;
                }

                if (finalPos.y > 0.3)
                {
                    if (!jumped)
                    {
                        jumped = true;
                        loc_jump = true;
                    }
                }
                else
                {
                    jumped = false;
                }

                if (finalPos.x > 1)
                {
                    ControllerPos.x -= (mousePosRelToCam.x - (MainCam.transform.position.x + 1)) - relativePosition.x;
                }

                if (finalPos.x < -1)
                {
                    ControllerPos.x -= (mousePosRelToCam.x - (MainCam.transform.position.x - 1)) - relativePosition.x;
                }

                if (finalPos.y > 1)
                {
                    ControllerPos.y -= (mousePosRelToCam.y - (MainCam.transform.position.y + 1)) - relativePosition.y;
                }

                if (finalPos.y < -1)
                {
                    ControllerPos.y -= (mousePosRelToCam.y - (MainCam.transform.position.y - 1)) - relativePosition.y;
                }
            }
        }
        else
        {
            jumped = false;
        }
        //ControllerObj.transform.localPosition = finalPos;
        horizontalMove = loc_horizontalMove;
        jump = loc_jump;
        ControllerObj.transform.position = ControllerPos;
    }
}
