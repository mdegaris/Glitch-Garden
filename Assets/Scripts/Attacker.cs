using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{

    // ===================================================================
    // Variables
    // ===================================================================

    // Statics

    private static string IS_ATTACKING_NAME = "isAttacking";

    // Instances

    [Tooltip("Controls how often (in seconds) this Attacker will spawn")]
    public float meanSpawnFrequency;

    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;


    // ===================================================================
    // Methods
    // ===================================================================

    // Statics

    // Static function determining if a given object is an Attacker or not.
    public static bool IsObjectAttacker(GameObject obj)
    {
        return ((obj.GetComponent<Attacker>()) ? true : false);
    }


    // Instances

    // Hit and damage the current target.
    public void StrikeCurrentTarget(float damage)
    {
        if (this.currentTarget)
        {
            // Do the damage
            Health targetHealth = this.currentTarget.GetComponent<Health>();
            if (targetHealth)
            {
                targetHealth.DealDamage(damage);
                Debug.Log(name + " deals " + damage + " damage to " + this.currentTarget + "!");
            }
        }
    }

    // Start attacking a given object
    public void Attack(GameObject gObj)
    {
        this.currentTarget = gObj;
        this.animator.SetBool(IS_ATTACKING_NAME, true);
    }

    // Remove current target and stop attacking animation.
    public void StopAttacking()
    {
        this.currentTarget = null;
        this.animator.SetBool(IS_ATTACKING_NAME, false);
    }

    // Ascetain if currently attacking.
    public bool IsAttacking()
    {
        return (this.animator.GetBool(IS_ATTACKING_NAME) == true);
    }

    // Return the Animator.
    public Animator GetAnimator()
    {
        return this.animator;
    }

    // Set's the movement speed (used in animation events).
    public void SetSpeed(float newSpeed)
    {
        this.currentSpeed = newSpeed;
    }


    // Use this for initialization
    private void Start()
    {
        this.animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // If we're not attacking anything, then move across the scene.
        if (!this.IsAttacking())
        {
            transform.Translate(Vector3.left * this.currentSpeed * Time.deltaTime);
        }

        // If we don't have a target and we're still attcking, then stop attacking.
        if (!this.currentTarget && this.IsAttacking())
        {
            this.StopAttacking();
        }
    }
}
