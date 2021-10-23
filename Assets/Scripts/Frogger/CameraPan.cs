using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public float speed = 2f;
    private float delayCamera = 2f;

    private float timeElapsed;

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if(timeElapsed > delayCamera)
        {
            if (transform.position.z <= 70)
            {
                transform.position += Vector3.forward * Time.deltaTime * speed;
            }
        }
    }
}
