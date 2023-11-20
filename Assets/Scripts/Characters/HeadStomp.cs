using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadStomp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerFoot")
        {
            print("touched");

            Destroy(gameObject.transform.root.gameObject);
        }
    }
}
