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
            var objects = spawner.GetPlayers();
            foreach (var player in objects)
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
                }
            }

            transform.position = position;
        }
    }
}
