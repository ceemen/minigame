using UnityEngine;

namespace LavaTower
{
    public class PlayerBounce : MonoBehaviour
    {
        [SerializeField] private float jumpHeight;
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            // Skip if not colliding with a platform.
            if (!other.gameObject.CompareTag("Platform") && !other.gameObject.CompareTag("SuperJumpPlatform"))
                return;
            // Return if ascending.
            if (_rb.velocity.y >= 0)
                return;

            var velocity = _rb.velocity;
            velocity.y = Random.Range(12, jumpHeight);
            if (other.gameObject.CompareTag("SuperJumpPlatform"))
                velocity.y += 4;
            _rb.velocity = velocity;
        }
    }
}