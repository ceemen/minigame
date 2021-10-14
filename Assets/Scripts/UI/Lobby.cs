using UnityEngine;

namespace UI
{
    public class Lobby : Menu
    {
        [SerializeField] private Canvas mainMenu;

        public void StartGame()
        {
            print("Starting game");
        }

        public void Back()
        {
            ChangeCanvas(mainMenu);
        }
    }
}