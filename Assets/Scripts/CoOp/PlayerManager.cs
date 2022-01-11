using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace CoOp
{
    public class PlayerManager : MonoBehaviour
    {
        private static PlayerManager _instance;
        private static readonly Color[] PlayerColours = {
            Color.red,
            Color.green,
            Color.blue,
            Color.yellow,
        };

        private readonly List<PlayerData> _players = new List<PlayerData>();

        public static Color GetPlayerColour(int playerIndex)
        {
            return PlayerColours[playerIndex % PlayerColours.Length];
        }

        public static List<PlayerData> GetPlayers()
        {
            return _instance._players;
        }

        private void Awake()
        {
            // Destroy this clone if instance already exists.
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }
            // Make this the instance otherwise.
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // Call at the end of the games.
        public static void RemovePlayers()
        {
            _instance._players.Clear();
        }

        // Returns true if player has been added, false if player was already added.
        public static bool AddPlayer(PlayerInput newPlayer)
        {
            var newPlayerData = new PlayerData(newPlayer.currentControlScheme, newPlayer.devices[0]);
            // Check if the player has already been added.
            foreach (var playerData in _instance._players)
            {
                if (playerData.Equals(newPlayerData))
                    return false;
            }
            print($"Player {newPlayer.playerIndex} joined with {newPlayer.devices.Count} devices");
            _instance._players.Add(newPlayerData);
            return true;
        }

        public static void UpdateScores(IEnumerable<int> players)
        {
            var score = 1;
            foreach (var player in players)
            {
                _instance._players[player].AddScore(score);
                score++;
            }
        }
    }
}
