using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager levelManager;
    private SoundManager musicManager;
    private MessageController messageController;

    // Use this for initialization
    private void Start()
    {
        this.levelManager = GameObject.FindObjectOfType<LevelManager>();
        this.messageController = GameObject.FindObjectOfType<MessageController>();
        this.musicManager = GameObject.FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidingObj = collision.gameObject;

        if (Attacker.IsObjectAttacker(collidingObj))
        {
            this.GameOver();
        }                
    }

    private void GameOver()
    {
        this.messageController.DisplayGameOver();

        // Slow down time and play jingle.
        Time.timeScale = 0.1f;
        this.PlayJingle();

        // Load the next level after a delay
        StartCoroutine(this.NextLevel(4.0f));
    }


    // Play the level completion jingle.
    private void PlayJingle()
    {
        if (this.musicManager)
        {
            this.musicManager.GameOverJingle();
        }
        else
        {
            Debug.LogWarning("MusicManager not found.");
        }
    }


    private IEnumerator NextLevel(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1.0f;
        this.levelManager.LoadLevel("03b Lose");
    }

    /*

    // Perform all the level completion actions.
    private void CompletedLevel()
    {
        // Display the level complete text
        this.messageController.displayLevelComplete();

        // Slow down time and play jingle.
        Time.timeScale = 0.1f;
        this.PlayJingle();

        // Load the next level after a delay
        StartCoroutine(this.NextLevel(4.0f));
    }

    // Play the level completion jingle.
    private void PlayJingle()
    {
        if (this.musicManager)
        {
            this.musicManager.LevelCompleteJingle();
        }
        else
        {
            Debug.LogWarning("MusicManager not found.");
        }
    }

    // Load the next level after a given delay (in seconds).
    private IEnumerator NextLevel(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1.0f;
        this.levelManager.LoadLevel("03a Win");
    }
    */
}
