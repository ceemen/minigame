using CoOp;
using UnityEngine;

namespace FloorDrop
{
    public class KillBox : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner spawner;

        private void OnTriggerEnter(Collider other)
        {
            // Remove player once they touch the lava
            if (other.CompareTag("Player"))
            {
                spawner.RemovePlayer(other.gameObject);
                other.GetComponent<CapsuleCollider>().isTrigger = true;
            }
        }
    }
}
