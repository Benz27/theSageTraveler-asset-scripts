using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI CoinsEarnedText;
    [SerializeField] TextMeshProUGUI TreasuresEarnedText;
    [SerializeField] Slider HealthSlider;
    [SerializeField] GameOver COMPGameOver;
    void Awake()
    {
   
        HealthSlider.maxValue = 1;
        HealthSlider.value = 1;
    }

    public void SetHealthSliderVal(float val)
    {
        HealthSlider.value = val;
    }

    public float GetHealthSliderVal()
    {
       return HealthSlider.value;
    }



    public void setCoinText(int val)
    {
        CoinsEarnedText.text = "" + val;


    }

    public void setTreasureText(int val)
    {
        TreasuresEarnedText.text = "" + val;
    }

    public void GameOver()
    {

        COMPGameOver.PlayerDied();
    }
}
