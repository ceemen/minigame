using System.Collections.Generic;
using UnityEngine;

namespace Frogger
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> prefabList;

        [SerializeField] private float minSpawnRate;
        [SerializeField] private float maxSpawnRate;

        private float _nextSpawn;

        void Start()
        {
            _nextSpawn = Time.time + Random.Range(0, 4);
        }

        // Update is called once per frame
        private void Update()
        {
            if (Time.time < _nextSpawn)
                return;
            int whatSpawns = Random.Range(0, prefabList.Count);

            switch(whatSpawns)
            {
                case 1:
                    Instantiate(prefabList[whatSpawns], transform.position, transform.rotation);
                    _nextSpawn = Time.time + Random.Range(minSpawnRate, maxSpawnRate);
                    break;
                case 2:
                    Instantiate(prefabList[whatSpawns], transform.position, transform.rotation);
                    _nextSpawn = Time.time + Random.Range(minSpawnRate, maxSpawnRate);
                    break;
                default:
                    Instantiate(prefabList[whatSpawns], transform.position, transform.rotation);
                    _nextSpawn = Time.time + Random.Range(minSpawnRate, maxSpawnRate);
                    break;
            }
        }
    }
}
