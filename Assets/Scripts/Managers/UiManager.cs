using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] private Text _text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //work in progress
        //_text.text = "Lives x" + lives.ToString();
    }
}
