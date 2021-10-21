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

        public static bool operator ==(PlayerData x, PlayerData y)
        {
            return x._controlScheme == y._controlScheme && x._device == y._device;
        }

        public static bool operator !=(PlayerData x, PlayerData y)
        {
            return !(x == y);
        }
    }
}