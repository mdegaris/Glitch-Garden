using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefenderSpawner : MonoBehaviour
{
    private static string DEFENDERS = "Defenders";

    private GameObject defenderParent;
    private Camera mainCamera;
    private StarDisplay starDisplay;

    // Use this for initialization
    void Start()
    {
        this.mainCamera = Camera.main;

        this.defenderParent = GameObject.Find(DefenderSpawner.DEFENDERS);
        if (!this.defenderParent)
        {
            this.defenderParent = new GameObject(DefenderSpawner.DEFENDERS);
        }

        this.starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Vector2 rawPosition = this.CalculateWorldPointOfMouseClick();
        Vector2 snappedPosition = this.SnapToGrid(rawPosition);

        GameObject selectedDefender = Button.GetSelectedDefender();

        if (selectedDefender)
        {
            Defender selectedDefenderObj = selectedDefender.GetComponent<Defender>();
            int starCost = selectedDefenderObj.starCost;

            if ((this.starDisplay.GetCurrentStars() - starCost) >= 0)
            { 
                Transform parentTransform = this.defenderParent.transform;
                GameObject newDefender = Instantiate(selectedDefender, snappedPosition, Quaternion.identity, parentTransform);
            }
            else
            {
                Debug.Log("Can't afford to buy a " + selectedDefender);
            }

        }
    }

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

    private Vector2 CalculateWorldPointOfMouseClick()
    {
        Vector2 worldPointV2;

        // Get the world point and convert to a Vector2
        Vector3 worldPointV3 = this.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPointV2 = new Vector2(worldPointV3.x, worldPointV3.y);

        return worldPointV2;
    }
}