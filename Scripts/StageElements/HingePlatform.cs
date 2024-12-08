using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingePlatform : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Only respond to collisions with objects that have a Rigidbody2D component
        Rigidbody2D otherRb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (otherRb != null)
        {
            // Calculate the force to apply to the platform based on the velocity and mass of the other object
            float force = otherRb.velocity.magnitude * otherRb.mass;

            // Calculate the position of the collision relative to the center of the platform
            Vector2 contactPos = collision.GetContact(0).point;
            Vector2 centerPos = transform.position;
            Vector2 relativePos = contactPos - centerPos;

            // Apply a force to the platform in the direction of the collision
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(relativePos.normalized * force, ForceMode2D.Impulse);
        }
    }
}
