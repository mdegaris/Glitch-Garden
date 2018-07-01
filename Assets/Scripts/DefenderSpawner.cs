using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefenderSpawner : MonoBehaviour
{

    // ===================================================================
    // Variables
    // ===================================================================

    // Statics

    private static string DEFENDERS = "Defenders";

    // Instances

    private GameObject defenderParent;
    private Camera mainCamera;
    private StarDisplay starDisplay;


    // ===================================================================
    // Methods
    // ===================================================================

    // Use this for initialization
    private void Start()
    {
        this.mainCamera = Camera.main;
        this.starDisplay = GameObject.FindObjectOfType<StarDisplay>();

        // Create the Defenders GameObject parent container if required
        this.defenderParent = GameObject.Find(DefenderSpawner.DEFENDERS);
        if (!this.defenderParent)
        {
            this.defenderParent = new GameObject(DefenderSpawner.DEFENDERS);
        }        
    }
   
    // Attempt to spawn a defender instance where the player has specified.
    private void OnMouseDown()
    {
        // Ascertain the snapped grid position.
        Vector2 rawPosition = this.CalculateWorldPointOfMouseClick();
        Vector2 snappedPosition = this.SnapToGrid(rawPosition);

        // Attempt to spawn a new defender.
        GameObject selectedDefender = DefenderButton.GetSelectedDefender();
        if (selectedDefender && Defender.IsObjectDefender(selectedDefender))
        {
            // Attempt to spend the stars and spawn the defender instance on success.
            int starCost = this.GetDefenderCost(selectedDefender);
            if (this.starDisplay.UseStars(starCost) == StarDisplay.Status.SUCCESS)
            {
                SpawnDefender(snappedPosition, selectedDefender);
            }
            else
            {
                Debug.Log("Can't afford to buy a " + selectedDefender + ". Insufficient funds.");
            }
        }
    }
    
    // Gets the star cost of the a given object.
    private int GetDefenderCost(GameObject selectedDefender)
    {
        // Get the star cost of the defender type
        Defender selectedDefenderObj = selectedDefender.GetComponent<Defender>();
        int starCost = selectedDefenderObj.GetStarCost();
        return starCost;
    }

    // Spawn a defender at the given position.
    private void SpawnDefender(Vector2 snappedPosition, GameObject selectedDefender)
    {
        Quaternion zeroRotation = Quaternion.identity;
        Transform parentTransform = this.defenderParent.transform;
        Instantiate(selectedDefender, snappedPosition, zeroRotation, parentTransform);
    }

    // Calculate the snapped grid position for a given absolute position.
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        Vector2 snappedWorldPos;
        float mouseRawX, mouseRawY, mouseSnapX, mouseSnapY;       

        mouseRawX = rawWorldPos.x;
        mouseRawY = rawWorldPos.y;

        // Round to snap values
        mouseSnapX = Mathf.RoundToInt(mouseRawX);
        mouseSnapY = Mathf.RoundToInt(mouseRawY);
        snappedWorldPos = new Vector2(mouseSnapX, mouseSnapY);

        return snappedWorldPos;
    }    

    // Returns the current position of a mouse click.
    private Vector2 CalculateWorldPointOfMouseClick()
    {
        Vector2 worldPointV2;

        // Get the world point and convert to a Vector2
        Vector3 worldPointV3 = this.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPointV2 = new Vector2(worldPointV3.x, worldPointV3.y);

        return worldPointV2;
    }
}