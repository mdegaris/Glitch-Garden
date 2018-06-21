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

    public enum Status{SUCCESS, FAILURE};

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

    public Status UseStars(int amount)
    {
        // If we have enough stars then remove cost and return SUCCESS
        if (amount <= this.currentStars)
        {
            this.currentStars -= amount;
            this.UpdateDisplay();
            return Status.SUCCESS;
        }
        else
        {
            return Status.FAILURE;
        }
    }
}
