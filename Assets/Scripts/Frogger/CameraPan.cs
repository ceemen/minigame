using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public int speed = 1;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z <= 70)
        {
            transform.position += Vector3.forward * Time.deltaTime * speed;
        }
    }
}
