using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireFlower : MonoBehaviour, Collectible
{
    [SerializeField] private Player theMario;
    public void Collect()
    {
        theMario.PowerUpObtained(0);
        Destroy(this.gameObject);
    }

}
