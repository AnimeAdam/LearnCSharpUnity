using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LD_Level : MonoBehaviour
{
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(9);
    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene(10);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(11);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
