﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {        
        Text scoreText = GetComponent<Text>();

        ScoreKeeper scoreKeeper = ScoreKeeper.GetInstance();
        scoreText.text = scoreKeeper.GetCurrentScore().ToString();
        scoreKeeper.Reset();
    }

}
