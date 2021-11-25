using UnityEngine;

namespace LavaTower
{
    public class DestroyPlatform : MonoBehaviour
    {
        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.CompareTag("Player"))
        //    {
        //        return;
        //    }
        //    other.gameObject.transform.position = new Vector2(
        //        Random.Range(-7, 7),
        //        Mathf.Round(transform.position.y) + 35 
        //        );
        //}

        [SerializeField]
        private GameObject platformPrefab;
        //[SerializeField]
        //private GameObject shortPlatformPrefab;
        //[SerializeField]
        //private GameObject longPlatformPrefab;

        private int numberOfPlatforms = 200;
        private int levelWidth = 7;
        private int minY = 3;
        private int maxY = 7;

        private void Start()
        {
            Vector3 spawnPosition = new Vector3();

            for (int i = 0; i < numberOfPlatforms; i++)
            {
                spawnPosition.y += Random.Range(minY, maxY);
                spawnPosition.x = Random.Range(-levelWidth, levelWidth);
                Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
                //Instantiate(shortPlatformPrefab, spawnPosition, Quaternion.identity);
                //Instantiate(longPlatformPrefab, spawnPosition, Quaternion.identity);
            }
        }


    }
}
