using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour, Collectible
{
    // Start is called before the first frame update
    
    
    public void Collect()
    {
        ScoreManager.instance.AddScore();
        Debug.Log("boing!");
        Destroy(gameObject);
        
    }
}
