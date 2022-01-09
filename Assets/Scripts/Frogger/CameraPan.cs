using System.Collections.Generic;
using UnityEngine;

namespace Frogger
{
    public class CameraPan : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;
        private float progress = float.NegativeInfinity;
        private readonly List<Transform> players = new List<Transform>();

        private void Start()
        {
            var controllers = FindObjectsOfType<PlayerControllerFrogger>();
            foreach (var player in controllers)
            {
                players.Add(player.transform);
            }
        }

        private void LateUpdate()
        {
            // remove deleted characters
            players.RemoveAll(player => player == null);
            foreach (var player in players)
            {
                var playerProgress = player.position.z;
                if (playerProgress > progress)
                    progress = playerProgress;
            }
            transform.position = Vector3.forward * progress + offset;
        }
    }
}
