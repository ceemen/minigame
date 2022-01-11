using CoOp;
using TMPro;
using UnityEngine;

namespace LavaTower
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerDeadText;

        private void LoadHub()
        {
            SceneTransition.LoadHub();
        }
        
        public void OnGameOver()
        {
            playerDeadText.enabled = true;
            Invoke(nameof(LoadHub), 3.0f);
        }
    }
}
