using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderRotate : MonoBehaviour
{
    public GameObject playerDecal;

	public int spinSpeed = 100;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinSpeed * Time.deltaTime, 0, 0, Space.Self);
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
