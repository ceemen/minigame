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

            if (!other.gameObject.CompareTag("Platform") && !other.gameObject.CompareTag("SuperJumpPlatform"))
            {
                return;
            }

            if (transform.position.y < other.transform.position.y)
            {
                return; 
            }
            
            var velocity = _rb.velocity;
            velocity = new Vector3(velocity.x, Random.Range(12, jumpHeight), velocity.z);
            _rb.velocity = velocity;

            if (other.gameObject.CompareTag("SuperJumpPlatform"))
            {
                var velocity2 = _rb.velocity;
                velocity2 = new Vector3(velocity2.x, Random.Range(16, jumpHeight + 4), velocity2.z);
                _rb.velocity = velocity2;
            }
        }
    }
}