using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMapGenerator : MonoBehaviour
{
    //[SerializeField] private List<GameObject> spawn = new List<GameObject>();
    private int RNG;

    [SerializeField] private GameObject safefloor;
    [SerializeField] private GameObject PLava;
    [SerializeField] private GameObject LLogLava;
    [SerializeField] private GameObject RLogLava;
    [SerializeField] private GameObject LRoad;
    [SerializeField] private GameObject RRoad;

    // Start is called before the first frame update
    void Start()
    {
        RNG = Random.Range(1, 9);

        if(RNG <= 4)
        {
            Instantiate(safefloor, transform.position, transform.rotation);
        }

        if (RNG == 5)
        {
            Instantiate(PLava, transform.position, transform.rotation);
        }

        if (RNG == 6)
        {
            Instantiate(LLogLava, transform.position, transform.rotation);
        }

        if (RNG == 7)
        {
            Instantiate(RLogLava, transform.position, transform.rotation);
        }

        if (RNG == 8)
        {
            Instantiate(LRoad, transform.position, transform.rotation);
        }

        if (RNG == 9)
        {
            Instantiate(RRoad, transform.position, transform.rotation);
        }
        //GameObject goToSpawn = spawn[Random.Range(0, spawn.Count)];
        //Instantiate(goToSpawn, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
