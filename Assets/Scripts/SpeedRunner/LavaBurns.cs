using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBurns : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Destroy(other.gameObject);
    }
}
