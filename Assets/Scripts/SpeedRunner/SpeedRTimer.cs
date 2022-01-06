using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;


namespace SRunner
{
    public class SpeedRTimer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        private int totalTimeMillis = 0;
        private int minutes = 0;
        private int seconds = 0;
        private int centiseconds = 0;
        void Start()
        {

        }


        void Update()
        {
            totalTimeMillis += (int)(Time.deltaTime * 1000);
            minutes = totalTimeMillis / 60000;
            seconds = (totalTimeMillis % 60000) / 1000;
            centiseconds = (totalTimeMillis % 1000) / 10;
            text.text = "Time Survived: " + string.Format("{0:D2}:{1:D2}:{2:D2}", minutes, seconds, centiseconds);
        }
    }
}
