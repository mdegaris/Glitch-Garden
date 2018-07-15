using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    // ===================================================================
    // Variables
    // ===================================================================

    [Tooltip("How long (in seconds) the player needs to keep the garden safe.")]
    public float levelTime;

    private Slider slider;
    private Text completeText;
    private bool isEndOfLevel;
    private LevelManager levelManager;
    private SoundManager musicManager;
    private MessageController messageController;


    // ===================================================================
    // Methods
    // ===================================================================

    // Use this for initialization
    private void Start()
    {
        // Initialise required objects
        this.levelManager = GameObject.FindObjectOfType<LevelManager>();
        this.musicManager = GameObject.FindObjectOfType<SoundManager>();
        this.messageController = GameObject.FindObjectOfType<MessageController>();
        this.slider = this.gameObject.GetComponent<Slider>();

        // Initialise slider.
        // Slider's value tracks the number of elapsed level seconds.
        this.slider.maxValue = this.levelTime;
        this.slider.minValue = 0;
        this.slider.value = 0;

        // Track if we've reached the end of the level 
        // (prevents repeated executiuon of level completion code)
        this.isEndOfLevel = false;
    }    

    // Update the state of the slider
    private void Update()
    {
        // Increment the slider each frame.
        this.slider.value += Time.deltaTime;

        // Check if the time is up and its the end of the level.
        bool isTimeUp = (this.slider.value >= this.levelTime);
        if (isTimeUp && !isEndOfLevel)
        {
            Debug.Log("The level has been completed.");
            this.isEndOfLevel = true;
            this.CompletedLevel();
        }        
    }    

    // Perform all the level completion actions.
    private void CompletedLevel()
    {
        // Display the level complete text
        this.messageController.DisplayLevelComplete();

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
}
