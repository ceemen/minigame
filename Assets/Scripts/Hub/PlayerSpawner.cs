using CoOp;
using Menu;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Hub
{
    public class PlayerSpawner : MonoBehaviour
    {
        private const float PillarGap = 5,
            ScoreHeight = 0.25f; // How much pillar height is added by each point.
        [SerializeField] private GameObject playerPrefab,
            pillar;
        private readonly Vector3 _pillarPosition = new Vector3(0, -2.25f, 0),
            _playerPosition = new Vector3(0, 2.5f, 0);

        private void Start()
        {
            // spawn players
            var players = PlayerManager.GetPlayers();
            var playerCount = players.Count;
            var playerOffset = (playerCount - 1) / 2f;
            var winners = PlayerManager.GetWinners();
            for (var p = 0; p < playerCount; p++)
            {
                // spawn the pillar
                var pillarOffset = new Vector3(
                    PillarGap * (p - playerOffset),
                    players[p].GetScore() * ScoreHeight,
                    0);
                var newPillar = Instantiate(pillar, _pillarPosition + pillarOffset, Quaternion.identity);
                // spawn the player
                var newPlayer = Instantiate(playerPrefab, newPillar.transform, false);
                newPlayer.transform.localPosition = _playerPosition;
                newPlayer.GetComponentInChildren<Renderer>().material.color = PlayerManager.GetPlayerColour(p);
                // set player animation
                // skip if game just started
                if (winners.Count == 0)
                    continue;
                var winner = winners[0] == p;
                newPlayer.GetComponentInChildren<PlayerAnimation>().SetWinner(winner);
            }
        }
    }
}
