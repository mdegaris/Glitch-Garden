using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private static Color UNSELECTED_COLOR = Color.black;
    private static Color SELECTED_COLOR = Color.white;
    private static Button[] buttonArray;
    private static GameObject selectedDefender;
    
    private bool selected;    
    public GameObject defenderPrefab;


    public static GameObject GetSelectedDefender()
    {
        GameObject selectedDefender = null;
        foreach (Button thisButton in GameObject.FindObjectsOfType<Button>())
        {            
            if (thisButton.selected)
            {                
                selectedDefender = thisButton.defenderPrefab;
                print(thisButton + " " + thisButton.selected);
            }
        }

        return selectedDefender;
    }


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
        this.selected = true;
    }

    private void UnselectAllButtons()
    {
        foreach (Button thisButton in Button.buttonArray)
        {
            SpriteRenderer buttonSpr = thisButton.GetComponent<SpriteRenderer>();
            buttonSpr.color = Button.UNSELECTED_COLOR;
            this.selected = false;
        }
    }
}
