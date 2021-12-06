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
            if (!other.gameObject.CompareTag("Platform"))
            {
                return;
            }

            if (transform.position.y < other.transform.position.y)
            {
                return; 
            }
            
            var velocity = _rb.velocity;
            velocity = new Vector3(velocity.x, jumpHeight, velocity.z);
            _rb.velocity = velocity;
        }
    }
}