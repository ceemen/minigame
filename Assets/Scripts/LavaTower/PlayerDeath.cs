using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using CoOp;

namespace LavaTower
{
    public class PlayerDeath : MonoBehaviour
    {
        public TextMeshProUGUI playerDeadText;
        
        private List<GameObject> players;

        public PlayerSpawner spawner;
        
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
                spawner.RemovePlayer(other.gameObject);
                Destroy(other.gameObject);
                if (players.Count == 0)
                {
                    playerDeadText.enabled = true;
                    StartCoroutine(LevelLoad());
                }
            }
        }
        
        IEnumerator LevelLoad()
        {
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene("Scenes/Menu");
        }
        
    }
}
