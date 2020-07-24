using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool isPaused = false;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] SceneFader sceneFader;
    [SerializeField] string menuScene = "MainMenu";

    void Start()
    {
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
                if (isPaused) Resume();
                else Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
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
        //Debug.Log("WTF");
        Pause();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
}
