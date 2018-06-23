using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour
{
    private static string JUMP_TRIGGER_NAME = "jumpTrigger";

    private Attacker attacker;


    public static bool IsObjectJumpable(GameObject obj)
    {
        bool jumpable = false;
        if (Defender.IsObjectDefender(obj) && obj.GetComponent<Stone>())
        {
            jumpable = true;
        }

        return jumpable;
    }


    // Use this for initialization
    private void Start()
    {
        this.attacker = GetComponent<Attacker>();
    }

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

    private void Jump()
    {
        this.attacker.GetAnimator().SetTrigger(JUMP_TRIGGER_NAME);
    }
}
