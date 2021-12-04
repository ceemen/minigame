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
    private GameState gamestate;


    // Start is called before the first frame update
    void Awake()
    {
       GameCountDownTimerComponent = GetComponent<GameCountDownTimer>();
       
    }
    private void OnEnable()
    {
        GameCountDownTimer.timerInvtervalEvent += DifficultySwitch;
        GameCountDownTimer.gameTimeStartEvent += ChangeGameState;
        GameCountDownTimer.gameTimeEndEvent += ChangeGameState;

    }  
    private void OnDisable()
    {
        GameCountDownTimer.timerInvtervalEvent -= DifficultySwitch;
        GameCountDownTimer.gameTimeStartEvent -= ChangeGameState;
        GameCountDownTimer.gameTimeEndEvent -= ChangeGameState;

    }

    private void Start()
    {
        gamestate = GameState.gameNotStarted;
    }

    // Update is called once per frame
    void Update()
    {

        if (gamestate == GameState.gameStarted)
        {

            delay -= Time.deltaTime;

            if (delay <= 0.0f)
            {
                int numToPush = Random.Range(0, wallRocks.Length);

                SetDelay();

                SelectWallToPush(numToPush);

                //print(delay);
            }

            print("curr game diff " + currentGameDifficulty);

        }
        if (gamestate == GameState.gameFinished)
        {
            print("Game has Finished");
        }

        print(gamestate.ToString());

    }

    void SelectWallToPush(int index)
    {

        if (wallRocks[index].GetComponent<RockWallObj>().GetOutBool())
        {
            wallRocks[index].GetComponent<Animator>().speed = 1 / delay;
            wallRocks[index].GetComponent<Animator>().SetTrigger("Pull");
            wallRocks[index].GetComponent<RockWallObj>().SetOutBool(false);
            //print("anim speed is: " + wallRocks[index].GetComponent<Animator>().speed);
        }
        else if(!wallRocks[index].GetComponent<RockWallObj>().GetOutBool())
        {
            wallRocks[index].GetComponent<Animator>().speed = 1 / delay;
            wallRocks[index].GetComponent<Animator>().SetTrigger("Push");
            wallRocks[index].GetComponent<RockWallObj>().SetOutBool(true);
            //print("anim speed is: " + wallRocks[index].GetComponent<Animator>().speed);
        }
                   
    }


    private void DifficultySwitch()
    {
        print("Getting Faster");
        currentGameDifficulty++;
        //print(currentGameDifficulty);
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

    public GameState GetGameState()
    {
        return gamestate;
    }
    public void ChangeGameState()
    {
        switch (gamestate)
        {
            case GameState.gameNotStarted:
                gamestate = GameState.gameStarted;
                break;
            case GameState.gameStarted:
                gamestate = GameState.gameFinished;
                break;
            case GameState.gameFinished:
                gamestate = GameState.gameFinished;
                break;
            default:
                break;
        }
    }


}
