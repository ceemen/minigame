using System;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(Canvas))]
    public class Menu : MonoBehaviour
    {
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }

        protected void ChangeCanvas(Canvas canvas)
        {
            _canvas.enabled = false;
            canvas.enabled = true;
        }
    }
}