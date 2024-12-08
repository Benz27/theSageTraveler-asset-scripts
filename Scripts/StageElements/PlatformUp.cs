using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUp : MonoBehaviour
{
    public float speed = 5f; // The speed of the platform
    public GameObject endpoint; // The endpoint game object
    public float stopDistance = 0.1f; // The distance at which the platform should stop moving
    public Vector2 force = new Vector2(0f, 100f); // The force to apply to the platform to move it upward


    public Transform Platform;


    private bool Active; // Whether the platform is currently moving



    private void Update()
    {
        // If the platform is not moving, return
        if (!Active) return;

        // Calculate the distance between the platform and the endpoint
        float dist = Vector2.Distance(Platform.position, endpoint.transform.position);

        // If the platform is close enough to the endpoint, stop moving
        if (dist <= stopDistance)
        {
            Platform.position = endpoint.transform.position;
            Active = false;
        }
        else
        {
            // Move the platform upward
            Platform.Translate(force * Time.deltaTime);
        }
    }


    public void Activate()
    {
        Active = true;
    }



    
}
