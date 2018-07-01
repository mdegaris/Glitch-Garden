using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] levelMusicChangeArray;
    public AudioClip levelComplete;

    private AudioSource musicAudio;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        
        this.musicAudio = GetComponent<AudioSource>();
        this.musicAudio.volume = PlayerPrefsManager.GetMasterVolume();
        SceneManager.sceneLoaded += this.LevelWasLoaded;
    }

    

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

    

    public void LevelCompleteJingle()
    {
        this.musicAudio.clip = this.levelComplete;
        this.musicAudio.loop = false;
        this.musicAudio.Play();
    }

    

    public void ChangeVolume(float newVolume)
    {
        this.musicAudio.volume = newVolume;
    }

}
