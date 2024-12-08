using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class HandWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    [NonSerialized] public float damage = 0f;
    [NonSerialized] public float knockback = 0f;

    [SerializeField] Animator Animator;
    private bool Attack = false;
    private bool AttackCooldownFinished = true;
    private int AttackCooldown;
    private int AttackCooldownInterval = 5;
    public UnityEvent OnAttackEvent;


    private void Awake()
    {
        if (OnAttackEvent == null)
            OnAttackEvent = new UnityEvent();
    }
    private void FixedUpdate()
    {
        if (Attack)
        {
            if (!AttackCooldownFinished)
            {
                AttackCooldown -= 1;
                if (AttackCooldown <= 0)
                {
                    AttackCooldownFinished = true;
                    AttackCooldown = AttackCooldownInterval;
                    Attack = false;
                }
            }
        }
    }
    public void HandWeaponAttack()
    {
        if (!Attack)
        {
            //AttackCooldown = int.Parse(ItemProperties[ItemEquippedID][7]);
            //AttackLength = int.Parse(ItemProperties[ItemEquippedID][8]);
            //ItemEquipped.SetActive(true);

            Animator.SetBool("OverHeadAttack", true);
            OnAttackEvent.Invoke();
            Attack = true;
        }

    }

    public void AttackEnded()
    {

        Animator.SetBool("OverHeadAttack", false);
        AttackCooldown = AttackCooldownInterval;
        AttackCooldownFinished = false;
        Attack = false;

    }

    public void OverHeadAttackPeak()
    {
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
    }

    public void OverHeadAttackEnded()
    {
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
    }


    //Fetching polygon
    public void FetchPolygon()
    {

        foreach(Vector2 vector2 in GetComponent<PolygonCollider2D>().points)
        {
            Debug.Log(vector2);
        }


        //Debug.Log(GetComponent<PolygonCollider2D>().GetPath(0));






    }








}
