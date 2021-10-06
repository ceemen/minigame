using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBounce : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>().velocity.y <= 0)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 600f);
        }
    }
}
