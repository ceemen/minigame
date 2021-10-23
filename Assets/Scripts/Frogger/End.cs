using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public AudioSource music;
    public AudioSource endFlair;

    void OnCollisionEnter(Collision collision)
    {
        music.mute = true;
        endFlair.Play(0);
    }
}
