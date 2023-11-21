using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadStomp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "PlayerFoot")
        {
           Enemy enemy = transform.root.gameObject.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.Die();
            }
        }
    }
}
