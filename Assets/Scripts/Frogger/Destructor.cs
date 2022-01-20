using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Frogger;
using CoOp;

public class Destructor : MonoBehaviour
{
    [SerializeField] private List<AudioSource> deathSounds;
    private AudioSource deathNoise;

    private PlayerSpawner spawner;
    private List<GameObject> players;

    private void Start()
    {
        spawner = FindObjectOfType<PlayerSpawner>();
        players = spawner.GetPlayers();
    }

    void OnTriggerEnter(Collider collision)
    {
        int randomNumber = Random.Range(1, deathSounds.Count);
        switch (randomNumber)
        {
            case 1:
                deathNoise = deathSounds[randomNumber];
                deathNoise.Play(0);
                break;
            case 2:
                deathNoise = deathSounds[randomNumber];
                deathNoise.Play(0);
                break;
            case 3:
                deathNoise = deathSounds[randomNumber];
                deathNoise.Play(0);
                break;
            case 4:
                deathNoise = deathSounds[randomNumber];
                deathNoise.Play(0);
                break;
            case 5:
                deathNoise = deathSounds[randomNumber];
                deathNoise.Play(0);
                break;
            default:
                deathNoise = deathSounds[randomNumber];
                deathNoise.Play(0);
                break;
        }
        players.Remove(collision.gameObject);
        spawner.RemovePlayer(collision.gameObject);
        Destroy(collision.gameObject);

        if (players.Count <= 1)
        {
            SceneTransition.LoadHub();
        }
    }
}
