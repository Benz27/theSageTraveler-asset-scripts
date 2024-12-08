using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SavedData SavedData;
    public AudioManager AudioManager;
    public GameObject LoadingObject;
    public GameObject ExitPanel;
    public GameObject NewGamePanel;



    public GameObject MainMenuPanel;
    public GameObject StageMenuPanel;

    GameStatus GameStatus;

    //public GameObject PlayButton;
    //public GameObject ContinueButton;
    //public GameObject ExitButton;

    //public SavedData SavedData;
    //InGameData InGameData;
    //GameData GameData;



    private void Awake()
    {
        SavedData.WriteAll();

        GameStatus = SavedData.LoadGameStatus();




        if (GameStatus.ShowTutorial)
        {
           
            SceneManager.LoadScene(2);
            return;
        }





        StageMenuPanel.SetActive(GameStatus.ShowStages);
        MainMenuPanel.SetActive(!GameStatus.ShowStages);










        if (GameStatus.ShowStages)
        {
            GameStatus.ShowStages = false;
            SavedData.SaveGameStatus(GameStatus);
        }

        //Debug.Log("Play " + PlayButton.transform.localPosition);
        //Debug.Log("Continue " + ContinueButton.transform.position);
        //Debug.Log("Exit " + ExitButton.transform.localPosition);
        //SetButtons();

        //GameData = SavedData.LoadGameData();
        //InGameData = SavedData.LoadInGameData();

        AudioManager.gameObject.SetActive(true);
        if (!AudioManager.IsMusicPlaying())
        {
            AudioManager.PlayMusic("Theme");
        }
    }


    void JumpToScene(int index)
    {
        LoadingObject.SetActive(true);
        //if (AudioSource != null)
        //{
        //    AudioSource.Stop();
        //}
        

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }







    public void PlayGame()
    {


        JumpToScene(6);



    }


    public void GameMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        
    }

    public void AnotherGameMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void ShopMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    
    public void ShopBackToMain()
    {
        JumpToScene(0);
    }

    public void OptionMenu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void OptionBackToMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        
    }

    public void GameBackToMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
        
    }

    public void ExitGame()
    {
        SavedData.ResetAll();
        Application.Quit();
    }

    public void ExitGamePanel()
    {
        ExitPanel.SetActive(true);
    }

    public void CloseExitGamePanel()
    {
        ExitPanel.SetActive(false);
    }

    public void OpenNewGamePanel()
    {
        NewGamePanel.SetActive(true);
    }

    public void CloseNewGamePanel()
    {
        NewGamePanel.SetActive(false);
    }
}