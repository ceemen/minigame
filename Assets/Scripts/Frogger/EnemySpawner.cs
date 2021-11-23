using System.Collections.Generic;
using UnityEngine;

namespace Frogger
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> prefabList;
        [SerializeField] private List<GameObject> SpawnerList;

        [SerializeField] private float minSpawnRate;
        [SerializeField] private float maxSpawnRate;

        private float _nextSpawn;

        void Start()
        {
            _nextSpawn = Time.time + Random.Range(0, 5);
        }

        // Update is called once per frame
        private void Update()
        {
            if (Time.time < _nextSpawn)
                return;
            int whereSpawns = Random.Range(0, SpawnerList.Count);
            int whatSpawns = Random.Range(0, prefabList.Count);

            switch(whereSpawns)
            {
                case 1:
                    Instantiate(prefabList[whatSpawns], SpawnerList[whereSpawns].transform.position, SpawnerList[whereSpawns].transform.rotation);
                    _nextSpawn = Time.time + Random.Range(minSpawnRate, maxSpawnRate);
                    break;
                case 2:
                    Instantiate(prefabList[whatSpawns], SpawnerList[whereSpawns].transform.position, SpawnerList[whereSpawns].transform.rotation);
                    _nextSpawn = Time.time + Random.Range(minSpawnRate, maxSpawnRate);
                    break;
                default:
                    Instantiate(prefabList[whatSpawns], SpawnerList[whereSpawns].transform.position, SpawnerList[whereSpawns].transform.rotation);
                    _nextSpawn = Time.time + Random.Range(minSpawnRate, maxSpawnRate);
                    break;
            }
        }
    }
}
