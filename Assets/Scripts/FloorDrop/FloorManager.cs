using System.Collections.Generic;
using CoOp;
using UnityEngine;

namespace FloorDrop
{
    public class FloorManager : MonoBehaviour
    {
        private const int Size = 10;
        [SerializeField] private GameObject floorTilePrefab;
        private readonly List<FloorTile> _tiles = new List<FloorTile>();

        public List<FloorTile> GetTiles()
        {
            return _tiles;
        }

        private void Start()
        {
            SpawnTiles();
        }

        private void SpawnTiles()
        {
            var size = PlayerManager.GetPlayers().Count * 2 + Size;
            var halfSize = size / 2.0f;
            for (var y = 0; y < size; y++)
            {
                for (var x = 0; x < size; x++)
                {
                    var tilePosition = new Vector3(
                        0.5f + x - halfSize,
                        0, 
                        0.5f + y - halfSize);
                    var newTile = Instantiate(floorTilePrefab, tilePosition, Quaternion.identity, transform);
                    _tiles.Add(newTile.GetComponent<FloorTile>());
                }
            }
        }

        public void GameOver()
        {
            foreach (var floorTile in _tiles)
            {
                floorTile.enabled = false;
            }
        }
    }
}
