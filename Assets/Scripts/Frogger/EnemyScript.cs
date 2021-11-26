using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float deleteTime;

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
