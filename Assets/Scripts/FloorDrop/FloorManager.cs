using System.Collections.Generic;
using UnityEngine;

namespace FloorDrop
{
    public class FloorManager : MonoBehaviour
    {
        [SerializeField] private Vector2Int size;
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
            for (var y = 0; y < size.y; y++)
            {
                for (var x = 0; x < size.x; x++)
                {
                    var tilePosition = new Vector3(
                        0.5f + x - size.x / 2.0f,
                        0, 
                        0.5f + y - size.y / 2.0f);
                    var newTile = Instantiate(floorTilePrefab, tilePosition, Quaternion.identity, transform);
                    _tiles.Add(newTile.GetComponent<FloorTile>());
                }
            }
        }
    }
}
