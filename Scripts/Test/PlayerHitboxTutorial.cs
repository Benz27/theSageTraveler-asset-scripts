using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitboxTutorial : MonoBehaviour
{

    public PlayerMovement PlayerMovement;
    public TutorialControl TutorialControl;
    public PuzzleManagerTutorial PuzzleManagerTutorial;
    public GameObject QuestionButton;
    public Player Player;
    bool Hit = false;
    public float timer = 0.3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ExitDoor")
        {
            //GameControl.GoToStage2();
            return;
        }
        if (collision.tag == "TutorialExitDoor")
        {
            TutorialControl.TutorialFinished();
            return;
        }
        if (collision.tag == "ExitDoorToStage3")
        {
            //GameControl.GoToStage3();
            return;
        }
        if (collision.tag == "PuzzleTrigger")
        {
            PuzzleManagerTutorial.ActivePuzzleTrigger = collision.gameObject.GetComponent<PuzzleTrigger>();
            QuestionButton.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PuzzleTrigger")
        {
            QuestionButton.SetActive(false);
            PuzzleManagerTutorial.CloseMPPanel();
        }
        //if (collision.CompareTag("MovingPlatform"))
        //{
        //    MPlatform = null;
        //}

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Hostile" && Hit == false)
        {
            Hit = true;
            StartCoroutine(Countdown());
            float push = -1f;
            int damage = collision.gameObject.transform.GetChild(3).gameObject.GetComponent<MobHitBox>().damage;

            if ((collision.transform.position.x - gameObject.transform.position.x) < 0)
            {
                push = 1f;
            }
            Player.hurt(push, damage);
        }
    }

    IEnumerator Countdown()
    {
        while (Hit)
        {
            yield return new WaitForSeconds(timer);
            Hit = false;
        }

    }
}
