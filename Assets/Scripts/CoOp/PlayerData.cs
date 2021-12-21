using UnityEngine.InputSystem;

namespace CoOp
{
    public struct PlayerData
    {
        private readonly string _controlScheme;
        private readonly InputDevice[] _devices;
        private int _score;

        public PlayerData(string controlScheme, InputDevice[] devices)
        {
            _controlScheme = controlScheme;
            _devices = devices;
            _score = 0;
        }

        public string GetControlScheme()
        {
            return _controlScheme;
        }

        public InputDevice[] GetDevices()
        {
            return _devices;
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
            return _controlScheme == other._controlScheme && _devices == other._devices;
        }
    }
}