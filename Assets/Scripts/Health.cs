using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;

    public void DealDamage(float damage)
    {
        if (damage < 0)
        {
            Debug.LogError("Damage can't be a negative number: " + damage);
        }

        float newHealth = this.health - damage;
        if (newHealth < 0)
        {
            this.health = 0;
            this.Kill();
        }
        else
        {
            this.health = newHealth;
        }

        Debug.Log(name + "'s current health is " + this.health);
    }

    public void Kill()
    {
        Debug.Log("-----------------------------------------");
        Debug.Log(this.gameObject.name + " has been killed!");
        Debug.Log("-----------------------------------------");
        Destroy(this.gameObject);
    }
}
