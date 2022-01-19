using UnityEngine;

namespace CoOp
{
    public class MiniGameOver : MonoBehaviour
    {
        [SerializeField] private float delay = 2f;

        public void GameOver()
        {
            Invoke(nameof(Transition), delay);
        }

        private void Transition()
        {
            SceneTransition.LoadHub();
        }
    }
}