using System;
using UnityEngine;

namespace FloorDrop
{
    public class FloorTile : MonoBehaviour
    {
        private const float DistanceThreshold = 0.5f;
        [SerializeField, ColorUsage(true, true)] private Color startColour, endColour;
        [SerializeField] private float timer;

        private Rigidbody _rb;
        private BoxCollider _collider;
        private MeshRenderer _renderer;

        private float _timeLeft;
        private bool _collided;
        private Vector2 _position;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _collider = GetComponent<BoxCollider>();
            _renderer = GetComponent<MeshRenderer>();
            _timeLeft = timer;
            var position = transform.position;
            _position = new Vector2(position.x, position.z);
        }

        private void CheckCollision(Collision other)
        {
            // Skip if already collided or not enabled
            if (_collided || !enabled)
                return;
            // Skip if not player
            if (!other.gameObject.CompareTag("Player"))
                return;
            // Skip if too far away
            var pos = other.gameObject.transform.position;
            var playerPosition = new Vector2(pos.x, pos.z);
            if (Mathf.Abs(playerPosition.x - _position.x) > DistanceThreshold ||
                Mathf.Abs(playerPosition.y - _position.y) > DistanceThreshold)
                return;
            // Start breaking
            _collided = true;
        }

        private void OnCollisionEnter(Collision other)
        {
            CheckCollision(other);
        }

        private void OnCollisionStay(Collision other)
        {
            CheckCollision(other);
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