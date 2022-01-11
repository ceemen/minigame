using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMapGenerator : MonoBehaviour
{
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
        RNG = Random.Range(1, 8);

        if(RNG <= 3)
        {
            Instantiate(safefloor, transform.position, transform.rotation);
        }

        if (RNG == 4)
        {
            Instantiate(PLava, transform.position, transform.rotation);
        }

        if (RNG == 5)
        {
            Instantiate(LLogLava, transform.position, transform.rotation);
        }

        if (RNG == 6)
        {
            Instantiate(RLogLava, transform.position, transform.rotation);
        }

        if (RNG == 7)
        {
            Instantiate(LRoad, transform.position, transform.rotation);
        }

        if (RNG == 8)
        {
            Instantiate(RRoad, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
