using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{



    public int numPlayers = 1;

    [SerializeField] private int gameLength = 300;
    [SerializeField] private GameObject[] floatPlatforms;
    [SerializeField] private GameObject[] raisedPlatforms;


    void Start()
    {

        for (int i = 0; i < gameLength; i++)
        {

        }
    }

}
