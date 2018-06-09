using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{
    private static string IS_ATTACKING_NAME = "isAttacking";

    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;


    public static bool IsObjectDefender(GameObject obj) { return ((obj.GetComponent<Defender>()) ? true : false); }

    public static bool IsObjectProjectile(GameObject obj) { return ((obj.GetComponent<Projectile>()) ? true : false); }


    // Use this for initialization
    private void Start ()
    {
        this.animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	private void Update ()
    {
        transform.Translate(Vector3.left * this.currentSpeed * Time.deltaTime);

        if (!this.currentTarget)
        {
            this.StopAttacking();
        }
	}   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name + " collided with " + collision);
    }

    public Animator GetAnimator()
    {
        return this.animator;
    }

    public void SetSpeed(float speed)
    {
        this.currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (this.currentTarget)
        {
            Health targetHealth = this.currentTarget.GetComponent<Health>();
            if (targetHealth)
            {
                targetHealth.DealDamage(damage);
                Debug.Log(name + " deals " + damage + " damage to " + this.currentTarget + "!");
            }
        }
    }

    public void Attack(GameObject gObj)
    {
        this.currentTarget = gObj;
        this.animator.SetBool(IS_ATTACKING_NAME, true);
    }

    public void StopAttacking()
    {
        this.animator.SetBool(IS_ATTACKING_NAME, false);  
    }
}
