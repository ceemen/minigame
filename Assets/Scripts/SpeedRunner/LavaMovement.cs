using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SRunner
{ 
    public class LavaMovement : MonoBehaviour
    {
        [SerializeField] private Vector2 speed;
        [SerializeField] private Vector2 flowChange;
    
        private Vector2 currentChange;
        private Renderer render;
    
        private void Awake()
        {
            render = GetComponent<Renderer>();
        }
    
        private void Update()
        {
            currentChange.x = flowChange.x * Random.Range(-1.0f, 1.0f);
            currentChange.y = flowChange.y * Random.Range(-1.0f, 1.0f);
            speed += currentChange * Time.deltaTime;
            render.material.mainTextureOffset += speed * Time.deltaTime;
        }
    }
}
