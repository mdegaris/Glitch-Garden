using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        print ("Volume: " + PlayerPrefsManager.GetMasterVolume());

        print("Difficulty: " + PlayerPrefsManager.GetDifficulty());

        /*
        print(PlayerPrefsManager.IsLevelUnlocked(10));
        PlayerPrefsManager.UnlockLevel(10);
        print(PlayerPrefsManager.IsLevelUnlocked(10));
        */
    }

    // Update is called once per frame
    void Update()
    {

    }
}
