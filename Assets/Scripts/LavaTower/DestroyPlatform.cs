using UnityEngine;

namespace LavaTower
{
    public class DestroyPlatform : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                return;
            }
            other.gameObject.transform.position = new Vector2(
                Random.Range(-7, 7),
                Mathf.Round(transform.position.y) + 35 
                );
        }
    }
}
