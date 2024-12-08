using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Player Player;
    int CoinsCollected = 0;
    int TreassuresCollected = 0;

    public void AddCoins(int qnt)
    {
        CoinsCollected += qnt;
    }

    public void AddTreasures(int qnt)
    {
        TreassuresCollected += qnt;
    }

    public void SetCoins(int qnt)
    {
        CoinsCollected = qnt;

        Player.setCollectiblesText();
    }

    public void SetTreasures(int qnt)
    {
        TreassuresCollected = qnt;
    }


    public void Display()
    {

    }




    public int GetCoins()
    {
        return CoinsCollected;
    }

    public int GetTreassures()
    {
        return TreassuresCollected;
    }

    public void SetCollectibles(int Coins, int Treasures)
    {

    }


}
