using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour, Collectible 
{
    public void Collect()
    {
        GameManager.instance.GameWin();


    }
}
