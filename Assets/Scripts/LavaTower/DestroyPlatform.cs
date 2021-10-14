using UnityEngine;

namespace LavaTower
{
    public class DestroyPlatform : MonoBehaviour
    {
        public GameObject player;

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.transform.position = new Vector2(
                Random.Range(-5, 5),
                Mathf.Round(player.transform.position.y) + (12 + Random.Range(0, 5) * 2.0f)
                );
        }
    }
}
