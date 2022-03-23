using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Wrapper class for PlayerPrefs that makes it easier to use.
public class PlayerPrefsManager : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    #region Volume
    public static void SetMasterVolume(float volume)
    {
        if (volume > 0f && volume < 1f)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        else
            Debug.LogError("Master Volume out of Range");
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }
    #endregion

    #region Level
    public static void UnlockLevel (int level)
    {
        if (level >= 0 && level <= Application.levelCount - 1)
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //0 false, 1 true
        else
            Debug.LogError("Trying to unlock level, it's out of range");
    }

    public static bool isLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level >= 0 && level <= Application.levelCount - 1)
            return isLevelUnlocked;
        else
        {
            Debug.LogError("Trying to unlock level, it's out of range");
            return false;
        }
    }
    #endregion

    #region Difficulty
    public static void SetDifficulty(float difficulty)
    {
        if (difficulty > 0f && difficulty < 1f)
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        else
            Debug.LogError("Difficulty is out of Range");
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
    #endregion
}
