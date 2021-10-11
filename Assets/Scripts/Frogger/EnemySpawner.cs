using System.Collections.Generic;
using UnityEngine;

namespace Frogger
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> prefabList;

        private const float SpawnRate = 2.5f;
        private float _nextSpawn;

        // Update is called once per frame
        private void Update()
        {
            if (Time.time < _nextSpawn)
                return;
            var whatSpawns = Random.Range(0, prefabList.Count);
            Instantiate(prefabList[whatSpawns], transform.position, transform.rotation);
            _nextSpawn = Time.time + SpawnRate;
        }
    }
}
