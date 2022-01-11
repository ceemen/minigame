using System.Linq;
using TMPro;
using UnityEngine;
using CoOp;

namespace LavaTower
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float timeRemaining = 10;
        [SerializeField] private bool timerIsRunning = false;
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private PlayerSpawner spawner;

        private void Start()
        {
            timerIsRunning = true;
        }

        private void Update()
        {
            if (timerIsRunning)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    DisplayTime(timeRemaining);
                }
                else
                {
                    timeText.enabled = false;
                    GetYPosition();
                    timeRemaining = 0;
                    timerIsRunning = false;
                }
            }
        }
        
        private void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        public void TimerStop()
        {
            timerIsRunning = false;
        }
        
        private void GetYPosition()
        {
            var players = spawner.GetPlayers().OrderBy(p => p.transform.position.y).ToList();
            foreach (var player in players)
            {
                spawner.RemovePlayer(player.gameObject);
            }
        }
    }
}
