using CoOp;
using UnityEngine;

namespace GameOver
{
    public class PlayerSpawner : CoOp.PlayerSpawner
    {
        [SerializeField] private GameObject pillarPrefab;
        [SerializeField] private Vector3 pillarOffset;
        [SerializeField] private int danceCount;
        private static readonly int Dance = Animator.StringToHash("Dance");

        protected override void SpawnPlayers(PlayerData[] players)
        {
            var spawnPoint = (players.Length - 1) * Vector3.left;
            var winner = PlayerManager.GetInstance().GetWinner();
            for (var p = 0; p < players.Length; p++)
            {
                var newPlayer = CreatePlayer(players[p], p);
                newPlayer.transform.position = spawnPoint;
                // Set the animation
                var dance = 0;
                if (winner == p)
                    dance = Random.Range(1, danceCount + 1);
                newPlayer.GetComponentInChildren<Animator>().SetInteger(Dance, dance);
                // Create the pillar
                var pillarPosition = spawnPoint + pillarOffset;
                Instantiate(pillarPrefab, pillarPosition, Quaternion.identity);
                spawnPoint.x += 2;
            }
        }
    }
}