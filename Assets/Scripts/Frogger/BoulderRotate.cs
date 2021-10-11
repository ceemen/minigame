using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderRotate : MonoBehaviour
{
    public GameObject playerDecal;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(50 * Time.deltaTime, 0, 0, Space.Self);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(playerDecal, col.gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
        }
    }
}
