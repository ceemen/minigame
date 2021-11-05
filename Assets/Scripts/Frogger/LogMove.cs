using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMove : MonoBehaviour
{
    private float speed;

    public float minSpeed;
    public float maxSpeed;
    public float deleteTime;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Destroy(gameObject, deleteTime);
    }

    void Move()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
