using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent = GameObject.Find("Flooring").transform;
    }
}
