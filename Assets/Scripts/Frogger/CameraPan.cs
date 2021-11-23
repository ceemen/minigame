using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Menu;

public class CameraPan : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    private readonly List<Transform> players = new List<Transform>();

    private void Start()
    {
        var controllers = FindObjectsOfType<PlayerControllerFrogger>();
        foreach (var player in controllers)
        {
            players.Add(player.transform);
        }
    }

    private void LateUpdate()
    {
        players.RemoveAll(player => player == null);
        var position = transform.position;
        foreach (var player in players)
        {
            var playerDistance = player.position.z;
            
            if (playerDistance <= position.z - offset.z)
                return;
            position.z = playerDistance;
        }
        transform.position = position + offset;
    }
}
