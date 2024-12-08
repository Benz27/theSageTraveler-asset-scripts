using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public bool FadeIn = false;
    public float Duration = 0.2f;

    IEnumerator ImgFade()
    {
        CanvasGroup BGIMG = GetComponent<CanvasGroup>();
  
        BGIMG.interactable = true;
        if (FadeIn)
        {
   
            BGIMG.alpha = 0;

            while (BGIMG.alpha < 1)
            {
                BGIMG.alpha += Time.deltaTime / Duration;
                yield return null;
            }
            yield break;

        }
        else
        {
            BGIMG.alpha = 1;
            while (BGIMG.alpha > 0)
            {
                BGIMG.alpha -= Time.deltaTime / Duration;
                yield return null;
            }
            yield break;
        }

        
    }

    public void StartImgFade()
    {
        StartCoroutine(ImgFade());
    }

    private void Awake()
    {
        StartImgFade();
    }
}
