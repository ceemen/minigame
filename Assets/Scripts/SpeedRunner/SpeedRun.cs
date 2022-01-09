using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SRunner
{
    public class SpeedRun : MonoBehaviour
    {

        [SerializeField] private float startSpeed = 3.0f;
        [SerializeField] private float speedInc = 0.1f;

        [SerializeField] private GameObject mainCamera;

        private GameObject[] players;

        void Start()
        {
            players = GameObject.FindGameObjectsWithTag("Player");
        }


        void Update()
        {
            startSpeed += speedInc * Time.deltaTime;
            foreach (GameObject player in players)
            {
                player.GetComponent<SRunController>().runSpeed += speedInc * Time.deltaTime;
            }
            Vector3 camPos = mainCamera.transform.position;
            camPos.x += startSpeed * Time.deltaTime;
            mainCamera.transform.position = camPos;
        }

        public void killPlayer(GameObject player)
        {
            foreach (GameObject p in players)
            {
                if(p==player)
                {
                    p.SetActive(false);
                }
            }
        }
    }
}
