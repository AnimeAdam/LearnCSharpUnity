using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //Always start with a singelton instance
    bool gameOver = false;
    int score = 0;

    public GameObject gameOverPanel;

    public Text scoreText;
    public Text scoreTextPanel;

    private void Awake()
    {
        if (instance == null) //Absolutely nesscessary.
        {
            instance = this;
        }
    }

    //Shows GameOver once the player dies.
    public void GameOver()
    {
        gameOver = true;
        scoreTextPanel.text = "Score: " + score.ToString();

        GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().StopSpawning();
        gameOverPanel.SetActive(true);
    }

    //Increases score and checks if the game is over.
    public void IncrementScore()
    {
        if(!gameOver)
        {
            score++;
        }

        scoreText.text = score.ToString();
    }
        
    //Loads the scenes.
    public void MainMenu()
    {
        SceneManager.LoadScene("SaveTheBunnyMenu");
    }
    public void Restart()
    {
        SceneManager.LoadScene("SaveTheBunny");
    }
}
