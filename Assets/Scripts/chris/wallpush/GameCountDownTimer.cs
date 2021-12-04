using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCountDownTimer : MonoBehaviour
{

    public Text timerText;
    private float gameTime;
    private float initialgameCountdownTime;
    private float eventInterval = 0.0f;

    public delegate void TimerDelegate();
    public static event TimerDelegate timerInvtervalEvent;
    public static event TimerDelegate gameTimeEndEvent;
    public static event TimerDelegate gameTimeStartEvent;

    private WallPushRandomizer randomizerManager;

    private void Awake()
    {
        randomizerManager = GetComponent<WallPushRandomizer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = initialgameCountdownTime.ToString();
        gameTime = 120.0f;
        initialgameCountdownTime = 5.0f;       
    }

    // Update is called once per frame
    void Update()
    {
        if (randomizerManager.GetGameState() == WallPushRandomizer.GameState.gameNotStarted)
        {
            initialgameCountdownTime -= Time.deltaTime;
            TimeDisplayConversion(initialgameCountdownTime);
            if (initialgameCountdownTime <= 0.0f)
            {
                gameTimeStartEvent();
            }       
        }

        if (randomizerManager.GetGameState() == WallPushRandomizer.GameState.gameStarted)
        {
            timerText.text = gameTime.ToString();
            if (gameTime > 0)
            {
                eventInterval += Time.deltaTime;
                gameTime -= Time.deltaTime;
                TimeDisplayConversion(gameTime);
                if (eventInterval >=20.0f)
                {
                    eventInterval = 0.0f;
                    if (timerInvtervalEvent != null)
                    {
                        timerInvtervalEvent();
                    }
                }
            }
            if (gameTime <= 0)
            {
                gameTime = 0;
                TimeDisplayConversion(gameTime);
                if (gameTimeEndEvent != null)
                {
                    gameTimeEndEvent();
                }
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
