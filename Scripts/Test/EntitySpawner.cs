using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] GameObject MobsCont;
    [SerializeField] GameObject ItemsCont;

    [SerializeField] GameObject GemsCont;
    [SerializeField] GameObject HealthUpsCont;


    Dictionary<string, GameObject> Entities = new();

    private void Awake()
    {
        InitializeEntities();
        //StartSpawn(STGMobsCont);
    }


    public void InitializeEntities()
    {
        foreach (Transform child in MobsCont.transform)
        {
            Entities.Add(child.name, child.gameObject);
        }

        foreach (Transform child in ItemsCont.transform)
        {
            Entities.Add(child.name, child.gameObject);
        }

        foreach (Transform child in GemsCont.transform)
        {
            Entities.Add(child.name, child.gameObject);
        }

        foreach (Transform child in HealthUpsCont.transform)
        {
            Entities.Add(child.name, child.gameObject);
        }
    }
    //, GameObject StageContItems, GameObject StageContGems, GameObject StageContHealthUps

    public void StartSpawn(GameObject StageContMobs)
    {
        foreach (Transform child in StageContMobs.transform)
        {
            string MobName = child.GetComponent<TargetSpawner>().EntityName;
            foreach (Transform Mobs in child)
            {
                GameObject Mob = Instantiate(Entities[MobName]);
                Mob.transform.SetParent(StageContMobs.transform);
                Mob.transform.localPosition = Mobs.localPosition;
                Destroy(Mobs.gameObject);
            }
        }
    }


    public void IndividualSpawn(GameObject Spawner)
    {
        GameObject Mob = Instantiate(Entities[Spawner.GetComponent<TargetSpawner>().EntityName]);
        Mob.transform.SetParent(Spawner.transform.parent.transform);
        Mob.transform.localPosition = Spawner.transform.localPosition;
        Destroy(Spawner);
    }
}
