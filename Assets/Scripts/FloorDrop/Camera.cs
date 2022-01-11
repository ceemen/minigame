using CoOp;
using UnityEngine;

namespace FloorDrop
{
    public class Camera : MonoBehaviour
    {
        private void Start()
        {
            var position = transform.position;
            position.y = 10 + PlayerManager.GetPlayers().Count * 2;
            transform.position = position;
        }
    }
}