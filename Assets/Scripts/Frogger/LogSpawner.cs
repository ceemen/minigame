using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabList;

    public GameObject Log;

    public float minSpawnRate;
    public float maxSpawnRate;

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
        var whatSpawns = Random.Range(0, prefabList.Count);
        Instantiate(Log, prefabList[whatSpawns].transform.position, prefabList[whatSpawns].transform.rotation);
        _nextSpawn = Time.time + Random.Range(minSpawnRate, maxSpawnRate);
    }
}
