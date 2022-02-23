using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; //Serialzed for debugging purposes

    //Cache referenece
    [SerializeField] BB_SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<BB_SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }
    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
