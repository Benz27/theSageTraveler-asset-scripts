using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    float horzcontrol = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    private Controls Controls;
    private Equipment Equipment;
    private JoyStickController joyStickController;

    bool allowmove = true;

    void Start()
    {
        SetComponents();
        
    }

    // Update is called once per frame

    void SetComponents()
    {
        Equipment = GameObject.Find("/Entities/Player/Equipment").GetComponent<Equipment>();
        controller = gameObject.GetComponent<CharacterController2D>();
        Controls = GameObject.Find("/GUI/Canvas/Controls").GetComponent<Controls>();

        joyStickController = GameObject.Find("/GUI/Canvas/Controls/Joystick/ControllerBase").GetComponent<JoyStickController>();
    }

    public void RightPressed()
    {
        horzcontrol += 1f;
    }

    public void RightReleased()
    {
        horzcontrol -= 1f;
    }

    public void LeftPressed()
    {
        horzcontrol -= 1f;
    }

    public void LeftReleased()
    {
        horzcontrol += 1f;
    }

    public void JumpPressed()
    {
        jump = true;

        animator.SetBool("Jumping", true);
    }

    void Update()
    {
        if (allowmove)
        {
            horizontalMove = horzcontrol * runSpeed;
            //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            //horizontalMove = joyStickController.horizontalMove * runSpeed;
        }


        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));

        //Input.GetButtonDown("Jump")
        //joyStickController.jump

        //if (Input.GetButtonDown("Jump"))
        //{

        //    jump = true;

        //    animator.SetBool("Jumping", true);


        //}


        //if (Input.GetButtonDown("Crouch"))
        //{
        //    crouch = true;
        //} else if(Input.GetButtonUp("Crouch"))
        //{
        //    crouch = false;
        //}

        //if (!jumping)
        //{
        //    animator.SetBool("Jumping", false);
        //}



    }


    public void OnLanding()
    {

        animator.SetBool("Jumping", false);
        
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void hit(float push)
    {
        allowmove = false;
        controller.Hurt(push, 300f);
        allowmove = true;
    }



}
