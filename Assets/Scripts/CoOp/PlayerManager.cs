using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
            // If player manager doesn't already exist, make this the singleton.
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
                return;
            }
            // Otherwise delete this clone.
            Destroy(gameObject);
        }

        // Returns true if player has been added, false if player was already added.
        public static bool AddPlayer(PlayerInput newPlayer)
        {
            var newPlayerData = new PlayerData(newPlayer.currentControlScheme, newPlayer.devices.ToArray());
            // Check if the player has already been added
            foreach (var playerData in _instance._players)
            {
                if (playerData.Equals(newPlayerData))
                    return false;
            }
            print($"Player {newPlayer.playerIndex} joined: {newPlayer.currentControlScheme}");
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
