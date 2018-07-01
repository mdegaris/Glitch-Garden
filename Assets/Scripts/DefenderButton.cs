using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{

    // ===================================================================
    // Variables
    // ===================================================================

    // Statics

    private static Color UNSELECTED_COLOR = Color.black;
    private static Color SELECTED_COLOR = Color.white;
    // Store the list of defender buttons
    private static DefenderButton[] buttonArray;
    // Currently selected defender prefab
    private static GameObject selectedDefender;

    // Instances

    public GameObject defenderPrefab;

    private Text costText;


    // ===================================================================
    // Methods
    // ===================================================================

    // Statics

    public static GameObject GetSelectedDefender()
    {
        return DefenderButton.selectedDefender;        
    }


    // Instances

    // Use this for initialization
    private void Start()
    {
        // Initialise the list of defender buttons if required
        if ((DefenderButton.buttonArray == null) || (DefenderButton.buttonArray.Length == 0))
        {
            DefenderButton.buttonArray = GameObject.FindObjectsOfType<DefenderButton>();
            Debug.Log("Inititialised button array.");
        }

        this.costText = this.gameObject.GetComponentInChildren<Text>();
        if (!this.costText) { Debug.LogWarning(this.name + " has no cost text."); }

        this.SetStarCostDisplay();
        
    }

    // Display the star cost next to the defender button.
    private void SetStarCostDisplay()
    {
        Defender defenderObj = this.defenderPrefab.GetComponent<Defender>();
        if (defenderObj)
        {
            this.costText.text = defenderObj.GetStarCost().ToString();
        }
    }

    // Handle selection of defender button
    private void OnMouseDown()
    {
        this.UnselectAllButtons();
        this.gameObject.GetComponent<SpriteRenderer>().color = DefenderButton.SELECTED_COLOR;
        DefenderButton.selectedDefender = this.defenderPrefab;
    }

    // Ensure all defender buttons are unselected
    private void UnselectAllButtons()
    {
        foreach (DefenderButton thisButton in DefenderButton.buttonArray)
        {
            SpriteRenderer buttonSpr = thisButton.GetComponent<SpriteRenderer>();
            buttonSpr.color = DefenderButton.UNSELECTED_COLOR;
        }
    }

    // Ensure we reset the button list as we want to initialise this
    // every time the Button class loaded (i.e. a fresh scene)
    private void OnDestroy()
    {   
        DefenderButton.buttonArray = null;
    }
}
