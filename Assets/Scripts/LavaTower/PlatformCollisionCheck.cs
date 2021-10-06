using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollisionCheck : MonoBehaviour
{
    public BoxCollider platform;
    public bool oneWay;

    void Update()
    {
        if (oneWay)
        {
            platform.enabled = false;
        }
        if (!oneWay)
        {
            platform.enabled = true;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        oneWay = true;
    }

    void OnTriggerExit(Collider collider)
    {
        oneWay = false;
    }
}
