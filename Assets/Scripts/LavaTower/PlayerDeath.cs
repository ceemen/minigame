using UnityEngine;

namespace LavaTower
{
    public class PlayerDeath : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
