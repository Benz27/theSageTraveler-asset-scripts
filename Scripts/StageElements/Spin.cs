using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 100f;

    public HingeJoint2D hinge;

    bool Active = false;

    private void FixedUpdate()
    {
        if (Active)
        {
            JointMotor2D motor = hinge.motor;
            motor.motorSpeed = speed;
            hinge.motor = motor;
            
        }
    
    }

    public void Activate()
    {
        
        Active = true;
    }



}
