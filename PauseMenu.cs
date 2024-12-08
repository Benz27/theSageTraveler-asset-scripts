using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject PauseMenuPanel;

    public AudioSource AudioSource;
    public GameObject LoadingObject;
    public GameObject MainCamera;
    public GameObject ReturnToMainMenuPanel;

    public GameObject SavePanel;
    public GameObject SavePanelButton;
    public Image SaveMessageImage;
    public Sprite[] SavingMessages;



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



    public void OpenReturnToMainMenuPanel()
    {
        ReturnToMainMenuPanel.SetActive(true);
    }

    public void CloseReturnToMainMenuPanel()
    {
        ReturnToMainMenuPanel.SetActive(false);
    }


    private void Awake()
    {
        if (Time.timeScale < 1f)
        {
            Time.timeScale = 1f;
        }
    }

    public void SaveProg()
    {
        SaveMessageImage.sprite = SavingMessages[0];
        SavePanelButton.SetActive(false);
        SavePanel.SetActive(true);
        
        SaveMessageImage.sprite = SavingMessages[1];
        SavePanelButton.SetActive(true);
    }



}
