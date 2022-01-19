using UnityEngine;

namespace LavaTower
{
    public class DestroyPlatform : MonoBehaviour
    {
        [SerializeField] private GameObject[] platformPrefabs;

        private void Start()
        {
            Vector3 spawnPosition = new Vector3();
            
            for (int i = 0; i < 200; i++)
           {
               spawnPosition.y += Random.Range(3, 7);
               spawnPosition.x = Random.Range(-7, 7);
               int randomIndex = Random.Range(0, platformPrefabs.Length);
               Instantiate(platformPrefabs[randomIndex], spawnPosition, Quaternion.Euler(0, 180, 0));
           }
        }
    }
}
