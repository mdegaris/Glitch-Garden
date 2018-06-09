using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] levelMusicChangeArray;

    private AudioSource musicAudio;

    /*********************************************************************/

    private void Awake()
    {
        Debug.Log("MusicManager.Awake");

        DontDestroyOnLoad(gameObject);
        this.musicAudio = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += this.LevelWasLoaded;
    }

    /*********************************************************************/

    private void LevelWasLoaded(Scene scene, LoadSceneMode mode)
    {        
        int level = scene.buildIndex;
        AudioClip thisLevelMusic = this.levelMusicChangeArray[level];        

        if (thisLevelMusic)
        {
            Debug.Log("Playing clip: " + thisLevelMusic);
            this.musicAudio.clip = thisLevelMusic;

            if (!this.musicAudio.isPlaying)
            {
                this.musicAudio.loop = true;
                this.musicAudio.Play();
            }
        }
    }

    /*********************************************************************/

    public void ChangeVolume(float newVolume)
    {
        this.musicAudio.volume = newVolume;
    }

}
