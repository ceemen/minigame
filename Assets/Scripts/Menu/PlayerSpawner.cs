using CoOp;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Menu
{
    [RequireComponent(typeof(PlayerInputManager))]
    public class PlayerSpawner : MonoBehaviour
    {
        private readonly Vector3[] _spawnPoints = {
            new Vector3(-2, 0, 2),
            new Vector3(2, 0, 2),
            new Vector3(-2, 0, -2),
            new Vector3(2, 0, -2)
        };

        [SerializeField] private Lobby lobby;
        
        public void OnPlayerJoined(PlayerInput player)
        {
            // Skip if player has already been added.
            if (!PlayerManager.GetInstance().AddPlayer(player))
                return;
            // Set the position and colour of a new player.
            var playerIndex = player.playerIndex % 4;
            player.gameObject.transform.position = _spawnPoints[playerIndex];
            player.GetComponentInChildren<Renderer>().material.color = PlayerManager.GetPlayerColour(playerIndex);
            lobby.AddPlayer(player);
        }

        public void OnPlayerLeft(PlayerInput player)
        {
            print($"Player {player.playerIndex} left.");
            lobby.RemovePlayer(player);
        }
    }
}