using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadStomp : MonoBehaviour
{

    private Rigidbody2D player;
    private Vector2 bounceForce = new Vector2(0, 15);
   [SerializeField ] private Enemy enemy;
    [SerializeField] Barrel barrel;

    private void Awake()
    {
       // enemy = transform.root.gameObject.GetComponent<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.tag == "PlayerFoot")
        {
            player = collision.gameObject.transform.root.gameObject.GetComponent<Rigidbody2D>();
            if (player.velocity.y < 0)
            {

                Debug.Log("foot");
                if (gameObject.tag == "WeakPoint")
                {
                    Debug.Log("weakpoint");


                    Debug.Log(enemy);
                    if (enemy != null)
                    {
                        Debug.Log("stomptriggered");
                        FindObjectOfType<AudioManager>().Play("Kill");
                        enemy.Die();
                    }
                }
                if (gameObject.tag == "Barrel")
                {
                    Debug.Log("BARREL");

                    //Barrel barrel = transform.root.gameObject.GetComponent<Barrel>();
                    if (barrel != null)
                    {
                        Debug.Log("barrel not null");
                        FindObjectOfType<AudioManager>().Play("Barrel");
                        barrel.Stomped();
                    }
                }


                player.AddForce(bounceForce, ForceMode2D.Impulse);
            }
        }
    }
}
