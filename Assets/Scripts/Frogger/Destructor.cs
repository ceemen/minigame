using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.collider.gameObject);
    }
}
