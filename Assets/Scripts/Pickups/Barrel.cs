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
        Instantiate(heldItem, spawn, transform.rotation);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        
    }
}
