using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CoOp
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Vector3[] spawnPoints;
        [SerializeField] private GameObject playerPrefab;
        private readonly List<GameObject> _players = new List<GameObject>();

        private void Awake()
        {
            var players = PlayerManager.GetInstance().GetPlayers();
            for (var p = 0; p < players.Count; p++)
            {
                var player = players[p];
                var newPlayer = PlayerInput.Instantiate(
                    playerPrefab,
                    -1,
                    player.GetControlScheme(),
                    1,
                    player.GetDevice());
                newPlayer.transform.position = spawnPoints[p];
                newPlayer.GetComponentInChildren<Renderer>().material.color = PlayerManager.GetPlayerColour(p);
                _players.Add(newPlayer.gameObject);
            }
        }

        public void RemovePlayer(GameObject player)
        {
            // Skip if player is already removed.
            if (!_players.Contains(player))
                return;
            _players.Remove(player);
            // Check if only one player left.
            if (_players.Count == 1)
            {
                print("Player x won");
            }
        }
    }
}
