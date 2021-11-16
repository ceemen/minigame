using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LavaTower
{
    public class PlayerDeath : MonoBehaviour
    {
        public TextMeshProUGUI PlayerDeadText;
        
        private List<GameObject> players;

        private void Start()
        {
            players = new List<GameObject>();
            
            players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (players.Contains(other.gameObject))
            {
                players.Remove(other.gameObject);
                Destroy(other.gameObject);
                if (players.Count == 0)
                {
                    PlayerDeadText.enabled = true;
                    StartCoroutine(LevelLoad());
                }
            }

            //foreach (GameObject g in players.ToArray())
            //{
            //    Destroy(g);
            //}
            
            //for (int i = 0; i < players.Length; i++)
            //{
            //    Destroy(players[i]);
            //}
            //print(players.Count);
        }
        
        IEnumerator LevelLoad()
        {
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene("Scenes/Menu");
        }
        
    }
}
