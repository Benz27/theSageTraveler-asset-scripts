using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHitBox : MonoBehaviour
{
    // Start is called before the first frame update
    public MobMovement MobMovement;
    public int damage = 2;
    public int interval = 50;
    public int interval_beinghit = 0;
    private bool Hitting = false;
    private bool BeingHit = false;
    private int timer;
    private int timer_beinghit;

    private void Start()
    {
        timer = interval;
    }

    private void FixedUpdate()
    {
        timerCountdown();
        timer_beinghitCountdown();
    }

    void timerCountdown()
    {
        if (Hitting && timer>0)
        {
            timer--;
        }

        if (timer<=0)
        {
            timer = interval;
            Hitting = false;
        }
    }

    void timer_beinghitCountdown()
    {
        if (BeingHit && timer_beinghit > 0)
        {
            timer_beinghit--;
        }

        if (timer_beinghit <= 0)
        {
            timer_beinghit = interval_beinghit;
            BeingHit = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PlayerWeapon")
        {

            
                float push = collision.transform.gameObject.GetComponent<HandWeapon>().knockback;
                if ((gameObject.transform.position.x - collision.transform.position.x) < 0)
                {
                    push *= -1f;
                }
                float damage = collision.transform.gameObject.GetComponent<HandWeapon>().damage;
                MobMovement.hurt(push, (int)damage);
            
        }
        //else if(collision.tag == "Player")
        //{
        //    if (!Hitting)
        //    {
        //        Hitting = true;
        //        float push = -10f;
        //        if ((gameObject.transform.position.x - collision.transform.position.x) < 0)
        //        {
        //            push = 10f;
        //        }
        //        collision.transform.parent.gameObject.GetComponent<PlayerProperties>().hurt(push, damage);

        //    }
            
        //}

    }

}
