using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace CoOp
{
    [System.Serializable]
    public class PlayerRemovedEvent : UnityEvent<GameObject>
    {}
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Vector3[] spawnPoints;
        [SerializeField] private GameObject playerPrefab;
        // Triggered when a player is removed.
        [SerializeField] private PlayerRemovedEvent playerRemoved;
        // Triggered when all players are removed.
        [SerializeField] private UnityEvent playersRemoved;
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
                    player.GetDevice());
                newPlayer.transform.position = spawnPoints[p];
                newPlayer.GetComponentInChildren<Renderer>().material.color = PlayerManager.GetPlayerColour(p);
                _players.Add(newPlayer);
            }
        }

        public void RemovePlayer(GameObject player)
        {
            // Find player.
            PlayerInput playerInput = null;
            foreach (var p in _players)
            {
                if (p.gameObject == player)
                    playerInput = p;
            }
            // Skip if player not found.
            if (playerInput == null)
                return;
            // Add score to the player.
            _winners.Insert(0, playerInput.playerIndex);
            _players.Remove(playerInput);
            playerRemoved.Invoke(player);
            // Check if only one player left.
            if (_players.Count == 1)
            {
                _winners.Insert(0, _players[0].playerIndex);
                PlayerManager.UpdateScores(_winners);
                playerRemoved.Invoke(_players[0].gameObject);
                playersRemoved.Invoke();
            }
        }

        public List<GameObject> GetPlayers()
        {
            var playerCount = _players.Count;
            var players = new List<GameObject>();
            for (var p = 0; p < playerCount; p++)
            {
                players[p] = _players[p].gameObject;
            }
            return players;
        }

        public List<PlayerInput> GetPlayerInputs()
        {
            return _players;
        }
    }
}
