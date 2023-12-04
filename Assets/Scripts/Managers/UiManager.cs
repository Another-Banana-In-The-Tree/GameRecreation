using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    [SerializeField] private Text _text;
    [SerializeField] private Text _nanaText;
    [SerializeField] private Text _controls;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private Player player;
    private void Start()
    {
        _text.text =  GameManager.instance.GetCurrentLives().ToString();
        _controls.gameObject.SetActive(false);
        _nanaText.text = "X 0";
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
        if (player.HasFireFlower)
        {
            Debug.Log("Showing Controls...");
            _controls.gameObject.SetActive(true);
        }
    }

    public void LivesText(int lives)
    {
        _text.text = lives.ToString();
    }

    public void NanasText(int score)
    {
        _nanaText.text = $"X " + score.ToString();

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
