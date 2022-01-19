using System.Globalization;
using TMPro;
using UnityEngine;

namespace FloorDrop
{
    public class MiniGameManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private FloorManager floorManager;
        private float _timeLeft = 3f;
        private bool _started;

        private void Update()
        {
            // Skip if already enabled tiles.
            if (_started && _timeLeft <= 0)
                return;
            // Count down timer until game starts.
            if (!_started)
            {
                _timeLeft -= Time.deltaTime;
                // Once timer reaches 0, start the game.
                if (_timeLeft <= 0)
                {
                    _started = true;
                    timerText.enabled = false;
                }
                else
                {
                    timerText.text = Mathf.Ceil(_timeLeft).ToString(CultureInfo.CurrentCulture);
                    return;
                }
            }
            // Enable all tiles when the game starts.
            var tiles = floorManager.GetTiles();
            foreach (var tile in tiles)
            {
                tile.enabled = true;
            }
        }
    }
}
