using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
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

    public void LoseLife()
    {
        lives--;
        UiManager.instance.LivesText(lives);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int GetCurrentLives()
    {
        return lives;
    }


}

