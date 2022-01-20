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
    private GameObject currentMovingWall;
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

                    SelectWallToPush(wallRocks[numToPush]);
                    currentMovingWall = wallRocks[numToPush];

                    //print($"wall being moving wall is {numToPush}");
                    //print(delay);
                }
            }

            if (inWallSequence)
            {

                if (delay <= 0.0f)
                {

                    //print(indexForSequence);
                    SetDelay();
                    if (indexForSequence < wallRocks.Length && indexForSequence != wallRocks.Length-1)
                    {
                        SelectWallToPush(wallRocks[indexForSequence]);
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

    public void SelectWallToPush(GameObject wallObj)
    {

        if (wallObj.GetComponent<RockWallObj>().GetOutBool())
        {
            PushIn(wallObj);
            //print("anim speed is: " + wallRocks[index].GetComponent<Animator>().speed);
        }
        else if(!wallObj.GetComponent<RockWallObj>().GetOutBool())
        {
            PushOut(wallObj);
            //print("anim speed is: " + wallRocks[index].GetComponent<Animator>().speed);
        }
                   
    }


    private void DifficultySwitch()
    {
        print("Getting Faster");
        if (currentGameDifficulty < 5)
        {
            currentGameDifficulty++;
        }
            //print(currentGameDifficulty);
    }

    private void SetDelay()
    {

        if (currentGameDifficulty == 0)
        {
            delay = 1.0f;
        }
        else if (currentGameDifficulty == 1)
        {
           delay = 0.8f;
        } else if (currentGameDifficulty == 2)
        {
            delay = 0.7f;
        } else if (currentGameDifficulty == 3)
        {
            delay = 0.6f;
        } else if (currentGameDifficulty == 4)
        {
            delay = 0.4f;
        } else if (currentGameDifficulty == 5)
        {
            delay = 0.3f;
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
            print("enabled event");
            inWallSequence = true;

        }
        else if(inWallSequence)
        {
            print("disabled event");
            inWallSequence = false;
        }
        
    }

    private void PushOut(GameObject wallObj)
    {
        wallObj.GetComponent<Animator>().speed = 1 / delay;
        wallObj.GetComponent<Animator>().SetTrigger("Push");
        wallObj.GetComponent<RockWallObj>().SetOutBool(true);
    }

    private void PushIn(GameObject wallObj)
    {
        wallObj.GetComponent<Animator>().speed = 1 / delay;
        wallObj.GetComponent<Animator>().SetTrigger("Retract");
        wallObj.GetComponent<RockWallObj>().SetOutBool(false);
    }

    public GameObject GetCurrentMovingWall()
    {
        return currentMovingWall;
    }

}
