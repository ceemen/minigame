using System.Collections;
using System.Collections.Generic;
using TMPro;
using CoOp;
using UnityEngine;


namespace SRunner
{
    public class SpeedRun : MonoBehaviour
    {
        [SerializeField] private List<AudioSource> noises;

        [SerializeField] private PlayerSpawner spawner;

        [SerializeField] private TextMeshProUGUI leaderBoardText;

        [SerializeField] private float startSpeed = 3.0f;
        [SerializeField] private float speedInc = 0.1f;

        [SerializeField] private GameObject mainCamera;
        [SerializeField] private GameObject timer;


        private List<GameObject> players;

        private bool isRunning = true;

        private string leaderBoard = "";

        private float gameEndTimeOut = 0;

        private SpeedRTimer time;

        void Start()
        {
            players = new List<GameObject>();
            players = spawner.GetPlayers(); //.AddRange(GameObject.FindGameObjectsWithTag("Player"));
            time = (SpeedRTimer)timer.GetComponent(typeof(SpeedRTimer));
        }


        void Update()
        {
            if (!isRunning)
            {
                gameEndTimeOut += Time.deltaTime;
                if (gameEndTimeOut > 6)
                    SceneTransition.LoadHub();
                return;
            }
            startSpeed += speedInc * Time.deltaTime;
            if(players.Count>0)
            {
                foreach (GameObject player in players)
                {
                    if(player!=null)
                        player.GetComponent<SRunController>().runSpeed = startSpeed+1;
                }
            }
            Vector3 camPos = mainCamera.transform.position;
            camPos.x += startSpeed * Time.deltaTime;
            mainCamera.transform.position = camPos;
        }

        void GameEnd()
        {
            time.EndTimer();
            leaderBoardText.text = leaderBoard;
            isRunning = false;
        }

        public void killPlayer(GameObject player)
        {
            if (players.Count == 0)
            {
                GameEnd();
                return;
            }
            foreach (GameObject p in players)
            {
                if (p == null)
                    continue;
                else if(p==player)
                {
                    noises[Random.Range(0, noises.Count)].Play(0);
                    switch ((int)p.transform.position.z/3)
                    {
                        case 0:
                            leaderBoard += "Player 1 " + time.GetTime() + "\u000a";
                            break;
                        case 1:
                            leaderBoard += "Player 2 " + time.GetTime() + "\u000a";
                            break;
                        case 2:
                            leaderBoard += "Player 3 " + time.GetTime() + "\u000a";
                            break;
                        case 3:
                            leaderBoard += "Player 4 " + time.GetTime() + "\u000a";
                            break;
                        default:
                            break;
                    }
                    players.Remove(p);
                    spawner.RemovePlayer(p);
                    Destroy(p);
                    Debug.Log(players.Count + "fuck");
                    if (players.Count == 0)
                        GameEnd();
                    return;
                }
            }
        }
    }
}
