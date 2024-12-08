using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Player Player;
    private bool picked = false;
    public int Quantity = 5;

    void Start()
    {

        GameObject PlayerGOBJ = GameObject.Find("/Entities/Player").gameObject;
        Player = PlayerGOBJ.GetComponent<Player>();

    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            if (!picked)
            {
                picked = true;
                Player.healthUp(Quantity);
                Destroy(gameObject);
            }
        }
    }
}
