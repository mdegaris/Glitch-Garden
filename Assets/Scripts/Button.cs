using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    // ===================================================================
    // Class variables
    // ===================================================================

    // Statics

    private static Color UNSELECTED_COLOR = Color.black;
    private static Color SELECTED_COLOR = Color.white;
    private static Button[] buttonArray;
    private static GameObject selectedDefender;

    // Instances
    private bool selected;    
    public GameObject defenderPrefab;



    // ===================================================================
    // Class methods
    // ===================================================================

    // Statics
    public static GameObject GetSelectedDefender()
    {
        return Button.selectedDefender;
    }


    // Instances

    // Use this for initialization
    private void Start()
    {
        if ((Button.buttonArray == null) || (Button.buttonArray.Length == 0))
        {
            Button.buttonArray = GameObject.FindObjectsOfType<Button>();
        }
    }

    private void OnMouseDown()
    {
        this.UnselectAllButtons();
        this.gameObject.GetComponent<SpriteRenderer>().color = Button.SELECTED_COLOR;
        Button.selectedDefender = this.defenderPrefab;
    }

    private void UnselectAllButtons()
    {
        foreach (Button thisButton in Button.buttonArray)
        {
            SpriteRenderer buttonSpr = thisButton.GetComponent<SpriteRenderer>();
            buttonSpr.color = Button.UNSELECTED_COLOR;
            thisButton.selected = false;
        }
    }
}
