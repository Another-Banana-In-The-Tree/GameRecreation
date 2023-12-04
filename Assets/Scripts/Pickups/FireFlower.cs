using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireFlower : MonoBehaviour, Collectible
{
    private Player theMario;

    private void Awake()
    {
        //FindObjectOfType<AudioManager>().Play("Fireball");
        theMario = GameObject.FindObjectOfType<Player>();   
    }

    public void Collect()
    {
        if (theMario != null)
        {
            theMario.PowerUpObtained(0);
            Destroy(this.gameObject);
        }
    }

}
