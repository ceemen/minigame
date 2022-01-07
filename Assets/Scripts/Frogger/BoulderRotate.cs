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
    private GameObject[] players;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        controllers = FindObjectsOfType<PlayerControllerFrogger>();
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
            for(int i = 0; i < controllers.Length; i++)
            {
                controllers[i].enabled = false;
                players[i].transform.localScale -= new Vector3(0, 0.5f, 0);
            }
        }
    }
}
