using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    
    public PlayerMovement PlayerMovement;
    public GameControl GameControl;
    public PuzzleManager PuzzleManager;
    public GameObject QuestionButton;
    public Player Player;


    bool Hit = false;
    public float timer = 0.3f;

    //Transform MPlatform;


    //private void Update()
    //{
    //    if (MPlatform != null)
    //    {

    //        Debug.Log(transform.parent.transform.position);
    //        transform.parent.transform.position = new Vector2(transform.position.x, transform.position.y) + MPlatform.GetComponent<Rigidbody2D>().velocity * Time.deltaTime;
    //    }
    //}





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ExitDoor")
        {
            GameControl.StageFinished();
            return;
        }
        if (collision.tag == "TutorialExitDoor")
        {
            GameControl.ToGame();
            return;
        }
        if (collision.tag == "ExitDoorToStage3")
        {
            GameControl.StageFinished();
            return;
        }
        if (collision.tag == "PuzzleTrigger")
        {
            PuzzleManager.SetActivePuzzleTrigger(collision.gameObject.GetComponent<PuzzleTrigger>());
            QuestionButton.SetActive(true);
        }

        //if (collision.CompareTag("MovingPlatform"))
        //{
        //    MPlatform = collision.transform;
        //}




    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PuzzleTrigger")
        {
            QuestionButton.SetActive(false);
            PuzzleManager.CloseMPPanel();
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

        if (collision.tag == "Fire" && Hit == false)
        {
            Hit = true;
            StartCoroutine(Countdown());
            float push = -1f;
            int damage = 2;

            if ((collision.transform.position.x - gameObject.transform.position.x) < 0)
            {
                push = 1f;
            }
            Player.hurt(push, damage);
        }

        if ((collision.tag == "Lava" || collision.tag == "Pit") && Hit == false)
        {
            //Hit = true;
            //StartCoroutine(Countdown());
            //float push = 0f;
            //int damage = 7;

            //Player.hurt(push, damage);

            Player.PlayerDie();
        }

    }

    IEnumerator Countdown()
    {
        while (Hit)
        {
            yield return new WaitForSeconds(timer);
            Hit=false;
        }

    }
}
