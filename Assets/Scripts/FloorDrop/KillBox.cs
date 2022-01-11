using System;
using CoOp;
using UnityEngine;

namespace FloorDrop
{
    public class KillBox : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner spawner;

        private void OnTriggerEnter(Collider other)
        {
            // Only check for collisions with player
            if (!other.CompareTag("Player"))
                return;
            spawner.RemovePlayer(other.gameObject);
        }
    }
}
