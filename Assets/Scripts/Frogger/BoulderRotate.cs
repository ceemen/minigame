using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderRotate : MonoBehaviour
{
    [SerializeField] private int spinSpeed = 100;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinSpeed * Time.deltaTime, 0, 0, Space.Self);
    }
}
