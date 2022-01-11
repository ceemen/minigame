using UnityEngine;
using UnityEngine.SceneManagement;

namespace CoOp
{
    public class EndMinigame : MonoBehaviour
    {
        public void End()
        {
            PlayerManager.RemovePlayers();
            SceneManager.LoadScene("Menu");
        }
    }
}