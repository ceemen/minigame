using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Frogger;

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
        StartCoroutine(LevelLoad());
    }

    IEnumerator LevelLoad()
    {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Scenes/Menu");
    }
}
