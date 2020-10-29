using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    public string mainMenu;

    public void GoBack()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
