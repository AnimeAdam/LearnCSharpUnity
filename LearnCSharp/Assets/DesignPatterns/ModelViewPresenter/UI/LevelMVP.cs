using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelMVP : MonoBehaviour
{

    [SerializeField] int pointsPerLevel = 200;
    [SerializeField] UnityEvent onLevelUp;
    int experiencePoints = 0;

    public event Action onLevelMVPUpAction;
    public event Action onExperienceChangeMVP;

    public void GainExperience(int points)
    {
        int level = GetLevel();
        experiencePoints += points;
        if (onExperienceChangeMVP != null)
        {
            onExperienceChangeMVP();
        }
        if (GetLevel() > level)
        {
            onLevelUp.Invoke();
            if (onLevelMVPUpAction != null)
            {
                onLevelMVPUpAction();
            }
        }
    }

    public int GetExperience()
    {
        return experiencePoints;
    }

    public int GetLevel()
    {
        return experiencePoints / pointsPerLevel;
    }
}