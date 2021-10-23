using UnityEngine;

namespace FloorDrop
{
    public class LavaFlow : MonoBehaviour
    {
        [SerializeField] private Vector2 speed;
        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void Update()
        {
            _renderer.material.mainTextureOffset += speed * Time.deltaTime;
        }
    }
}