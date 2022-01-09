using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Frogger;
using CoOp;

public class End : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource endFlair;
    [SerializeField] private GameObject winText;
    
    void OnCollisionEnter(Collision collision)
    {
        music.mute = true;
        endFlair.Play(0);
        winText.gameObject.SetActive(true);
        StartCoroutine(WaitForMusic());
    }

    private IEnumerator WaitForMusic()
    {
        yield return new WaitForSeconds(4);
        SceneTransition.LoadScene(0);
    }
}
