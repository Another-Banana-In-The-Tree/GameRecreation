using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : MonoBehaviour
{
    private GameObject lastTouched = null;
    private Rigidbody2D _rb;
    private Collider2D col;
    public float waitTime;
    
    private int coconutNum;
    private Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        col = gameObject.GetComponent<Collider2D>();
        
    }
    private void Update()
    {
        if(transform.position.y < -15)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector2 direction, int cocoNum )
    {
        dir = direction;
        coconutNum = cocoNum;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision");
        if(collision.gameObject.tag == "Ground")
        {
           // Debug.Log("Touched Ground");
            if(collision.gameObject != lastTouched)
            {
               // Debug.Log("Bounced");
                StartCoroutine("TempPassThrough");
                lastTouched = collision.gameObject;
                
                _rb.AddForce(dir + Vector2.up * 2, ForceMode2D.Impulse);
            }
        }
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("HitPlayer");
        }
    }

    public IEnumerator TempPassThrough()
    {
       // Debug.Log("off");
        col.isTrigger = true;
        if (coconutNum != 1)
        {
            yield return new WaitForSeconds(waitTime);
        }
        else
        {
            yield return new WaitForSeconds(waitTime + 0.2f);
        }
       // Debug.Log("On");
        col.isTrigger = false;
    }
}
