using System.Collections.Generic;
using CoOp;
using TMPro;
using UnityEngine;

namespace Hub
{
    public class MiniGameDisplay : MonoBehaviour
    {
        private const float Threshold = 0.5f;
        private TMP_Text _text;
        private MiniGame nextMiniGame;
        private List<MiniGame> miniGames;
        private int miniGameIndex;
        private float _changeTime = 0.01f,
            _changeTimer;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            var randomMiniGame = FindObjectOfType<RandomMiniGame>();
            miniGames = new List<MiniGame>(randomMiniGame.GetMiniGames());
            nextMiniGame = randomMiniGame.PickRandom();
        }

        private void Update()
        {
            if (_changeTime > Threshold)
            {
                _text.text = nextMiniGame.Name;
                Invoke(nameof(LoadNextScene), 2);
                enabled = false;
            }
            if (_changeTimer < _changeTime)
            {
                _changeTimer += Time.deltaTime;
                return;
            }
            _changeTimer = 0;
            _changeTime *= 1.05f;
            _text.text = miniGames[miniGameIndex].Name;
            miniGameIndex++;
            if (miniGameIndex >= miniGames.Count)
                miniGameIndex = 0;
        }

        private void LoadNextScene()
        {
            SceneTransition.LoadScene(nextMiniGame.Scene);
        }
    }
}