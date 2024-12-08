using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float interval;
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] Image Fill;
    float time;
    bool timerOnGoing = false;

    public UnityEvent TimerFinished;

    void Awake()
    {
        if (TimerFinished == null)
            TimerFinished = new UnityEvent();
    }

    public void StartTimer()
    {
        StopTimer();
        ResetTimer();

        StartCoroutine(DelayTimer());
        
    }

    public void StopTimer()
    {
        timerOnGoing = false;
    }

    public float[] GetTimerValue()
    {
        return new float[] { time, interval };
    }

    public void ResetTimer()
    {
        time = interval;
        //Fill.fillAmount = 1f;
        //TimerText.text = "" + (int)time;
    }

    private IEnumerator DelayTimer()
    {
        // Wait for one second
        yield return new WaitForSeconds(0.5f);

        // Enable the collider component
        timerOnGoing = true;
    }

    void Update()
    {
        if (timerOnGoing)
        {
            time -= Time.deltaTime;
            //TimerText.text = "" + (int)time;
            //Fill.fillAmount = time / interval;

            if(time <= 0)
            {
                time = 0;
                timerOnGoing = false;
                TimerFinished.Invoke();
            }
        }
    }

    public float[] GetTImeInterval()
    {



        return new float[2]{ time, interval };
    }

    public float GetTime()
    {
        return time;
    }

    public float GetInterval()
    {
        return interval;
    }
}
