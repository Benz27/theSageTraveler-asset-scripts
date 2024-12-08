using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    [SerializeField] Image Message;
    [SerializeField] Sprite[] MessageTemplate;
    bool Active = false;



    public void PlayerDied()
    {
        if (!Active)
        {
            Active = true;
            Message.sprite = MessageTemplate[0];
            gameObject.SetActive(true);
        }

    }

    public void PuzzleFailed()
    {
        if (!Active)
        {
            Active = true;
            Message.sprite = MessageTemplate[1];
            gameObject.SetActive(true);
        }
    }






}
