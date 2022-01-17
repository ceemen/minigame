using System.Collections;
using UnityEngine;

namespace LavaTower
{
    public class BreakablePlatform : MonoBehaviour
    {
        private MeshRenderer _mr;
        private BoxCollider _bc;
        private void Awake()
        {
            _mr = GetComponentInChildren<MeshRenderer>();
            _bc = GetComponentInChildren<BoxCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (transform.position.y < other.transform.position.y)
            {
                _mr.enabled = false;
                _bc.enabled = false;
                StartCoroutine(Enable());
            }
        }
        
        IEnumerator Enable()
        {
            yield return new WaitForSeconds(2.0f);
            _mr.enabled = true;
            _bc.enabled = true;
        }
    }
}
