using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CoOp
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Vector3[] spawnPoints;
        [SerializeField] private GameObject playerPrefab;
        private readonly List<GameObject> _players = new List<GameObject>();

        private void Start()
        {
            var players = PlayerManager.GetInstance().GetPlayers();
            SpawnPlayers(players);
        }

        protected virtual void SpawnPlayers(PlayerData[] players)
        {
            for (var p = 0; p < players.Length; p++)
            {
                var newPlayer = CreatePlayer(players[p], p);
                newPlayer.transform.position = spawnPoints[p];
            }
        }

        protected PlayerInput CreatePlayer(PlayerData data, int index)
        {
            var newPlayer = PlayerInput.Instantiate(
                playerPrefab,
                -1,
                data.GetControlScheme(),
                1,
                data.GetDevice());
            newPlayer.GetComponentInChildren<Renderer>().material.color = PlayerManager.GetPlayerColour(index);
            _players.Add(newPlayer.gameObject);
            return newPlayer;
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
