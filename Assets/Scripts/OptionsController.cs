using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;

    public float defaultVolume;
    public float defaultDifficulty;

    private MusicManager musicManager;

    /*********************************************************************/

    // Use this for initialization
    private void Start()
    {
        // Set volume and diffulty sliders to current values
        this.musicManager = GameObject.FindObjectOfType<MusicManager>();
        this.volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        this.difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }

    /*********************************************************************/

    // Update is called once per frame
    private void Update()
    {
        if (this.musicManager)
        {
            this.musicManager.ChangeVolume(this.volumeSlider.value);
        }
        else
        {
            Debug.LogError("Unable to find a MusicManager");
        }        
    }

    /*********************************************************************/

    public void SaveAndExit()
    {
        // Save the volume value
        PlayerPrefsManager.SetMasterVolume(this.volumeSlider.value);
        // Save the difficulty value
        PlayerPrefsManager.SetDifficulty(this.difficultySlider.value);

        levelManager.LoadLevel("01a Start SCreen");
    }

    /*********************************************************************/

    public void SetDefaults()
    {
        this.volumeSlider.value = this.defaultVolume;
        this.difficultySlider.value = this.defaultDifficulty;
    }
}
