using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
    public GameObject levelCompleteMessage;
    public GameObject gameOverMessage;

    private Text levelCompleteText;
    private Text gameOverText;


    public void DisplayLevelComplete()
    {
        this.levelCompleteText.enabled = true;
    }

    public void DisplayGameOver()
    {
        this.gameOverText.enabled = true;
    }


    private void Start()
    {
        this.levelCompleteText = this.levelCompleteMessage.GetComponent<Text>();
        this.gameOverText = this.gameOverMessage.GetComponent<Text>();
    }


    /* May not be needed
    private void Start()
    {
        Text[] messages = this.gameObject.GetComponentsInChildren<Text>();

        foreach (Text message in messages)
        {
            if (message.name == "Level Complete")
            {
                this.levelComplete = message;
            }
            else if (message.name == "Game Over")
            {
                this.gameOver = message;
            }
        }
    }
    */

}
