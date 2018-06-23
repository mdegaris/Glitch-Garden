using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    private StarDisplay starDisplay;
    public int starCost;


    public static bool IsObjectDefender(GameObject obj)
    {
        return ((obj.GetComponent<Defender>()) ? true : false);
    }


    private void Start()
    {
        this.starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    public void AddStars(int amount)
    {
        this.starDisplay.AddStars(amount);
    }

}
