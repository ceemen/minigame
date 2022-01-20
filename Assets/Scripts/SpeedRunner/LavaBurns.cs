using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SRunner
{
    public class LavaBurns : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                GameObject gM = GameObject.Find("GameManager");
                SpeedRun script = (SpeedRun)gM.GetComponent(typeof(SpeedRun));
                script.killPlayer(other.gameObject);
            }
        }
    }
}
