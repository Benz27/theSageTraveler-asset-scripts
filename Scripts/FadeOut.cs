using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{







    IEnumerator ImgFadeIn()
    {
        CanvasGroup BGIMG = GetComponent<CanvasGroup>();
        BGIMG.alpha = 0;
        BGIMG.interactable = true;
        while (BGIMG.alpha < 1)
        {
            BGIMG.alpha += Time.deltaTime / 1f;
            yield return null;
        }
        yield break;
    }

    public void StartImgFadeIn()
    {
        StartCoroutine(ImgFadeIn());
    }

    private void Awake()
    {
        StartImgFadeIn();
    }
}
