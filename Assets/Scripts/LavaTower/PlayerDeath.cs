using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using CoOp;

namespace LavaTower
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private Animator transition;
        [SerializeField] private TextMeshProUGUI playerDeadText;
        [SerializeField] private PlayerSpawner spawner;
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
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(2.0f);
            SceneTransition.LoadScene(0);
        }
        
    }
}
