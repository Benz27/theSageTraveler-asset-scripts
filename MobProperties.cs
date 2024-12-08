using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class MobProperties : MonoBehaviour
{
    // Start is called before the first frame update
    public int TotalHealth = 30;
    private int DamageTaken = 0;
    private int HealthUp = 0;
    private float difference = 0.05f;

    [SerializeField] GameObject GoldCoin;
    [SerializeField] GameObject CoinsParent;
    [SerializeField] int MinCoinDrop;
    [SerializeField] int MaxCoinDrop;
    List<GameObject> CoinsToSpawn = new List<GameObject>();
    public UnityEvent OnHurtEvent;


    int CoinDropQnt = 0;
    void Awake()
    {
        if (OnHurtEvent == null)
            OnHurtEvent = new UnityEvent();

        if (CoinsParent == null)
        {
            CoinsParent = GameObject.Find("Entities/Collectibles/Coins");
        }

        if (MinCoinDrop > MaxCoinDrop)
        {
            MinCoinDrop = 0;
            MaxCoinDrop = 0;
            
        }

        CoinDropQnt = Random.Range(MinCoinDrop, MaxCoinDrop);

        if(CoinDropQnt > 0)
        {
            CoinDropQnt++;
        }

        for (int i = MinCoinDrop; i < CoinDropQnt; i++)
        {
            
            GameObject CoinDrop = Instantiate(GoldCoin);
            //CoinDrop.transform.SetParent(CoinsParent.transform);
            CoinDrop.transform.SetParent(transform.parent);
            CoinsToSpawn.Add(CoinDrop);
        }
    }

    void Update()
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
                
                if (TotalHealth <= 0)
                {
                    //PlayerProperties.PlayerDie();
                    MobDie();
                }

            }

            if (HealthUp > 0)
            {

            }
        }
    }

    public void hit(int damage)
    {
        DamageTaken += damage;
        OnHurtEvent.Invoke();
    }

    public void healthup(int healthup)
    {
        HealthUp += healthup;
    }

    void MobDie()
    {



        gameObject.SetActive(false);

        foreach (GameObject Coin in CoinsToSpawn)
        {
            Coin.transform.position = transform.position;
            Rigidbody2D coinRb = Coin.GetComponent<Rigidbody2D>();
            Coin.SetActive(true);
            coinRb.AddForce(new Vector2(Random.Range(-100, 100), 100));
        }


        Destroy(gameObject);

    }



}
