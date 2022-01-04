using System.Collections;
using TMPro;
using UnityEngine;
using CoOp;

namespace LavaTower
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private Animator transition;
        [SerializeField] private float timeRemaining = 10;
        [SerializeField] private bool timerIsRunning = false;
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private TextMeshProUGUI timeRunoutText;

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
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(2.0f);
            SceneTransition.LoadScene(0);
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
