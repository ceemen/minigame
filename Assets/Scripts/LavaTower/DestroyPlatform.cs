using UnityEngine;

namespace LavaTower
{
    public class DestroyPlatform : MonoBehaviour
    {
        public GameObject player;
        //public GameObject platformPrefab;
        
        private void OnTriggerEnter(Collider other)
        {
            //Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (12 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
            //Destroy(other.gameObject);
            
            other.gameObject.transform.position = new Vector2(Random.Range(-5.5f, 5.5f),
                player.transform.position.y + (12 + Random.Range(0.2f, 1.0f)));
            
            print("moved");
        }
    }
}
