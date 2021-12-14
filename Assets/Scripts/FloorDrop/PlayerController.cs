using UnityEngine;

namespace FloorDrop
{
    public class PlayerController : Menu.PlayerController
    {
        private const float RayDistance = 0.1f,
            RayOffset = 0.05f;
        protected override bool IsGrounded()
        {
            var ray = new Ray(transform.position + Vector3.up * RayOffset, Vector3.down);
            // Skip if no ray hit
            var result = Physics.Raycast(ray, out var hitInfo, RayDistance, LayerMask.GetMask("Floor"));
            if (!result)
                return false;
            // Make the collided tile break
            hitInfo.collider.GetComponent<FloorTile>().StartBreaking();
            return true;
        }
    }
}