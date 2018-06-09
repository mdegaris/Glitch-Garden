using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private static ScoreKeeper _instance;

    private int currentScore;
    private Text scoreText;


    public static ScoreKeeper GetInstance()
    {
        return _instance;
    }


    // Use this for initialization
    private void Start()
    {
        ScoreKeeper sk = ScoreKeeper.GetInstance();
        sk.scoreText = GetComponent<Text>();
        Reset();
        UpdateScoreText();
    }

    private void Awake()
    {
        if (ScoreKeeper._instance != null && ScoreKeeper._instance != this)
        {
            print ("ScoreKeeper Destroy(this)");
            Destroy(this);
        }
        else
        {
            print ("ScoreKeeper._instance = this");
            ScoreKeeper._instance = this;
            // DontDestroyOnLoad(this);
        }
    }

    public void Reset()
    {
        ScoreKeeper sk = ScoreKeeper.GetInstance();
        sk.currentScore = 0;
    }

    public void UpdateScoreText()
    {
        ScoreKeeper sk = ScoreKeeper.GetInstance();
        sk.scoreText.text = currentScore.ToString();
    }

    public void Score(int points)
    {
        ScoreKeeper sk = ScoreKeeper.GetInstance();
        sk.currentScore += points;
        UpdateScoreText();
    }

    public int GetCurrentScore()
    {
        ScoreKeeper sk = ScoreKeeper.GetInstance();
        return sk.currentScore;
    }
}
