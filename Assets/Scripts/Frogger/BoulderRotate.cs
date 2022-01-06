using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Frogger;
using Menu;

public class BoulderRotate : MonoBehaviour
{
    [SerializeField] private GameObject playerDecal;

    [SerializeField] private int spinSpeed = 100;

    private PlayerControllerFrogger[] controllers;
   // private CapsuleCollider[] collisions;
    //private GameObject[] players;

    void Start()
    {
        //collisions = FindObjectsOfType<CapsuleCollider>();
        controllers = FindObjectsOfType<PlayerControllerFrogger>();
        //players = FindObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinSpeed * Time.deltaTime, 0, 0, Space.Self);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            for(int i = 0; i < players.Length; i++)
            {
                controllers[i].enabled = false;
                collisions[i].enabled = false;
            }
        }
    }
}
