using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    // ===================================================================
    // Methods
    // ===================================================================

    // Destroy all colliding objects.
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        Destroy(collision.gameObject);
        Debug.Log("Destroyed " + collision.name + " in the shredder (" + this.name + ").");
    }
}
