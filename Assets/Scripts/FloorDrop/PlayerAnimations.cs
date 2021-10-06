using UnityEngine;

namespace FloorDrop
{
    public class PlayerAnimations : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        private Animator _animator;
        private int _animation = Idle;
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Run = Animator.StringToHash("Run");
        private static readonly int Jump = Animator.StringToHash("Jump");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            var velocity = rb.velocity;
            // Update rotation.
            var forwardVelocity = new Vector3(velocity.x, 0, velocity.z).normalized;
            if (forwardVelocity.sqrMagnitude > 0.1)
                transform.forward = forwardVelocity;
            // Update animations.
            if (Mathf.Abs(velocity.y) > 0.6)
                SetAnimation(Jump);
            else if (forwardVelocity.sqrMagnitude < 0.1)
                SetAnimation(Idle);
            else
                SetAnimation(Run);
        }

        public void SetAnimation(int newAnimation)
        {
            _animator.SetBool(_animation, false);
            _animation = newAnimation;
            _animator.SetBool(_animation, true);
        }
    }
}
