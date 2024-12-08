using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{

    public MobMovement MobMovement;
    private bool PlayerCollision = false;

    private void Update()
    {
        MobMovement.Onradar = PlayerCollision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == MobMovement.ObjectToChase.tag)
        {
            PlayerCollision = false;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == MobMovement.ObjectToChase.tag)
        {
            PlayerCollision = true;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if (collision.tag == MobMovement.ObjectToChase.tag)
    //    {
    //        PlayerCollision = true;
    //        MobMovement.Onradar = true;
    //    }
    //    else
    //    {
    //        MobMovement.Onradar = false;
    //    }
    //    Debug.Log(MobMovement.Onradar);
    //}

}
