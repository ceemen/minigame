using UnityEngine;

namespace LavaTower
{
    public class DestroyPlatform : MonoBehaviour
    {
        public GameObject player;

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.transform.position = new Vector2(Random.Range(-5.5f, 5.5f),
                player.transform.position.y + (12 + Random.Range(0.2f, 1.0f)));
        }
    }
}
