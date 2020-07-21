using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool isPaused = false;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] SceneFader sceneFader;
    [SerializeField] string menuScene = "MainMenu";

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Resume();
            else Pause();
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
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);

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
}
