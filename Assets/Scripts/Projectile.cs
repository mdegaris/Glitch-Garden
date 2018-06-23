using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed, damage;

    // ===================================================================

    public static bool IsObjectProjectile(GameObject obj)
    {
        return ((obj.GetComponent<Projectile>()) ? true : false);
    }

    // ===================================================================

    // Update is called once per frame
    private void Update()
    {
        this.transform.Translate(Vector3.right * this.speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(name + " collided with " + collision);

        GameObject collidingGameObj = collision.gameObject;
        if (Attacker.IsObjectAttacker(collidingGameObj))
        {
            Health attackerHealth = collidingGameObj.GetComponent<Health>();
            attackerHealth.DealDamage(this.damage);

            Debug.Log(name + " has damaged " + collidingGameObj.name + " for " + damage + " damage.");
        }
    }
}
