using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Hosting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreens : MonoBehaviour
{
    public string newGameScene;
    public string creditScene;

    public GameObject pauseMenu;
    public bool gamePaused = false;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void Update()
    {
        if (gamePaused == false && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            gamePaused = true;
        }

        else if (gamePaused == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            gamePaused = false;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(newGameScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Credits()
    {
        SceneManager.LoadScene(creditScene);
    }
}
