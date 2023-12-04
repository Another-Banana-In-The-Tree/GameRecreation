using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour, Collectible 
{
    Player player;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    public void Collect()
    {
        player._rb.velocity = new Vector2(0, 0);
        if (player.HasStarPower) FindObjectOfType<AudioManager>().Stop("StarSong");
        else FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Play("GameWin");
        GameManager.instance.GameWin();
    }
}
