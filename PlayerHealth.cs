using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{

    public int TotalHealth = 20;
    private int DamageTaken = 0;
    private int HealthUp = 0;
    public PlayerProperties PlayerProperties;
    private float difference = 0.05f;
    Slider HealthSlider;



    void Awake()
    {
        HealthSlider = GetComponent<Slider>();
        HealthSlider.maxValue = 1;
        HealthSlider.value = 1;
    }


    void Update()
    {
        if (TotalHealth > 0)
        {
        if (DamageTaken>0)
        {

            int CurrentDamage = DamageTaken;
            TotalHealth -= CurrentDamage;
            DamageTaken -= CurrentDamage;
            float slidevalue = TotalHealth * difference;
            HealthSlider.value = slidevalue;

            if (TotalHealth <= 0)
            {
                    //PlayerProperties.PlayerDie();
                    TotalHealth = 20;
                    float slidevalue2 = TotalHealth * difference;
                    HealthSlider.value = slidevalue2;
            }
  

        }

        if (HealthUp > 0)
        {
                if (HealthSlider.value >= 1)
                {
                    HealthUp = 0;
                }
                else {
                    int CurrentHealthUp = HealthUp;
                    TotalHealth += CurrentHealthUp;
                    HealthUp -= CurrentHealthUp;
                    float slidevalue = TotalHealth * difference;
                    HealthSlider.value = slidevalue;
                }
               

               
            }
        }
    }

    public void hit(int damage)
    {
        DamageTaken += damage;
      
    }

    public void healthup(int healthup)
    {
        HealthUp += healthup;
    }




}

