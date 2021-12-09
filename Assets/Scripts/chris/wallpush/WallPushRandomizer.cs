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


    public GameObject[] wallRocks;
    private float delay = 2.0f;
    private int currentGameDifficulty = 0;
    private bool inWallSequence = false;
    private GameState gamestate;


    // Start is called before the first frame update
    void Awake()
    {
       
    }
    private void OnEnable()
    {
        GameCountDownTimer.timerInvtervalEvent += DifficultySwitch;
        GameCountDownTimer.gameTimeStartEvent += ChangeGameState;
        GameCountDownTimer.gameTimeEndEvent += ChangeGameState;
        GameCountDownTimer.gameTimeSequenceEvent += ResetWalls;

    }  
    private void OnDisable()
    {
        GameCountDownTimer.timerInvtervalEvent -= DifficultySwitch;
        GameCountDownTimer.gameTimeStartEvent -= ChangeGameState;
        GameCountDownTimer.gameTimeEndEvent -= ChangeGameState;
        GameCountDownTimer.gameTimeSequenceEvent -= ResetWalls;

    }

    private void Start()
    {
        gamestate = GameState.gameNotStarted;
    }

    // Update is called once per frame
    private void Update()
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
                       
            //print("curr game diff " + currentGameDifficulty);

        }
        if (gamestate == GameState.gameFinished)
        {
            print("Game has Finished");
        }

        //print(gamestate.ToString());

    }

    private void SelectWallToPush(int index)
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
    private void ChangeGameState()
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

    private void ResetWalls()
    {
        print("event called");
        inWallSequence = true;
        for (int i = 6; i < wallRocks.Length; i++)
        {
            SelectWallToPush(i);
        }
    }

    private void StartWallSequence()
    {
        for (int i = 0; i < wallRocks.Length; i++)
        {
            SelectWallToPush(i);
        }
    }

}
