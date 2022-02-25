using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    const string scoreTextStart = "Score: ";
    //Config Parameters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    //State Variables
    [SerializeField] int currentScore = 0;

    private void Start()
    {
        AddScoreToScoreBoard();
    }


    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        AddScoreToScoreBoard();
    }

    private void AddScoreToScoreBoard()
    {
        scoreText.text = scoreTextStart + currentScore.ToString();
    }
}
