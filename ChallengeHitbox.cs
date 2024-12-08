using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeHitbox : MonoBehaviour
{
    // Start is called before the first frame update

    public Collider2D PlayerHitBox;
    public Challenges Challenges;
    public GameObject Control;
    public int MyQuestionNumber;
    public ObstacleBehavior Target;
    public Collider2D MyCollider;
    private int tries = 3;
    public int interval = 40;
    private int cooldown;
    private GameObject ExitPanel;
    private QuestionButton QuestionButton;
    private bool activatecooldown = false;
    private GameObject HealthBar;
    private GameObject CooldownBar;
    private float XCBSizeDiff = 0f;
    private float XCBSize = 0f;
    public bool StageGameOver = true;

    private void Start()
    {
        cooldown = interval;

        ExitPanel = GameObject.Find("GUI/Canvas/GameOverPanel");
        QuestionButton = Control.GetComponent<QuestionButton>();
        CooldownBar = transform.GetChild(0).gameObject;
        HealthBar = transform.GetChild(1).gameObject;
        XCBSizeDiff = CooldownBar.transform.localScale.x/interval ;

    }
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == PlayerHitBox)
        {
            Challenges.ChallengeHitbox = this;
            Control.SetActive(true);
   
            
        }
        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == PlayerHitBox)
        {

            Control.SetActive(false);
            QuestionButton.CloseQuestion();
        }
    }

    public void BoolBehave(bool bve)
    {
        
        if (bve)
        {
            Target.Activate(true);
            MyCollider.enabled = false;
            CooldownBar.SetActive(false);
            HealthBar.SetActive(false);

            if (StageGameOver)
            {
                GameObject.Find("/Entities/Player").GetComponent<PlayerProperties>().healthUp(5);
            }
   
        }
        else
        {
            CooldownBar.transform.localScale = new Vector3(0f, 0.122529f, 1f);

            tries -= 1;
            HealthBar.transform.GetChild(tries).gameObject.SetActive(false);
            if (tries>0)
            {
                MyCollider.enabled = false;
                activatecooldown = true;
            }
            else
            {
                Target.Activate(false);
                CooldownBar.SetActive(false);
                HealthBar.SetActive(false);
                MyCollider.enabled = false;
                FailBehavior();

            }
           
        }

    }


   private void TryCooldown()
    {
        cooldown -= 1;

        XCBSize += XCBSizeDiff;
        CooldownBar.transform.localScale = new Vector3(XCBSize, 0.122529f, 1f);
        if (cooldown <= 0)
        {
            XCBSize = 0;
            MyCollider.enabled = true;
            activatecooldown = false;
            cooldown = interval;
        }
    }

    private void FixedUpdate()
    {
        if (activatecooldown)
        {
            TryCooldown();
        }
    }

    private void FailBehavior()
    {
        if (StageGameOver)
        {
            ExitPanel.SetActive(true);
        }
    }
}
