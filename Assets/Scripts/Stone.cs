using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{

    // ===================================================================
    // Variables
    // ===================================================================

    // Statics

    private static string UNDER_ATTACK_TRIGGER_NAME = "underAttackTrigger";

    // Instances

    private Animator animator;


    // ===================================================================
    // Methods
    // ===================================================================

    // Use this for initialization
    private void Start()
    {
        this.animator = this.gameObject.GetComponent<Animator>();
    }

    // Continusouly trigger the under attack animation 
    // when the Gravestone is under attack from an Attack.
    private void OnTriggerStay2D(Collider2D collision)
    {
        Attacker attackerObj = collision.GetComponent<Attacker>();
        if (attackerObj && attackerObj.IsAttacking())
        {
            this.animator.SetTrigger(UNDER_ATTACK_TRIGGER_NAME);
        }
    }

}
