using System;
using UnityEngine;

namespace LavaTower
{
    public class PlayerDeath : MonoBehaviour
    {
        public GameObject player;
        private void OnTriggerEnter(Collider other)
        {
            Destroy(player);
        }
    }
}
