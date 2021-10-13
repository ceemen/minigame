using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabList;
    public GameObject platform;

    void Start()
    {
        var whereSpawn = Random.Range(0, prefabList.Count);

        switch (whereSpawn)
        {
            case 1:
                Instantiate(platform, prefabList[whereSpawn].transform.position, prefabList[whereSpawn].transform.rotation);
                break;
            case 2:
                Instantiate(platform, prefabList[whereSpawn].transform.position, prefabList[whereSpawn].transform.rotation);
                break;
            case 3:
                Instantiate(platform, prefabList[whereSpawn].transform.position, prefabList[whereSpawn].transform.rotation);
                break;
            default:
                Instantiate(platform, prefabList[whereSpawn].transform.position, prefabList[whereSpawn].transform.rotation);
                break;
        }
    }
}
