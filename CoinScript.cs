using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Player Player;
    private bool picked = false;
    public int Quantity = 1;
    public bool isCoin = true;

    [SerializeField] Collider2D PickUpCollider;

    void Awake()
    {
            
            GameObject PlayerOBJ = GameObject.Find("/Entities/Player").gameObject;
        Player = PlayerOBJ.GetComponent<Player>();

            if(PickUpCollider == null)
        {
            PickUpCollider = gameObject.GetComponent<CircleCollider2D>();
        }

            StartCoroutine(EnableColliderAfterDelay());
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {

            if (!picked)
            {
                picked = true;
                Player.addCollectibles(Quantity, isCoin);
                Destroy(gameObject);
            }
        } 
    }

    private IEnumerator EnableColliderAfterDelay()
    {
        // Wait for one second
        yield return new WaitForSeconds(0.2f);

        // Enable the collider component
        PickUpCollider.enabled = true;
    }


}
