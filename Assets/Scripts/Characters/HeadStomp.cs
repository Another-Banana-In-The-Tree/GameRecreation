using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadStomp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "PlayerFoot")
        {
            Destroy(gameObject.transform.root.gameObject);
        }
    }
}
