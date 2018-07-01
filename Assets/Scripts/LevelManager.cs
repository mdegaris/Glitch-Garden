using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    // ===================================================================
    // Variables
    // ===================================================================

    [Tooltip("Controls how long (in seconds) the next level will be loaded automtically (on class load).")]
    public float autoLoadNextLevelAfter;


    // ===================================================================
    // Methods
    // ===================================================================

    // Use this for initialization
    private void Start()
    {
        // Automatically load the next level if a timer has been specified.
        if (autoLoadNextLevelAfter > 0)
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
        else
        {
            Debug.Log("Level auto load disabled, use a positive number in seconds");
        }
    }

    // Load a given scene.
    public void LoadLevel(string name)
    {
        Debug.Log("Level load request for " + name);
        SceneManager.LoadScene(name);
    }

    // Quit the game.
    public void QuitCurrentGame()
    {
        Debug.Log("Quit this game!");
        this.LoadLevel("01a Start Screen");
    }

    // Quit the game.
    public void QuitRequest()
    {
        Debug.Log("I want to quit!");
        Application.Quit();
    }

    // Load the next level (scene) in the build list.
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}