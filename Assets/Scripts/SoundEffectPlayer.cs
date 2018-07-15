using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
