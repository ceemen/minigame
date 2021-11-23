using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> SpawnerList;

    [SerializeField] private GameObject Log;

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
        int whatSpawns = Random.Range(0, SpawnerList.Count);
        Instantiate(Log, SpawnerList[whatSpawns].transform.position, SpawnerList[whatSpawns].transform.rotation);
        _nextSpawn = Time.time + Random.Range(minSpawnRate, maxSpawnRate);
    }
}
