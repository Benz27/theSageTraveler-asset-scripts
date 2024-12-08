using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject PlayerGOBJ;
    [SerializeField] PlayerProgress PlayerProgress;
    [SerializeField] HandWeapon HandWeapon;

    [SerializeField] GUIManager GUIManager;
    [SerializeField] Collider2D PlayerHitbox;
    [SerializeField] GameSFX GameSFX;

    bool HitCDbool = false;
    public UnityEvent OnHurtEvent;
    public UnityEvent OnHealthUpEvent;
    public UnityEvent OnCoinUpEvent;
    //

    //health
    public int TotalHealth = 40;
    int DamageTaken = 0;
    int HealthUp = 0;
    float difference = 0.05f;

    void Awake()
    {

        if (OnHurtEvent == null)
            OnHurtEvent = new UnityEvent();

        if (OnHealthUpEvent == null)
            OnHealthUpEvent = new UnityEvent();

        if (OnCoinUpEvent == null)
            OnCoinUpEvent = new UnityEvent();
        
        setCollectiblesText();
    }

    void Update()
    {
        HealthModif();
    }

    public void setCollectiblesText()
    {
        GUIManager.setCoinText(PlayerProgress.GetCoins());
        GUIManager.setTreasureText(PlayerProgress.GetTreassures());
    }



    public void addCollectibles(int qnt, bool isCoin)
    {
        if (isCoin)
        {
            PlayerProgress.AddCoins(qnt);
            OnCoinUpEvent.Invoke();
            GUIManager.setCoinText(PlayerProgress.GetCoins());
            return;
        }
        PlayerProgress.AddTreasures(qnt);
        GUIManager.setTreasureText(PlayerProgress.GetTreassures());
    }



    public void healthUp(int healthup)
    {
        HealthUp += healthup;
        OnHealthUpEvent.Invoke();
    }

    public void damagePlayer(int damage)
    {
        DamageTaken += damage;

    }

    public void SetHealth(int health)
    {
        TotalHealth = health;
        GUIManager.SetHealthSliderVal(TotalHealth * difference);
    }



    void HealthModif()
    {
        if (TotalHealth > 0)
        {
            if (DamageTaken > 0)
            {

                int CurrentDamage = DamageTaken;
                TotalHealth -= CurrentDamage;
                DamageTaken -= CurrentDamage;
                float slidevalue = TotalHealth * difference;
                //HealthSlider.value = slidevalue;

                GUIManager.SetHealthSliderVal(slidevalue);

                if (TotalHealth <= 0)
                {
                    PlayerDie();
                    //TotalHealth = 20;
                    //HealthSlider.value = slidevalue2;
                    //GUIManager.SetHealthSliderVal(TotalHealth * difference);
                }


            }

            if (HealthUp > 0)
            {
                if (GUIManager.GetHealthSliderVal() >= 1)
                {
                    HealthUp = 0;
                }
                else
                {
                    int CurrentHealthUp = HealthUp;
                    TotalHealth += CurrentHealthUp;
                    HealthUp -= CurrentHealthUp;
                    float slidevalue = TotalHealth * difference;
                    GUIManager.SetHealthSliderVal(slidevalue);
                }

            }
        }
    }



    public void OverLeapingAnimFinished()
    {
        HandWeapon.OverHeadAttackEnded();
    }

    public void OverHeadAttackPeak()
    {
        HandWeapon.OverHeadAttackPeak();
    }

    public void hurt(float push, int damage)
    {
        //PlayerMovement.hit(push);
        if (!HitCDbool)
        {
            damagePlayer(damage);
            OnHurtEvent.Invoke();
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(400f * push, 300f));
            
            HitCDbool = true;
            StartCoroutine(HitCD());
        }

    }

    public void PlayerDie()
    {

        //PlayerHitbox.enabled = false;

       

        GUIManager.GameOver();
        DisablePlayer();
    }

    private IEnumerator HitCD()
    {
        // Wait for one second
        yield return new WaitForSeconds(0.5f);

        // Enable the collider component
        HitCDbool = false;


    }



    public void DisablePlayer()
    {
        gameObject.SetActive(false);
    }


}
