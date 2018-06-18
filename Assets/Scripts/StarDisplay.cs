using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour
{
    private int currentStars;
    private Text starsText;

    public int startingStars;

    // Use this for initialization
    private void Start()
    {
        this.currentStars = this.startingStars;
        this.starsText = this.GetComponent<Text>();

        this.UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        this.starsText.text = this.currentStars.ToString();
    }

    public void AddStars(int amount)
    {
        this.currentStars += amount;
        this.UpdateDisplay();
    }

    public void UseStars(int amount)
    {
        int newStarsTotal = (this.currentStars - amount);
        if (newStarsTotal < 0)
        {
            this.currentStars = 0;
        }
        else
        {
            this.currentStars = newStarsTotal;
        }

        this.UpdateDisplay();
    }

    public int GetCurrentStars()
    {
        return this.currentStars;
    }
}
