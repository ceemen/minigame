using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoOp
{
    public class WallPushDeath : MonoBehaviour
    {

        public PlayerSpawner playerSpawner;


        private void OnTriggerEnter(Collider player)
        {
            if (player.gameObject.tag == "Player")
            {
                print($"{player.name} has been eliminated");
                playerSpawner.RemovePlayer(player.gameObject);
                GameObject.Destroy(player.gameObject);
            }
        }

    }
}
