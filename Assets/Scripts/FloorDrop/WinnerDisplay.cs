using System;
using CoOp;
using TMPro;
using UnityEngine;

namespace FloorDrop
{
    public class WinnerDisplay : MonoBehaviour
    {
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        public void GameOver()
        {
            var winner = PlayerManager.GetWinners()[0];
            _text.text = $"Player {winner + 1} won";
            _text.enabled = true;
        }
    }
}