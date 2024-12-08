using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer VideoPlayer;
    public GameObject LoadingObject;
    public GameObject MainCamera;
    public GameObject SkipButton;

    bool started = false;
    public int timer = 2;


    void Start()
    {
        VideoPlayer.prepareCompleted += VideoStarted;
    }

    IEnumerator Countdown()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer--;
        }

        // Perform an action after the timer has counted down to 0, such as triggering a new scene or playing a sound effect.
        started = true;
        SkipButton.SetActive(true);
    }


    void VideoStarted(VideoPlayer source)
    {
        // Perform an action when the video starts, such as playing a sound effect.
        PrefabOBJLoaded();
        StartCoroutine(Countdown());
    }



    void Update()
    {
        if (!VideoPlayer.isPlaying && !VideoPlayer.isLooping && started)
        {
            GoToGame();
        }
    }



    public void GoToGame()
    {
     
        VideoPlayer.Stop();
        BackToLoading();
        SceneManager.LoadScene(3);
    } 

    void BackToLoading()
    {
        LoadingObject.SetActive(true);
        MainCamera.SetActive(false);
    }

    void PrefabOBJLoaded()
    {
        MainCamera.SetActive(true);
        LoadingObject.SetActive(false);
    }
}
