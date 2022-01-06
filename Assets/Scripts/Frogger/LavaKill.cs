using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaKill : MonoBehaviour
{
   void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.collider.gameObject);
    }
}
