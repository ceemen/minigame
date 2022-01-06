using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LavaTower
{
    public class Timer : MonoBehaviour
    {
        public float timeRemaining = 10;
        public bool timerIsRunning = false;
        public TextMeshProUGUI timeText;
        public TextMeshProUGUI timeRunoutText;

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
                    timeRunoutText.enabled = true;
                    StartCoroutine(LevelLoad());
                    timeRemaining = 0;
                    timerIsRunning = false;
                }
            }
        }

        IEnumerator LevelLoad()
        {
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene("Scenes/Menu");
        }
        
        private void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
