using UnityEngine.InputSystem;

namespace CoOp
{
    public struct PlayerData
    {
        private readonly PlayerInput _input;
        private int _score;

        public PlayerData(PlayerInput player)
        {
            _input = player;
            _score = 0;
        }

        public PlayerInput GetInput()
        {
            return _input;
        }

        public int GetScore()
        {
            return _score;
        }

        public void AddScore(int amount)
        {
            _score += amount;
        }
    }
}