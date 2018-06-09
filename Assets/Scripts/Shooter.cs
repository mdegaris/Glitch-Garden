using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private static string PROJECTILES = "Projectiles";

    public GameObject projectile;

    private GameObject projectileParent;
    private Gun gunLocation;


    private void Awake()
    {
        this.projectileParent = GameObject.Find(PROJECTILES);
        if (!this.projectileParent)
        {
            this.projectileParent = new GameObject(PROJECTILES);
        }

        this.gunLocation = gameObject.GetComponentInChildren<Gun>();
    }

    private void FireGun()
    {
        GameObject newProjectile = Instantiate(projectile, projectileParent.transform);
        newProjectile.transform.position = gunLocation.transform.position;

        Debug.Log(this.name + " has spawned a " + projectile.name + " from the " + gunLocation.name + "!");
    }
}
;