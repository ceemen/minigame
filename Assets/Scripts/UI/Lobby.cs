using CoOp;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI
{
    public class Lobby : Menu
    {
        [SerializeField] private Animator transition; 
        [SerializeField] private Canvas mainMenu;
        [SerializeField] private Button startButton;
        [SerializeField] private RectTransform panel;
        [SerializeField] private GameObject playerNameTextPrefab;
        [SerializeField] private PlayerInputManager inputManager;

        public void StartGame()
        {
            inputManager.enabled = false;
            SceneTransition.LoadScene(3);
        }

        public void Back()
        {
            ChangeCanvas(mainMenu);
            inputManager.enabled = false;
        }

        public void AddPlayer(PlayerInput player)
        {
            var newText = Instantiate(playerNameTextPrefab, panel);
            var textComponent = newText.GetComponent<TextMeshProUGUI>();
            textComponent.text = $"Player {player.playerIndex + 1}";
            textComponent.color = PlayerManager.GetPlayerColour(player.playerIndex);
            newText.transform.SetSiblingIndex(GetChildIndex(player.playerIndex));
            // Enable the start button when the second player joins.
            if (player.playerIndex == 1)
                startButton.interactable = true;
        }

        public void RemovePlayer(PlayerInput player)
        {
            Destroy(panel.GetChild(GetChildIndex(player.playerIndex)).gameObject);
        }

        private int GetChildIndex(int playerIndex)
        {
            return playerIndex + 1;
        }
    }
}
