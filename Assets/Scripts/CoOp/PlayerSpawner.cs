using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CoOp
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Vector3[] spawnPoints;
        [SerializeField] private GameObject playerPrefab;
        private readonly List<PlayerInput> _players = new List<PlayerInput>();
        private readonly List<int> _winners = new List<int>();

        private void Awake()
        {
            var players = PlayerManager.GetPlayers();
            for (var p = 0; p < players.Count; p++)
            {
                var player = players[p];
                var newPlayer = PlayerInput.Instantiate(
                    playerPrefab,
                    -1,
                    player.GetControlScheme(),
                    1,
                    player.GetDevices());
                newPlayer.transform.position = spawnPoints[p];
                newPlayer.GetComponentInChildren<Renderer>().material.color = PlayerManager.GetPlayerColour(p);
                _players.Add(newPlayer);
            }
        }

        public void RemovePlayer(GameObject player)
        {
            // Get the player index
            var playerIndex = -1;
            foreach (var p in _players)
            {
                if (p.gameObject == player)
                    playerIndex = p.playerIndex;
            }
            // Skip if player is already removed.
            if (playerIndex == -1)
                return;
            // Add score to the player
            _winners.Insert(0, playerIndex);
            _players.RemoveAt(playerIndex);
            // Check if only one player left.
            if (_players.Count == 1)
            {
                _winners.Insert(0, _players[0].playerIndex);
                PlayerManager.UpdateScores(_winners);
            }
        }
    }
}
