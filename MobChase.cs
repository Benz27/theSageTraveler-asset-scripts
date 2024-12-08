using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobChase : MonoBehaviour
{
    public GameObject ObjectToChase;
    public MobMovement MobMovement;

    private int GetToTargetLocation()
    {
        int x = 1;
        if ((gameObject.transform.position.x-ObjectToChase.transform.position.x)<0)
        {
            x = -1;
        }

        return x;
    }

}
