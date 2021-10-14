using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class MainMenu : Menu
    {
        [SerializeField] private Canvas lobby;
        [SerializeField] private PlayerInputManager inputManager;

        public void StartGame()
        {
            ChangeCanvas(lobby);
            inputManager.enabled = true;
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
