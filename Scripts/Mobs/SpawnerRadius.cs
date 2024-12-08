using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;



public class SpawnerRadius : MonoBehaviour
{
    [SerializeField] EntitySpawner EntitySpawner;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spawner"))
        {
            EntitySpawner.IndividualSpawn(collision.gameObject);
        }
    }
}
