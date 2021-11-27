using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPushRandomizer : MonoBehaviour
{

    public enum GameState
    {
        gameNotStarted,
        gameStarted,
        gameFinished

    };


    private GameCountDownTimer GameCountDownTimerComponent;
    public GameObject[] wallRocks;
    private float gameStartDelay = 5.0f;
    private float delay = 2.0f;
    private int currentGameTime;
    private int currentGameDifficulty = 0;

    //I want to subscribe to the event in GameCOuntDOwn

    // Start is called before the first frame update
    void Awake()
    {
       GameCountDownTimerComponent = GetComponent<GameCountDownTimer>();
       
    }
    private void OnEnable()
    {
        GameCountDownTimer.timerInvterval += DifficultySwitch;

    }  
    private void OnDisable()
    {
        GameCountDownTimer.timerInvterval -= DifficultySwitch;

    }

    // Update is called once per frame
    void Update()
    {
            delay -= Time.deltaTime;

            if (delay <= 0.0f)
            {
                int numToPush = Random.Range(0, wallRocks.Length);

                SelectWallToPush(numToPush);

                SetDelay();
                //print(delay);
            }

        print("curr game diff " + currentGameDifficulty);

    }

    void SelectWallToPush(int index)
    {
        if (wallRocks[index].GetComponent<RockWallObj>().GetOutBool())
        {
            wallRocks[index].GetComponent<Animator>().SetTrigger("Pull");
            wallRocks[index].GetComponent<RockWallObj>().SetOutBool(false);
        }
        else if(!wallRocks[index].GetComponent<RockWallObj>().GetOutBool())
        {
            wallRocks[index].GetComponent<Animator>().SetTrigger("Push");
            wallRocks[index].GetComponent<RockWallObj>().SetOutBool(true);
        }
                   
    }


    private void DifficultySwitch()
    {
        print("GEtting Faster");
        currentGameDifficulty++;
        print(currentGameDifficulty);
    }

    private void SetDelay()
    {

        if (currentGameDifficulty == 0)
        {
            delay = 2.0f;
        }
        else if (currentGameDifficulty == 1)
        {
           delay = 1.6f;
        } else if (currentGameDifficulty == 2)
        {
            delay = 1.2f;
        } else if (currentGameDifficulty == 3)
        {
            delay = 0.8f;
        } else if (currentGameDifficulty == 4)
        {
            delay = 0.6f;
        } else if (currentGameDifficulty == 5)
        {
            delay = 0.4f;
        }

    }

    
}
