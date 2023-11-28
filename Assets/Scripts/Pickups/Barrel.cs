using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]private GameObject heldItem;
    private Vector3 spawn;
    void Start()
    {
        spawn = transform.position;
    }

    public void Stomped()
    {
        print("kaboom");
        
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Instantiate(heldItem, spawn, transform.rotation);
    }
}
