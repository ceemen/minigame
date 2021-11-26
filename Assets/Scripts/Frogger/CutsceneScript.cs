using System.Collections;
using System.Collections.Generic;
using Frogger;
using Menu;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    [SerializeField] private GameObject camera1;
    [SerializeField] private GameObject camera2;
    [SerializeField] private GameObject camera3;
    [SerializeField] private GameObject camera4;

	private PlayerControllerFrogger[] players;// = GameObject.FindGameObjectsWithTag("Player");
	
    // Start is called before the first frame update
    void Start()
    {
	    players = FindObjectsOfType<PlayerControllerFrogger>();
	    foreach (var player in players)
			player.enabled = false;
		StartCoroutine(TheSequence());
    }

   IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(0.7f);

        camera2.SetActive(true);
        camera1.SetActive(false);

        yield return new WaitForSeconds(1f);

        camera3.SetActive(true);
        camera2.SetActive(false);

        yield return new WaitForSeconds(2f);

        camera4.SetActive(true);
        camera3.SetActive(false);
		
        foreach (var player in players)
	        player.enabled = true;
    }
}
