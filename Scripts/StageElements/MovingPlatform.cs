using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2.0f;
    public Transform endpoint1;
    public Transform endpoint2;

    public Transform Platform;
    bool Active = false;







    void Update()
    {
        if (Active)
        {


            float distance = Mathf.PingPong(Time.time * speed, Vector3.Distance(endpoint1.position, endpoint2.position));
            Platform.position = Vector2.Lerp(endpoint1.position, endpoint2.position, distance / Vector2.Distance(endpoint1.position, endpoint2.position));

            //float distance = Mathf.PingPong(Time.time * speed, Vector2.Distance(endpoint1.position, endpoint2.position));
            //Platform.position = Vector2.Lerp(endpoint1.position, endpoint2.position, distance / Vector2.Distance(endpoint1.position, endpoint2.position));

        }
    }


    public void Activate() {

        Active = true;

    }

}
