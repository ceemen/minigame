using UnityEngine;

namespace FloorDrop
{
    public class FloorTile : MonoBehaviour
    {
        [SerializeField] private Color breakColourStart;
        [SerializeField] private Color breakColourEnd;
        [SerializeField] private float timer;
        private float _timeLeft;
        private bool _collided;
        private Rigidbody _rb;
        private BoxCollider _collider;
        private MeshRenderer _renderer;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _collider = GetComponent<BoxCollider>();
            _renderer = GetComponent<MeshRenderer>();
            _timeLeft = timer;
        }

        private void OnCollisionEnter(Collision other)
        {
            // Only collide with players.
            if (!other.gameObject.CompareTag("Player"))
                return;
            _collided = true;
        }

        private void Update()
        {
            if (!_collided)
                return;
            if (_timeLeft > 0)
            {
                _renderer.material.color = Color.Lerp(breakColourEnd, breakColourStart, _timeLeft / timer);
                _timeLeft -= Time.deltaTime;
            }
            else
            {
                Break();
            }
        }

        private void Break()
        {
            _rb.isKinematic = false;
            _collider.enabled = false;
            _renderer.material.color = breakColourEnd;
        }
    }
}