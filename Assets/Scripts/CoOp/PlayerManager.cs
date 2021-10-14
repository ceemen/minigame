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

        public static PlayerManager GetInstance()
        {
            return _instance;
        }

        public static Color GetPlayerColour(int playerIndex)
        {
            return PlayerColours[playerIndex % PlayerColours.Length];
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
        public bool AddPlayer(PlayerInput newPlayer)
        {
            print($"Player joined: {newPlayer.devices.ToArray()[0]} {newPlayer.devices.Count}");
            var newPlayerData = new PlayerData(newPlayer.currentControlScheme, newPlayer.devices[0]);
            // Ignore players that have already been added.
            foreach (var playerData in _players)
            {
                if (playerData == newPlayerData)
                    return false;
            }
            _players.Add(newPlayerData);
            return true;
        }
    }
}
