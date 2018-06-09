using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

    // Use this for initialization
    private void Start ()
    {
        MusicManager musicManager = GameObject.FindObjectOfType<MusicManager>();
        float initVolume = PlayerPrefsManager.GetMasterVolume();

        Debug.Log("Initialise music volume to " + initVolume);
        musicManager.ChangeVolume(initVolume);
    }
}
