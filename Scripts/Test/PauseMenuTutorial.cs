using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PauseMenuTutorial : MonoBehaviour
{
    [SerializeField] public GameObject PauseMenuPanel;

    public AudioSource AudioSource;
    public GameObject LoadingObject;
    public GameObject MainCamera;
    public GameObject SkipTutorialPanel;
    public GameObject ReturnToMainMenuPanel;

    public TutorialControl TutorialControl;

    void JumpToScene(int index)
    {
        MainCamera.SetActive(false);
        LoadingObject.SetActive(true);
        if (AudioSource != null)
        {
            AudioSource.Stop();
        }


        SceneManager.LoadScene(index);
    }

    public void Pause()
    {
        PauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;

    }

    public void Resume()

    {
        PauseMenuPanel.SetActive(false);
        SkipTutorialPanel.SetActive(false);
        ReturnToMainMenuPanel.SetActive(false);
        Time.timeScale = 1f;

    }
    public void Restart()

    {


        Time.timeScale = 1f;
        JumpToScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()

    {
        Time.timeScale = 1f;
        JumpToScene(0);
    }

    public void OpenSkipTutorialPanel()
    {
        SkipTutorialPanel.SetActive(true);
    }

    public void CloseSkipTutorialPanel()
    {
        SkipTutorialPanel.SetActive(false);
    }

    public void OpenReturnToMainMenuPanel()
    {
        ReturnToMainMenuPanel.SetActive(true);
    }

    public void CloseReturnToMainMenuPanel()
    {
        ReturnToMainMenuPanel.SetActive(false);
    }



    public void SkipTutorial()
    {

        TutorialControl.GoToMain();
    }
}
