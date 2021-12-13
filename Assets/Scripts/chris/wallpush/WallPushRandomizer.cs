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
    private int indexForSequence = 0;
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
        GameCountDownTimer.gameTimeSequenceEvent += SetWallSequenceBool;

    }  
    private void OnDisable()
    {
        GameCountDownTimer.timerInvtervalEvent -= DifficultySwitch;
        GameCountDownTimer.gameTimeStartEvent -= ChangeGameState;
        GameCountDownTimer.gameTimeEndEvent -= ChangeGameState;
        GameCountDownTimer.gameTimeSequenceEvent -= SetWallSequenceBool;

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

            if (!inWallSequence)
            {

                if (delay <= 0.0f)
                {
                    int numToPush = Random.Range(0, wallRocks.Length);

                    SetDelay();

                    SelectWallToPush(numToPush);

                    //print(delay);
                }
            }

            if (inWallSequence)
            {

                if (delay <= 0.0f)
                {

                    print(indexForSequence);
                    SetDelay();
                    if (indexForSequence < wallRocks.Length && indexForSequence != wallRocks.Length-1)
                    {
                        SelectWallToPush(indexForSequence);
                        indexForSequence+=2;
                    }
                    else if(indexForSequence == wallRocks.Length)
                    {
                        indexForSequence = 1;
                    }else if(indexForSequence == wallRocks.Length - 1){

                        inWallSequence = false;
                    }
                }
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
            PushIn(index);
            //print("anim speed is: " + wallRocks[index].GetComponent<Animator>().speed);
        }
        else if(!wallRocks[index].GetComponent<RockWallObj>().GetOutBool())
        {
            PushOut(index);
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
            delay = 1.8f;
        }
        else if (currentGameDifficulty == 1)
        {
           delay = 1.4f;
        } else if (currentGameDifficulty == 2)
        {
            delay = 1.0f;
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

    private void SetWallSequenceBool()
    {
        if (!inWallSequence)
        {
            print("enabled called");
            inWallSequence = true;

        }
        else if(inWallSequence)
        {
            print("disabled event");
            inWallSequence = false;
        }

    }

    private void PushOut(int index)
    {
        wallRocks[index].GetComponent<Animator>().speed = 1 / delay;
        wallRocks[index].GetComponent<Animator>().SetTrigger("Push");
        wallRocks[index].GetComponent<RockWallObj>().SetOutBool(true);
    }

    private void PushIn(int index)
    {
        wallRocks[index].GetComponent<Animator>().speed = 1 / delay;
        wallRocks[index].GetComponent<Animator>().SetTrigger("Pull");
        wallRocks[index].GetComponent<RockWallObj>().SetOutBool(false);
    }

}
