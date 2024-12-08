using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySFXManager : MonoBehaviour
{
    [SerializeField] string Jump;
    [SerializeField] string Hurt;
    [SerializeField] string Attack;
    [SerializeField] string HealthUp;
    [SerializeField] string CoinUp;
    [SerializeField] string Correct;
    [SerializeField] string InCorrect;
    [SerializeField] GameSFX GameSFX;

    public void JumpSFX()
    {
        GameSFX.PlaySFX(Jump);
    }

    public void HurtSFX()
    {
        GameSFX.PlaySFX(Hurt);
    }
    public void AttackSFX()
    {
        GameSFX.PlaySFX(Attack);
    }

    public void HealthUpSFX()
    {
        GameSFX.PlaySFX(HealthUp);
    }


    public void CoinUpSFX()
    {
        GameSFX.PlaySFX(CoinUp);
    }

    public void CorrectSFX()
    {
        GameSFX.PlaySFX(Correct);
    }

    public void InCorrectSFX()
    {
        GameSFX.PlaySFX(InCorrect);
    }
}
