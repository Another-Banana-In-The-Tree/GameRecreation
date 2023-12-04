using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPower : MonoBehaviour, Collectible
{
    [SerializeField] private Player myMario;
    private void Awake()
    {
        myMario = GameObject.FindObjectOfType<Player>();
    }
    public void Collect()
    {
        myMario.PowerUpObtained(1);
        Destroy(this.gameObject);
    }
    
}
