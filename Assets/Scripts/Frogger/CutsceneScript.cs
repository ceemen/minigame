using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject camera4;

	private GameObject[] players;// = GameObject.FindGameObjectsWithTag("Player");
	
    // Start is called before the first frame update
    void Start()
    {
		players = GameObject.FindGameObjectsWithTag("Player");
		for(int i = 0; i < players.Length; i++)
		{
			MonoBehaviour script = players[i].GetComponent("PlayerControllerFrogger")as MonoBehaviour;
			script.enabled = false;
		}
		
        StartCoroutine(TheSequence());
    }

   IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(1);

        camera2.SetActive(true);
        camera1.SetActive(false);

        yield return new WaitForSeconds(1);

        camera3.SetActive(true);
        camera2.SetActive(false);

        yield return new WaitForSeconds(2);

        camera4.SetActive(true);
        camera3.SetActive(false);
		
		players = GameObject.FindGameObjectsWithTag("Player");
		for(int i = 0; i < players.Length; i++)
		{
			MonoBehaviour script = players[i].GetComponent("PlayerControllerFrogger")as MonoBehaviour;
			script.enabled = true;
		}
    }
}
