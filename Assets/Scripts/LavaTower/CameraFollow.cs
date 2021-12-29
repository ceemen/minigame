using System.Collections.Generic;
using UnityEngine;
using CoOp;

namespace LavaTower
{
    public class CameraFollow : MonoBehaviour
    {
        private readonly List<Transform> players = new List<Transform>();

        public PlayerSpawner spawner;
        
        private void Start()
        {
            var controllers = FindObjectsOfType<PlayerControllerLavaTower>();
            foreach (var player in controllers)
            {
                players.Add(player.transform);
            }
        }

        private void LateUpdate()
        {
            players.RemoveAll(player => player == null);
            var position = transform.position;
            foreach (var player in players)
            {
                var playerHeight = player.position.y;
                if (playerHeight > position.y)
                {
                    position.y = playerHeight;
                    spawner.RemovePlayer(player.gameObject);
                }
            }

            transform.position = position;
        }
    }
}
