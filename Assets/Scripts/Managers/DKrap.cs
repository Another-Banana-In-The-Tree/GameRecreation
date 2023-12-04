using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DKrap : MonoBehaviour
{
    private Player player;
    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player.HasStarPower) FindObjectOfType<AudioManager>().Stop("StarSong");
            else FindObjectOfType<AudioManager>().Stop("Theme");
            FindObjectOfType<AudioManager>().Play("DKRap");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Stop("DKRap");
            if (player.HasStarPower) FindObjectOfType<AudioManager>().Play("StarSong");
            else FindObjectOfType<AudioManager>().Play("Theme");
        }
    }
}
