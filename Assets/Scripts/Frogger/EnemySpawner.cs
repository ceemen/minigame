using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    List<GameObject> prefabList = new List<GameObject>();

    public GameObject Boulder;
    public GameObject LargeBoulder;
    public GameObject Spawner;

    private float spawnRate = 5f;
    private float nextSpawn = 0f;

    public int whatSpawns;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            whatSpawns = Random.Range(0, 3);
            print(whatSpawns);

            switch (whatSpawns)
            {
                case 1:
                    Instantiate(LargeBoulder, Spawner.transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Boulder, Spawner.transform.position, Quaternion.identity);
                    break;
                default:
                    Instantiate(Boulder, Spawner.transform.position, Quaternion.identity);
                    break;
            }
            nextSpawn = Time.time + spawnRate;
        }
    }
}
