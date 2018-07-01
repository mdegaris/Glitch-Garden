using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour
{

    // ===================================================================
    // Variables
    // ===================================================================

    private static string JUMP_TRIGGER_NAME = "jumpTrigger";

    private Attacker attacker;


    // ===================================================================
    // Methods
    // ===================================================================

    // statics

    // Ascertain if a given object can be jumped over.
    public static bool IsObjectJumpable(GameObject obj)
    {
        bool jumpable = false;
        if (Defender.IsObjectDefender(obj) && obj.GetComponent<Stone>())
        {
            jumpable = true;
        }

        return jumpable;
    }


    // Instances

    // Use this for initialization
    private void Start()
    {
        this.attacker = GetComponent<Attacker>();
    }

    // Attack a colliding Defender. 
    // If its a jumpable Defender then jump over it.
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        GameObject collidingGameObj = collision.gameObject;
        if (!Defender.IsObjectDefender(collidingGameObj))
        {
            return;
        }

        if (Fox.IsObjectJumpable(collidingGameObj))
        {
            Debug.Log("Fox jumps over the " + collision);
            this.Jump();
        }
        else
        {
            Debug.Log("Fox attacks the " + collision);
            this.attacker.Attack(collidingGameObj);
        }
    }

    // Do a jump animation.
    private void Jump()
    {
        this.attacker.GetAnimator().SetTrigger(JUMP_TRIGGER_NAME);
    }
}
