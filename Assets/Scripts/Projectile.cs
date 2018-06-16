using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed, damage;

    // ===================================================================

    // Static function determining if a given object is an Attacker or not.
    public static bool IsObjectAttacker(GameObject obj)
    {
        return ((obj.GetComponent<Attacker>()) ? true : false);
    }

    // ===================================================================

    // Update is called once per frame
    private void Update()
    {
        this.transform.Translate(Vector3.right * this.speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name + " collided with " + collision);

        GameObject collidingGameObj = collision.gameObject;
        if (Projectile.IsObjectAttacker(collidingGameObj))
        {
            Health attackerHealth = collidingGameObj.GetComponent<Health>();
            attackerHealth.DealDamage(this.damage);

            Debug.Log(name + " has damaged " + collidingGameObj.name + " for " + damage + " damage.");
        }
    }
}
