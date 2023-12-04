using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private Rigidbody2D ourSelf;
    private Animator animator;
    private bool bounceBool = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        ourSelf = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        bounceBool = !bounceBool;
        animator.SetBool("bounceBool", bounceBool);
        Vector2 upwards = new Vector2(0, 1);
        ourSelf.AddForce(upwards * 5, ForceMode2D.Impulse);

        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        bounceBool = !bounceBool;
        animator.SetBool("bounceBool", bounceBool);
        Vector2 upwards = new Vector2(0, 1);
        ourSelf.AddForce(upwards * 5, ForceMode2D.Impulse);

        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
