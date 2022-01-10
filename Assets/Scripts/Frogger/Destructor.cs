using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Frogger;
using CoOp;

public class Destructor : MonoBehaviour
{
    private List<GameObject> players;

    private void Start()
    {
        players = new List<GameObject>();
        players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
    }

    void OnTriggerEnter(Collider collision)
    {
        players.Remove(collision.gameObject);
        Destroy(collision.gameObject);
        if (players.Count == 0)
        {
            SceneTransition.LoadScene(0);
        }
    }
}
