using System.Collections;
using System.Collections.Generic;
using Menu;
using UnityEngine;
using UnityEngine.InputSystem;


namespace SRunner
{
    public class SRunController : MonoBehaviour
    {
        public float runSpeed = 3;
        [SerializeField] private float jumpHeight = 5;
        [SerializeField] private PlayerAnimation playerAnimation;

        private Rigidbody rb;
        private float sideInput;
        private bool _actionHeld;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void OnRun(InputAction.CallbackContext input)
        {
            sideInput = input.ReadValue<Vector2>().x;
        }

        public void OnAction(InputAction.CallbackContext input)
        {
            _actionHeld = input.ReadValueAsButton();
        }

        private void FixedUpdate()
        {
            bool grounded = IsGrounded();
            Vector3 velocity = rb.velocity;
            velocity.z = 0;
            velocity.x = sideInput * runSpeed;
            
            // Jump.
            if (_actionHeld && grounded)
            {
                grounded = false;
                velocity.y = jumpHeight;
            }

            rb.velocity = velocity;
            playerAnimation.Animate(velocity, grounded);
        }

        private bool IsGrounded()
        {
            var ray = new Ray(transform.position + Vector3.up * 0.1f, Vector3.down);
            return Physics.Raycast(ray, out var hitInfo, 0.2f, LayerMask.GetMask("Floor"));
        }
    }
}
