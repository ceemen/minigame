using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Frogger;
using CoOp;
using UnityEngine.SceneManagement;

public class LavaKill : MonoBehaviour
{
    //private PlayerControllerFrogger[] players;

    [SerializeField] private GameObject loseText;

    private List<GameObject> players;

    private void Start()
    {
        players = new List<GameObject>();
        loseText = GameObject.Find("Lose Text");
        players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
       
    }

    void OnCollisionEnter(Collision collision)
    {
        players.Remove(collision.gameObject);
        Destroy(collision.gameObject);
        if (players.Count <= 0)
        {
            loseText.gameObject.SetActive(true);
        }
        //for(int i = 0; i < players.Count; i++)
        //{
        //    players[i].enabled = false;

        //}
    }

    IEnumerator LevelLoad()
    {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Scenes/Menu");
    }
}
