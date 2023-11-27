using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadStomp : MonoBehaviour
{

    private Rigidbody2D player;
    private Vector2 bounceForce = new Vector2(0, 15);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "PlayerFoot")
        {
            if (gameObject.tag == "WeakPoint")
            {
                Enemy enemy = transform.root.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.Die();
                }
            }
            if(gameObject.tag == "Barrel")
            {

                Barrel  barrel = transform.root.gameObject.GetComponent<Barrel>();
                if (barrel != null)
                {
                    barrel.Stomped();
                }
            }
            player = collision.gameObject.transform.root.gameObject.GetComponent<Rigidbody2D>();

            player.AddForce(bounceForce, ForceMode2D.Impulse);
        }
    }
}
