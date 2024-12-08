using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MPTimerGUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] Image Fill;
    [SerializeField] Timer Timer;
    //bool Active = false;



    //void OnEnable()
    //{
        
    //}

    private void Update()
    {

        float[] TimeInterval = Timer.GetTImeInterval();

        TimerText.text = "" + (int)TimeInterval[0];
        Fill.fillAmount = TimeInterval[0] / TimeInterval[1];
    }






}
