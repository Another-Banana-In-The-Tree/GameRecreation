using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCroc : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance (gameObject.transform.position, player.transform.position) < 10)
        {
            Debug.Log("playerClose");
        }
        Movement();
    }
}
