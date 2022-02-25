using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BB_SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(5);
        if (FindObjectOfType<GameState>())
            FindObjectOfType<GameState>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
