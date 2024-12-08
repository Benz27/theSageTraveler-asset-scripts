using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public int ObstacleID;
    private delegate void FunctionToActivate();
    private FunctionToActivate Action;
    private bool Behave;
    private float from_x, to_x, x_diff, x_iterate, starting_x = 0;
    private bool x_move = false;
    private void Awake()
    {
        switch (ObstacleID)
        {
            case 1:
                Action = SetActiveFalse;
            break;
            case 2:
                Action = SetActiveTrue;
                gameObject.SetActive(false);
            break;
            case 3:
                Action = PlatformMoveUp;
            break;
            case 4:
                Action = PlatformSpin;
            break;
            case 5:
                Action = MultiplePlatformSpin;
                break;
            case 6:
                Action = MultiplePlatformMoveUp;
                break;
        }
    }


    void MultiplePlatformSpin()
    {

        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<Spin>().Activate();
        }


        
    }

    void MultiplePlatformMoveUp()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<MovingPlatform>().Activate();
        }
    }


    void PlatformMoveUp()
    {
       transform.GetChild(0).gameObject.GetComponent<MovingPlatform>().Activate();
    }

    void PlatformSpin()
    {
        transform.GetChild(0).gameObject.GetComponent<Spin>().Activate();
    }

    private void FixedUpdate()
    {
        GameObjectMoveX(x_iterate);
    }

    public void Activate(bool bve)
    {
        Behave = bve;
        Action();
    }

    private void SetActiveFalse()
    {
        if (Behave)
        {
            gameObject.SetActive(false);
        
        }
   
    }


    private void SetActiveTrue()
    {
        if (Behave)
        {
            gameObject.SetActive(true);

        }

    }

    private void CaveDoorBve()
    {
        if (Behave)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(false);
 
        }

    }

    private void GameObjectMoveStage1()
    {
        if (Behave)
        {
            from_x = 19;
            to_x = 35;
            x_diff = to_x - from_x;
            x_iterate = 5f;
            x_move = true;

        }
    }

    private void GameObjectMoveX(float iterate)
    {

        if (x_move)
        {
            transform.position = new Vector3(transform.position.x + iterate * Time.deltaTime, transform.position.y+0, transform.position.z + 0);
            starting_x += iterate;
            if (starting_x == 775)
            {
                x_move = false;
                starting_x = 0;
            }
        }


    }
}
