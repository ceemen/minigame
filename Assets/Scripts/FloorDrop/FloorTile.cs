using UnityEngine;

namespace FloorDrop
{
    public class FloorTile : MonoBehaviour
    {
        [SerializeField, ColorUsage(true, true)] private Color startColour, endColour;
        [SerializeField] private float timer;

        private Rigidbody _rb;
        private BoxCollider _collider;
        private MeshRenderer _renderer;

        private float _timeLeft;
        private bool _collided;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _collider = GetComponent<BoxCollider>();
            _renderer = GetComponent<MeshRenderer>();
            _timeLeft = timer;
        }

        public void StartBreaking()
        {
            if (enabled)
                _collided = true;
        }

        private void Update()
        {
            if (!_collided)
                return;
            if (_timeLeft > 0)
            {
                var emissionColour = Color.Lerp(endColour, startColour, _timeLeft / timer);
                _renderer.material.color = emissionColour;
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
            _renderer.material.color = endColour;
        }
    }
}