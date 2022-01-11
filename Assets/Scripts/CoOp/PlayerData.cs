using UnityEngine.InputSystem;

namespace CoOp
{
    public struct PlayerData
    {
        private readonly string _controlScheme;
        private readonly InputDevice _device;
        private int _score;

        public PlayerData(string controlScheme, InputDevice device)
        {
            _controlScheme = controlScheme;
            _device = device;
            _score = 0;
        }

        public string GetControlScheme()
        {
            return _controlScheme;
        }

        public InputDevice GetDevice()
        {
            return _device;
        }

        public int GetScore()
        {
            return _score;
        }

        public void AddScore(int amount)
        {
            _score += amount;
        }

        public bool Equals(PlayerData other)
        {
            return _controlScheme == other._controlScheme && _device == other._device;
        }
    }
}