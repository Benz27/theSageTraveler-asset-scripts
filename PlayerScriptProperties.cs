using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class PlayerScriptProperties : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController2D CharacterController2D;
    private PlayerMovement PlayerMovement;
    private PlayerHealth PlayerHealth;
    private PlayerProperties PlayerProperties;
    private Equipment Equipment;
    private GameObject Player;

    public HandWeapon HandWeapon;
    public TextMeshProUGUI CoinsEarnedText;
    public TextMeshProUGUI TreasuresEarnedText;

    void Awake()
    {
        Player = GameObject.Find("/Entities/Player").gameObject;
        Equipment = Player.transform.Find("Equipment").gameObject.GetComponent<Equipment>();
        PlayerHealth = Player.GetComponent<PlayerHealth>();
        PlayerMovement = Player.GetComponent<PlayerMovement>();
        CharacterController2D = Player.GetComponent<CharacterController2D>();
        PlayerProperties = Player.GetComponent<PlayerProperties>();
        setCollectiblesText();
    }


    public void setCollectiblesText()
    {
        setCoinText();
        setTreasureText();
    }

    public void setCoinText()
    {
        CoinsEarnedText.text = "" + PlayerProperties.CoinsCollected;
    }

    public void setTreasureText()
    {
        TreasuresEarnedText.text = "" + PlayerProperties.TreassuresCollected;
    }


    public void addCollectibles(int qnt, bool isCoin)
    {
        if (isCoin)
        {
            PlayerProperties.CoinsCollected += qnt;
            setCoinText();
            return;
        }
        PlayerProperties.TreassuresCollected += qnt;
        setTreasureText();
    }

    public void addHealth(int qnt)
    {

        PlayerProperties.healthUp(qnt);

    }

    public void OverLeapingAnimFinished()
    {
        HandWeapon.OverHeadAttackEnded();
    }

    public void OverHeadAttackPeak()
    {
        HandWeapon.OverHeadAttackPeak();
    }


}
