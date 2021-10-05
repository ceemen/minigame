using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FloorDrop
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpHeight;
        [SerializeField] private InputActionReference moveAction;
        [SerializeField] private InputActionReference actionAction;
        private Vector2 _moveInput;
        private bool _actionHeld;
        private bool _grounded;
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            moveAction.action.performed += OnMove;
            moveAction.action.canceled += OnMove;
            actionAction.action.performed += OnAction;
            actionAction.action.canceled += OnAction;
        }

        private void OnEnable()
        {
            moveAction.action.Enable();
            actionAction.action.Enable();
        }

        private void OnDisable()
        {
            moveAction.action.Enable();
            actionAction.action.Disable();
        }

        private void OnMove(InputAction.CallbackContext input)
        {
            _moveInput = input.ReadValue<Vector2>();
        }
        
        private void OnAction(InputAction.CallbackContext input)
        {
            _actionHeld = input.performed;
        }

        private void FixedUpdate()
        {
            var velocity = _rb.velocity;
            velocity.x = _moveInput.x * speed;
            velocity.z = _moveInput.y * speed;
            // Jump.
            if (_actionHeld && _grounded)
            {
                velocity.y = jumpHeight;
                _grounded = false;
            }
            _rb.velocity = velocity;
        }

        private void OnCollisionEnter(Collision other)
        {
            // Check if already grounded.
            if (_grounded)
                return;
            foreach (var contact in other.contacts)
            {
                var dot = Vector3.Dot(contact.normal, Vector3.up);
                // Skip if not colliding with floor.
                if (dot < 0.9)
                    continue;
                _grounded = true;
                return;
            }
        }
    }
}
