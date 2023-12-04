using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SecretManager : MonoBehaviour
{
    //_-_-Funky lil' variables_-_-_
    Player player;
    public Transform teleportLocation;
    //_-_-_-_-_-_-_-_-_-_-_-_-_-_-_

    //Get player using Player tag
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }
    //When the player collides with the collider, teleport them to the new location
    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<AudioManager>().Play("Pipe");
        player.transform.position = teleportLocation.position;
    }
}
