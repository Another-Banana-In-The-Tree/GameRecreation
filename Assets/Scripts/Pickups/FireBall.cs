using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private Rigidbody2D ourSelf;

    private void Awake()
    {
        ourSelf = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
            Vector2 upwards = new Vector2(0, 1);
            ourSelf.AddForce(upwards * 5, ForceMode2D.Impulse);

            if (other.gameObject.tag == "Enemy")
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
    }
}
