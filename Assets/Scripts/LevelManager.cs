using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float autoLoadNextLevelAfter;

    /*********************************************************************/

    private void Start()
    {
        if (autoLoadNextLevelAfter > 0)
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
        else
        {
            Debug.Log("Level auto load disabled, use a positive number in seconds");
        }
    }

    /*********************************************************************/

    public void LoadLevel(string name)
    {
        Debug.Log("Level load request for " + name);
        SceneManager.LoadScene(name);
    }

    /*********************************************************************/

    public void QuitRequest()
    {
        Debug.Log("I want to quit!");
        Application.Quit();
    }

    /*********************************************************************/

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}