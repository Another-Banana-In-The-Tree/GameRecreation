using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleOpenExit : MonoBehaviour
{
    public GameObject holeExit;
    // Start is called before the first frame update
    void Start()
    {
        holeExit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
     
            holeExit.SetActive(true);
       
    }
}
