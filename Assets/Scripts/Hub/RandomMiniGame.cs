using System.Collections.Generic;
using UnityEngine;

namespace Hub
{
    public struct MiniGame
    {
        public string Name,
            Scene;

        public MiniGame(string name, string scene)
        {
            Name = name;
            Scene = scene;
        }
    }
    public class RandomMiniGame : MonoBehaviour
    {
        private readonly List<MiniGame> miniGames = new List<MiniGame>
        {
            new MiniGame("Floor Drop", "Scenes/FloorDrop"),
            new MiniGame("Lava Tower", "Scenes/LavaTower"),
            //new MiniGame("Wallpush", "Scenes/Wallpush"),
            new MiniGame("Lava Road", "Scenes/Frogger"),
            new MiniGame("Lavarunner", "Scenes/Speedrunner"),
        };

        public List<MiniGame> GetMiniGames()
        {
            return miniGames;
        }

        public MiniGame PickRandom()
        {
            var randomIndex = Random.Range(0, miniGames.Count);
            var miniGame = miniGames[randomIndex];
            miniGames.RemoveAt(randomIndex);
            return miniGame;
        }
    }
}