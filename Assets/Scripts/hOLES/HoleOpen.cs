using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleOpen : MonoBehaviour
{

    public GameObject holeEnter;
    public Collider2D holeEnterColider;

    // Start is called before the first frame update
    void Start()
    {
        Deactivate();
        holeEnterColider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Deactivate()
    {
        holeEnter.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.transform.tag.Contains("Fireball")) 
        {
            FindObjectOfType<AudioManager>().Play("Shhhh... Secret");
            holeEnterColider.isTrigger = true;
            holeEnter.SetActive(true);
        }
    }
}
