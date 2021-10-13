using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speed;

    public float minSpeed = 30;
    public float maxSpeed = 50;
    public float deleteTime = 2f;

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
