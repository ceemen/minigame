using System;
using UnityEngine;

namespace Menu
{
    public class PlayerAnimation : MonoBehaviour
    {
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Run = Animator.StringToHash("Run");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int Punch = Animator.StringToHash("Punch");
        
        private Animator _animator;
        
        private Vector3 _targetForward;
        private int _animation = Idle;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _targetForward = transform.forward;
        }

        public void Animate(Vector3 velocity, bool grounded)
        {
            // Update rotation.
            var forwardVelocity = new Vector3(velocity.x, 0, velocity.z).normalized;
            var isRunning = forwardVelocity.sqrMagnitude > 0.1;
            if (isRunning)
                _targetForward = forwardVelocity;
            var forward = transform.forward;
            var dot = Vector3.Dot(forward, _targetForward);
            transform.forward = dot < -0.5 ?
                _targetForward :
                Vector3.Lerp(forward, _targetForward, 0.3f);
            // Update animations.
            if (!grounded)
                SetAnimation(Jump);
            else if (isRunning)
                SetAnimation(Run);
            else
                SetAnimation(Idle);
        }

        private void SetAnimation(int newAnimation)
        {
            if (newAnimation == _animation)
                return;
            _animator.SetBool(_animation, false);
            _animation = newAnimation;
            _animator.SetBool(_animation, true);
        }
    }
}