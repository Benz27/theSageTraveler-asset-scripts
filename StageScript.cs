using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StageScript : MonoBehaviour
{


    Vector2 Spawn;

    public void StageLoad(int index)
    {
 

        if(index == 0)
        {
            Vector2 SpawnerPosition = GameObject.Find("/Stages/Stage1(Clone)/PlayerSpawn").transform.position;
            Spawn = new Vector2(SpawnerPosition.x, SpawnerPosition.y);

            return;
        }


        if(index == 1)
        {
            Vector2 SpawnerPosition = GameObject.Find("/Stages/Stage2(Clone)/PlayerSpawn").transform.position;
            Spawn = new Vector2(SpawnerPosition.x, SpawnerPosition.y);
            return;
        }

        if (index == 2)
        {
            Vector2 SpawnerPosition = GameObject.Find("/Stages/Stage3(Clone)/PlayerSpawn").transform.position;
            Spawn = new Vector2(SpawnerPosition.x, SpawnerPosition.y);
            return;
        }

        if (index == 3)
        {
            Vector2 SpawnerPosition = GameObject.Find("/Stages/Stage4(Clone)/PlayerSpawn").transform.position;
            Spawn = new Vector2(SpawnerPosition.x, SpawnerPosition.y);
            return;
        }




    }





    public Vector2 GetSpawnPos()
    {
        return Spawn;
    }

   
}

