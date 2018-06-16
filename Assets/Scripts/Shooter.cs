using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private static string PROJECTILES = "Projectiles";    

    private GameObject projectileParent;
    private Gun gun;

    public GameObject projectile;


    private void Awake()
    {
        this.projectileParent = GameObject.Find(Shooter.PROJECTILES);
        if (!this.projectileParent)
        {
            this.projectileParent = new GameObject(Shooter.PROJECTILES);
        }

        this.gun = gameObject.GetComponentInChildren<Gun>();
    }

    private void FireGun()
    {
        GameObject newProjectile = Instantiate(projectile, projectileParent.transform);
        newProjectile.transform.position = gun.transform.position;

        Debug.Log(this.name + " has spawned a " + projectile.name + " from the " + gun.name + "!");
    }
}
