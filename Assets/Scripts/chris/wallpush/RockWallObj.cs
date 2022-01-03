using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockWallObj : MonoBehaviour
{
    [SerializeField]
    private bool pushedOut;

    private void Start()
    {
        if (gameObject.tag == "GroundLevelRock")
        {
            pushedOut = true;
        }
        else
        {
            pushedOut = false;
        }
    }

    public bool GetOutBool()
    {
        return pushedOut;
    }
    public void SetOutBool(bool newState)
    {
        pushedOut = newState;
    }

}
