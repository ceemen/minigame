using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMapGenerator : MonoBehaviour
{
    // [SerializeField] private List<GameObject> prefabList;

    public List<GameObject> spawn = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject goToSpawn = spawn[Random.Range(0, spawn.Count)];
        Instantiate(goToSpawn, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
