using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] levelMusicArray;
    public AudioClip levelComplete;
    public AudioClip gameOver;

    private AudioSource musicAudio;

    // Ensure the MusicManager isn't destroyed upon loading a new scene.
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Init required objects.
    private void Start()
    {        
        this.musicAudio = GetComponent<AudioSource>();
        this.musicAudio.volume = PlayerPrefsManager.GetMasterVolume();
        // Apend additional scene loaded function.
        SceneManager.sceneLoaded += this.LevelWasLoaded;
    }

    // Start playing music for this loaded scene.
    private void LevelWasLoaded(Scene scene, LoadSceneMode mode)
    {        
        // Get any music for this scnene, by using an array lookup via its build index.
        int level = scene.buildIndex;
        AudioClip thisLevelMusic = this.levelMusicArray[level];

        // If we have some music, then play it.
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

    // Jingle played upon level completed.
    public void LevelCompleteJingle()
    {
        this.musicAudio.clip = this.levelComplete;
        this.musicAudio.loop = false;
        this.musicAudio.Play();
    }

    // Jingle played upon level completed.
    public void GameOverJingle()
    {
        this.musicAudio.clip = this.gameOver;
        this.musicAudio.loop = false;
        this.musicAudio.Play();
    }

    // Changes the volume of all music.
    public void ChangeVolume(float newVolume)
    {
        this.musicAudio.volume = newVolume;
    }
}
