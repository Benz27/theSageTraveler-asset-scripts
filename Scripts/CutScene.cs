using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    // Start is called before the first frame update

    public VideoClip[] CutScenes;

    public VideoPlayer VideoPlayer;

    public SavedData SavedData;
    public GameObject LoadingObject;
    public GameObject MainCamera;
    public GameObject SkipButton;

    InGameData InGameData;



    bool started = false;
    public int timer = 2;


    void Start()
    {
        InGameData = SavedData.LoadInGameData();

        //if (!PlayerPrefs.HasKey("CurrentStage"))
        //{
        //    SceneManager.LoadScene(0);
        //}
        VideoPlayer.clip = CutScenes[InGameData.ActiveLevel.CurrentLevel];

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
        EndLoadingScreen();
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
        StartLoadingScreen();
        VideoPlayer.Stop();
        SceneManager.LoadScene(1);
    } 

    void StartLoadingScreen()
    {
        MainCamera.SetActive(false);
        LoadingObject.SetActive(true);
       
    }

    void EndLoadingScreen()
    {
        MainCamera.SetActive(true);
        LoadingObject.SetActive(false);
    }
}
