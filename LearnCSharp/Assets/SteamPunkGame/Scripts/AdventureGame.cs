using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text TextComponent;
    [SerializeField] State staringState;


    State currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = staringState;

        TextComponent.text = currentState.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = currentState.GetNextState();
        for (int index = 0; index < nextStates.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                currentState = nextStates[index];
            }
        }

        TextComponent.text = currentState.GetStateStory();
    }
}
