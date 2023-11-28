using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collectible pickup = collision.GetComponent<Collectible>();

        if(pickup != null)
        {
            pickup.Collect();
        }
    }
}
