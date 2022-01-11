using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SRunner
{
    public class LevelGen : MonoBehaviour
    {

        public int numPlayers = 1;

        [SerializeField] private int gameLength = 300;
        [SerializeField] private GameObject[] floatPlatforms;
        [SerializeField] private GameObject[] raisedPlatforms;

        private int platformHeight;
        private int prevFloat = 0;
        private int prevRaised;

        void Start()
        {
            platformHeight = 0;
            Vector3 spawnPosition = new Vector3();
            int floatIndex = 0;
            int raiseIndex = 0;
            for (int i = 0; i < gameLength; i++)
            {
                spawnPosition.x = i * 13;
                spawnPosition.y = platformHeight * 2;
                floatIndex = Random.Range(0, floatPlatforms.Length);
                if (floatIndex == prevFloat)
                    floatIndex = (++floatIndex) % floatPlatforms.Length;
                raiseIndex = Random.Range(0, raisedPlatforms.Length);
                if (raiseIndex == prevFloat)
                    raiseIndex = (++raiseIndex) % raisedPlatforms.Length;

                for (int j = 0; j < numPlayers; j++)
                {
                    spawnPosition.z = j * 3;
                    if (i == 0)
                        Instantiate(floatPlatforms[0], spawnPosition, Quaternion.identity);
                    else if (platformHeight == 0)
                    {
                        Instantiate(floatPlatforms[floatIndex], spawnPosition, Quaternion.identity);
                    }
                    else if (platformHeight > 0)
                    {
                        Instantiate(raisedPlatforms[raiseIndex], spawnPosition, Quaternion.identity);
                    }
                }

                platformHeight += Random.Range(-1, 2);
                while (platformHeight > 2 || platformHeight < 0)
                {
                    platformHeight += Random.Range(-1, 2);
                }
            }
        }

    }
}
