using System.Collections.Generic;
using UnityEngine;
using CoOp;

namespace LavaTower
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner spawner;
        private List<GameObject> players;

        private void Start()
        {
            players = spawner.GetPlayers();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            players.Remove(other.gameObject);
            spawner.RemovePlayer(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
