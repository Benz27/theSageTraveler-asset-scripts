using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithScreen : MonoBehaviour
{
    public float referenceScreenWidth = 1080f;
    public float scaleFactor = 1f;

    private void Start()
    {
        // Get the current screen dimensions
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Calculate the scale factor
        float scaleFactorX = screenWidth / referenceScreenWidth;
        float scaleFactorY = screenHeight / referenceScreenWidth;
        float scaleFactor = Mathf.Min(scaleFactorX, scaleFactorY);

        // Apply the scale factor to the object's scale
        transform.localScale *= scaleFactor;
    }
}
