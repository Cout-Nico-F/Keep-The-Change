using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool isPaused = false;
    [SerializeField] GameObject pauseMenuUI = null;
    [SerializeField] GameObject gameOverUI = null;
    [SerializeField] SceneFader sceneFader = null;
    [SerializeField] string menuScene = "MainMenu";

    void Start()
    {
        Transform T = ReferenceUI.Instance.MainCanvas.transform.Find("PauseMenu");
        pauseMenuUI = T.gameObject;
        gameOver = false;
    }

    void Update()
    {
        if (gameOver == false)
        {
            if (PlayerController.health <= 0 && !gameOver)
            {
                GameOver();   
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GameOver();
            }
        }
    }

  
    public void Pause()
    {
        //pauseMenuUI.SetActive(true);
        //Time.timeScale = 0f;
        //isPaused = true;
        if (gameOver)
        {
            return;
        }
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
        isPaused = !isPaused;

        if (pauseMenuUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void ReturnToMenu()
    {
        Pause();
        sceneFader.FadeTo(menuScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        Debug.Log("Test");
        Pause();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
}
