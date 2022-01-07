using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Frogger;

public class LavaKill : MonoBehaviour
{
    private PlayerControllerFrogger[] players;

    void OnCollisionEnter(Collision collision)
    {
        for(int i = 0; i < players.Length; i++)
        {
            players[i].enabled = false;
        }
    }
}
