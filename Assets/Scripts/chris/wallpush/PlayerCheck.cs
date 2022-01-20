using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{

    [SerializeField]
    private WallPushRandomizer randomizerScript;
    private float timeBeforeMoving = 3.0f;
    private float colliderrestoreTime = 3.0f;
    private BoxCollider boxTriggerCollider;

    private void Awake()
    {
        randomizerScript = FindObjectOfType<WallPushRandomizer>();
        boxTriggerCollider.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (boxTriggerCollider.enabled == false)
        {
            colliderrestoreTime -= Time.deltaTime;
            if (colliderrestoreTime <= 0.0f)
            {
                colliderrestoreTime = 3.0f;
                boxTriggerCollider.enabled = true;
            }
        }

    }



    private void OnTriggerStay(Collider other)
    {
        if (randomizerScript.GetGameState() == WallPushRandomizer.GameState.gameStarted)
        {
            if (other.tag == "Player")
            {
                if (timeBeforeMoving >= 0.0f)
                {
                    timeBeforeMoving -= Time.deltaTime;
                }
                if (timeBeforeMoving <= 0.0f && this.gameObject != randomizerScript.GetCurrentMovingWall())
                {
                    randomizerScript.SelectWallToPush(this.gameObject);
                    boxTriggerCollider.enabled = false;
                    print("Get Off Me!!");
                    timeBeforeMoving = 3.0f;
                }
            }
        }
    }


}
