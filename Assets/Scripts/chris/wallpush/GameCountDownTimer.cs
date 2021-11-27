using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCountDownTimer : MonoBehaviour
{

    public Text timerText;
    private float gameTime = 120.0f;
    private float eventInterval = 0.0f;

    public delegate void TimerDelegate();
    public static event TimerDelegate timerInvterval;
    public static event TimerDelegate timeEndEvent;

    // I want an event here

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = gameTime.ToString();   
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameTime > 0)
        {
            eventInterval += Time.deltaTime;
            gameTime -= Time.deltaTime;
            TimeDisplayConversion(gameTime);
            if (eventInterval >=20.0f)
            {
                eventInterval = 0.0f;
                if (timerInvterval != null)
                {
                    timerInvterval();
                }
            }
        }
        if (gameTime <= 0)
        {
            gameTime = 0;
            TimeDisplayConversion(gameTime);
            if (timeEndEvent != null)
            {
                timeEndEvent();
            }
        }

    }


    void TimeDisplayConversion(float timeToConvert)
    {
        float minutes = Mathf.FloorToInt(timeToConvert / 60);
        float seconds = Mathf.FloorToInt(timeToConvert %60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

}
