using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreens : MonoBehaviour
{
    public string newGameScene;
    public string creditScene;

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
