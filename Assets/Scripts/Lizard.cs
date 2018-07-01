using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
{

    // ===================================================================
    // Variables
    // ===================================================================
    private Attacker attacker;


    // ===================================================================
    // Methods
    // ===================================================================

    // Use this for initialization
    private void Start()
    {
        this.attacker = GetComponent<Attacker>();
    }

    // Attack a colliding Defender.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidingGameObj = collision.gameObject;
        if (Defender.IsObjectDefender(collidingGameObj))
        {            
            this.attacker.Attack(collidingGameObj);
            Debug.Log("Lizard attacks the " + collision);
        }
    }
}
