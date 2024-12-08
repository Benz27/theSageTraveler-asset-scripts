using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class PlayerProperties : MonoBehaviour
{


    public float PlayerDamage = 0f;
    public float PlayerDefense = 0f;
   [NonSerialized] public int CoinsCollected = 0;
   [NonSerialized] public int TreassuresCollected = 0;


    public PlayerMovement PlayerMovement;


    public PlayerHealth PlayerHealth;

    public Collider2D MainCollider;
    public Collider2D Hitbox;
    public Rigidbody2D Rigidbody2D;






    public void hurt(float push, int damage)
    {
        PlayerMovement.hit(push);
        PlayerHealth.hit(damage);

  
    }


    public void healthUp(int health)
    {
        PlayerHealth.healthup(health);

    }

    public void PlayerDie()
    {
       
        Hitbox.enabled = false;

        GameObject ExitPanel = GameObject.Find("GUI/Canvas/GameOverPanel");
        ExitPanel.SetActive(true);
  
    }




   
}
