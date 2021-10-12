using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public AudioSource music;
    public AudioSource endFlair;

    private double nextEventTime;

    // Start is called before the first frame update
    void Start()
    {
        nextEventTime = AudioSettings.dspTime + 50f;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Game End");

        music.mute = true;
        endFlair.Play(0);
    }
}
