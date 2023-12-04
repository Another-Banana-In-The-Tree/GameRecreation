using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private static bool gameStarted;
    
   [SerializeField] private static int lives = 3;

    private void Awake()
    {
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
       
        Debug.Log(lives);
    }
    private void Start()
    {
        //InputManager.EnableGame();
        if (!gameStarted)
        {
            UiManager.instance.OpenStartmenu();
        }
        else
        {
            UiManager.instance.StartGame();
        }
    }

    public void LoseLife()
    {
        lives--;
        UiManager.instance.LivesText(lives);

        if(lives <= 0)
        {
            GameOver();
            
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AddLives()
    {
        lives++;
        UiManager.instance.LivesText(lives);
    }

    public int GetCurrentLives()
    {
        return lives;
    }

    private void GameOver()
    {
        lives = 3;
        gameStarted = false;
        InputManager.DisableGame();
    }
    public void GameWin()
    {
        UiManager.instance.WinGame();
        InputManager.DisableGame();
    }

    public void StartGame()
    {
        gameStarted = true;
        InputManager.EnableGame();
    }

    public void RestartGame()
    {
        gameStarted = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
}

