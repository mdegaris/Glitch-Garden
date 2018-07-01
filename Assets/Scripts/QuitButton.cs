using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{

    // ===================================================================
    // Variables
    // ===================================================================

    private LevelManager levelManager;


    // ===================================================================
    // Methods
    // ===================================================================

    private void Start()
    {
        this.levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void OnMouseDown()
    { 
    
        this.levelManager.QuitCurrentGame();
    }
}
