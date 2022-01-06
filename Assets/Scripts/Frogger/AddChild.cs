using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddChild : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            col.gameObject.transform.SetParent(gameObject.transform, true);
        }
    }

    void OnCollisionExit(Collision col)
    {
        col.gameObject.transform.parent = null;
    }
}
