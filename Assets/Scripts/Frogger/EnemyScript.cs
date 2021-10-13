using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speed;

    public float minSpeed = 30;
    public float maxSpeed = 50;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Destroy(gameObject, 2);
    }

    void Move()
    {
        transform.position += transform.forward * Time.deltaTime * speed; 
    }
}
