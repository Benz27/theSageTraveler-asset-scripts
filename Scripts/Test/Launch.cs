using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(LauncDelay());

    }
    private IEnumerator LauncDelay()
    {
        // Wait for one second
        yield return new WaitForSeconds(2.0f);

        // Enable the collider component
        LaunchOBJ();
    }

    void LaunchOBJ()
    {
        Vector2 endTipPosition = transform.position - transform.right * (transform.localScale.x / 2f);
        Rigidbody2D coinRb = gameObject.GetComponent<Rigidbody2D>();
        coinRb.AddForceAtPosition(new Vector2(4000, 0), endTipPosition);
         
    }

}
