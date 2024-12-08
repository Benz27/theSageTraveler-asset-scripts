using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    // Start is called before the first frame update

    public int ControlType;
    public Collider2D Jump;
    public Collider2D Left;
    public Collider2D Right;
    public Collider2D Attack;
    public Collider2D QuestionButton;
    public QuestionButton QuestionButtonScript;

    public bool Jumping = false;
    public float horizontalMove = 0f;


    void Update()
    {
        //(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        bool _jumping = false;
        float _left = 0f;
        float _right = 0f;
        if (Input.touchCount > 0)
        {

            foreach (Touch touch in Input.touches)
            {

                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((touch.position)), Vector2.zero);

                if (hit.collider == Jump && touch.phase == TouchPhase.Began)
                {
                    _jumping = true;
                }

               
                if (hit.collider == Left)
                {
                    _left = -1f;
                }

                if (hit.collider == Right)
                {
                    _right = 1f;
                }

                if (hit.collider == QuestionButton && touch.phase == TouchPhase.Began)
                {
                    QuestionButtonScript.AppearQuestion();
                }

            }

        }

        horizontalMove = (_left + _right);
        Jumping = _jumping;
    }


}
