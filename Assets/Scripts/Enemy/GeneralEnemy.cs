using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Init();
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    
}
