using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
{    
    private Attacker attacker;

    // Use this for initialization
    private void Start()
    {
        this.attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidingGameObj = collision.gameObject;
        if (Defender.IsObjectDefender(collidingGameObj))
        {
            Debug.Log("Lizard attacks the " + collision);
            this.attacker.Attack(collidingGameObj);
        }
    }
}
