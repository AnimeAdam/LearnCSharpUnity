using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("BlockBreakerGameOver"); //Be careful of using string, incase you change the Scene name.
        if (FindObjectOfType<GameState>())
            FindObjectOfType<GameState>().ResetGame();
    }
}
