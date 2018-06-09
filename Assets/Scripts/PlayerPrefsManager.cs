using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty_key";
    const string LEVEL_UNLOCKED = "level_unlocked_";

    /******************************************************************/

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range: " + volume);
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    /*********************************************************************/

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1 && difficulty <= 3)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty out of range: " + difficulty);
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    /*********************************************************************/

    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt(LEVEL_UNLOCKED + level.ToString(), 1);
        }
        else
        {
            Debug.LogError("Attempting to unlock level not in build order: " + level);
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_UNLOCKED + level.ToString());
        bool levelUnlocked = (levelValue == 1);

        if (level <= (SceneManager.sceneCountInBuildSettings - 1))
        {
            return levelUnlocked;
        }
        else
        {
            Debug.LogError("Attempting to unlock level not in build order: " + level);
            return false;
        }
    }

    /*********************************************************************/

}
