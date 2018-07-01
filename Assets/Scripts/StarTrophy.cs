using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTrophy : MonoBehaviour
{
    [Tooltip("The amount stars this defender awards to the players.")]
    public int starAward;

    private StarDisplay starDisplay;


    // Add a number of stars to the star display.
    public void AddStars()
    {
        this.starDisplay.AddStars(this.starAward);
    }

    private void Start()
    {
        this.starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }
}
