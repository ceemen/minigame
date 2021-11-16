using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnerList;

    public GameObject platform;

    bool check = false;

    void Start()
    {
        int amountSpawn = Random.Range(1, spawnerList.Count);
        int[] spawned = new int[5] { -1, -1, -1, -1, -1 };

        for (int i = 0; i < amountSpawn; i++)
        {
            int whereSpawn = Random.Range(0, spawnerList.Count);

            do
            {
                check = true;

                whereSpawn = Random.Range(0, spawnerList.Count);

                for (int j = 0; j < spawned.Length; j++)
                {
                    if (whereSpawn == spawned[j])
                    {
                        check = false;
                    }
                }
            } while (!check);

            Instantiate(platform, spawnerList[whereSpawn].transform.position, spawnerList[whereSpawn].transform.rotation);
            spawned[i] = whereSpawn;
        }
    }
}
