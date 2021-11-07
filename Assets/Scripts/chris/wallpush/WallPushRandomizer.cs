using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPushRandomizer : MonoBehaviour
{
    //public List<GameObject> WallRockss;
    public GameObject[] wallRocks;
    private float delay = 5.0f;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (delay <= 0.0f)
        {
            int numToPush = Random.Range(0, wallRocks.Length);
            Debug.Log(numToPush);
            SelectWallToPush(numToPush);
            delay = 1.0f;
        }

        delay -= Time.deltaTime;



    }

    void SelectWallToPush(int index)
    {
        if (wallRocks[index].GetComponent<RockWallObj>().GetOutBool())
        {
            wallRocks[index].GetComponent<Animator>().SetTrigger("Pull");
            wallRocks[index].GetComponent<RockWallObj>().SetOutBool(false);
        }
        else if(!wallRocks[index].GetComponent<RockWallObj>().GetOutBool())
        {
            wallRocks[index].GetComponent<Animator>().SetTrigger("Push");
            wallRocks[index].GetComponent<RockWallObj>().SetOutBool(true);
        }
            
       
    }
    
}
