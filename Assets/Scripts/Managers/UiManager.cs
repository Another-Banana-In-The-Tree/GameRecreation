using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    [SerializeField] private Text _text;
    [SerializeField] private Text _nanaText;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject winMenu;
    private void Start()
    {
        _text.text = "Lives x " + GameManager.instance.GetCurrentLives().ToString();

        _nanaText.text = "Score x 0";
        winMenu.SetActive(false);
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

    public void StartGame()
    {
       startMenu.SetActive(false);
    GameManager.instance.StartGame();
    }


    public void OpenStartmenu()
    {
        startMenu.SetActive(true);
    }

     public void WinGame()
    {
        winMenu.SetActive(true);
    }

    public void Restart()
    {
        GameManager.instance.RestartGame();
    }
    
}
