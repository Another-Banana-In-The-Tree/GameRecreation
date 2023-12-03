using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    [SerializeField] private Text _text;
    [SerializeField] private Text _nanaText;

    private void Start()
    {
        _text.text = "Lives x " + GameManager.instance.GetCurrentLives().ToString();

        _nanaText.text = "Score x 0";
    }

    private void Awake()
    {
        
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }


        


    }


    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    public void LivesText(int lives)
    {
        _text.text = "Lives x " + lives.ToString();
    }

    public void NanasText(int score)
    {
        _nanaText.text = "Score x " + score.ToString();

    }


}
