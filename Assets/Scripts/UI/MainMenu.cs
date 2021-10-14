using UnityEngine;

namespace UI
{
    public class MainMenu : Menu
    {
        [SerializeField] private Canvas lobby;

        public void StartGame()
        {
            ChangeCanvas(lobby);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
