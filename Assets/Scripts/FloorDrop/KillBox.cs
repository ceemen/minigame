using UnityEngine;

namespace FloorDrop
{
    public class KillBox : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            // Only check for collisions with player.
            if (!other.CompareTag("Player"))
                return;
            print(other.name);
        }
    }
}
