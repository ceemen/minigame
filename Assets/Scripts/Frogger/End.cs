using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource endFlair;

    void OnCollisionEnter(Collision collision)
    {
        music.mute = true;
        endFlair.Play(0);
    }
}
