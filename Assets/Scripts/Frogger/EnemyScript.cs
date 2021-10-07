using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject playerDecal;
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(10, 50);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            Instantiate(playerDecal, col.gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
        }
    }
}
