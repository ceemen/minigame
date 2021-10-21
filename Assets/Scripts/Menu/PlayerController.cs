using UnityEngine;
using UnityEngine.InputSystem;

namespace Menu
{
    public class PlayerController : MonoBehaviour
    {
        private const float RunSpeed = 3;
        private const float JumpHeight = 5;

        [SerializeField] private PlayerAnimation playerAnimation;

        private Rigidbody _rb;
        private Vector2 _runInput;
        private bool _actionHeld;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void OnRun(InputAction.CallbackContext input)
        {
            _runInput = input.ReadValue<Vector2>();
        }

        public void OnAction(InputAction.CallbackContext input)
        {
            _actionHeld = input.ReadValueAsButton();
        }

        private void FixedUpdate()
        {
            var grounded = IsGrounded();
            var velocity = _rb.velocity;
            // Horizontal movement.
            velocity.x = _runInput.x * RunSpeed;
            velocity.z = _runInput.y * RunSpeed;
            // Jump.
            if (_actionHeld && grounded)
            {
                grounded = false;
                velocity.y = JumpHeight;
            }
            // Apply velocity.
            _rb.velocity = velocity;
            playerAnimation.Animate(velocity, grounded);
        }

        private bool IsGrounded()
        {
            var ray = new Ray(transform.position + Vector3.up * 0.1f, Vector3.down);
            return Physics.Raycast(ray, out var hitInfo, 0.2f, LayerMask.GetMask("Floor"));
        }
    }
}
