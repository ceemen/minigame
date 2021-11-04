using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using UnityEditor;
using UnityEngine;

public class WallPushRandomizer : MonoBehaviour
{
    public GameObject[] wallcubes;
    private float delay = 1.0f;

    // Start is called before the first frame update
    void Awake()
    {
        wallcubes = GameObject.FindGameObjectsWithTag("Cube");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (delay <= 0.0f)
        {
            int numToPush = Random.Range(0, wallcubes.Length);
            Debug.Log(numToPush);
            SelectWallToPush(numToPush);
            delay = 1.0f;
        }

        delay -= Time.deltaTime;

    }

    void SelectWallToPush(int index)
    {
        for (int i = 0; i < wallcubes.Length; i++)
        {
        
            wallcubes[index].SetActive(false);
            
        }
    }
    
}
