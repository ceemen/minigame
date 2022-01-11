using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class MainMenu : Menu
    {
        [SerializeField] private Canvas lobby;
        [SerializeField] private Canvas options;
        [SerializeField] private PlayerInputManager inputManager;

        public void StartGame()
        {
            ChangeCanvas(lobby);
            inputManager.enabled = true;
        }
        public void OptionsGame()
        {
            ChangeCanvas(options);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
