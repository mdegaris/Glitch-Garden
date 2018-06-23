using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private static string SPAWNERS = "Spawners";
    private static string PROJECTILES = "Projectiles";
    private static string IS_ATTACKING_NAME = "isAttacking";

    private int defenderSnappedYPosition;
    private float defenderXPosition;
    private GameObject projectileParent;
    private Animator animator;
    private AttackerSpawner laneSpawner;
    private Gun gun;

    private GameObject spawnersParent;
    public GameObject projectile;
    

    private void Start()
    {
        this.projectileParent = GameObject.Find(Shooter.PROJECTILES);
        if (!this.projectileParent)
        {
            this.projectileParent = new GameObject(Shooter.PROJECTILES);
        }

        this.gun = gameObject.GetComponentInChildren<Gun>();

        // Init Animator
        this.animator = this.GetComponent<Animator>();
        this.animator.SetBool(Shooter.IS_ATTACKING_NAME, false);

        // Init Spawners parent
        this.spawnersParent = GameObject.Find(Shooter.SPAWNERS);

        // Init shooter co-ords
        this.defenderSnappedYPosition = Mathf.RoundToInt(this.transform.position.y);
        this.defenderXPosition = this.transform.position.x;

        // Init Lane Spawner, throw error if one can't be found
        this.laneSpawner = this.GetThisLaneSpawner();
        if (this.laneSpawner == null)
        {
            Debug.LogError("No AttackSpawner could be found for lane with Y position: " + this.defenderSnappedYPosition);
        }
    }

    private void Update()
    {
        if (this.IsAttackerInFront())
        {
            this.animator.SetBool(Shooter.IS_ATTACKING_NAME, true);
        }
        else
        {
            this.animator.SetBool(Shooter.IS_ATTACKING_NAME, false);
        }
    }

    // Fire a new projectile from the Gun object 
    private void FireGun()
    {
        GameObject newProjectile = Instantiate(projectile, projectileParent.transform);
        newProjectile.transform.position = gun.transform.position;
    }

    // Gets the lane spawner (AttackerSpawner) object that's currently in this defender's lane
    private AttackerSpawner GetThisLaneSpawner()
    {
        AttackerSpawner foundAttackerSpawner = null;
        AttackerSpawner[] allSpawners = this.spawnersParent.GetComponentsInChildren<AttackerSpawner>();         
        foreach (AttackerSpawner thisSpawner in allSpawners)
        {
            int spawnerYPos = Mathf.RoundToInt(thisSpawner.transform.position.y);
            if ((foundAttackerSpawner == null) && (this.defenderSnappedYPosition == spawnerYPos))
            {
                foundAttackerSpawner = thisSpawner;
                Debug.Log("Found Lane Spawner (" + foundAttackerSpawner + ") at Y pos: " + spawnerYPos);
            }
        }

        return foundAttackerSpawner;
    }

    // Checks if an attacker is in from the defender, and returns true/false
    private bool IsAttackerInFront()
    {        
        // If we have 1 or more attackers in the lane
        if (this.laneSpawner.transform.childCount > 0)
        {
            // Iterate through all the spawners transforms (i.e. the attacker's transforms)
            foreach (Transform laneAttacker in this.laneSpawner.transform)
            {
                // Check if the attacker's x position is greater (in front) than the defender's
                if (this.defenderXPosition < laneAttacker.position.x)
                {
                    // Then we have an attacker in front of the defender
                    return true;
                }
            }
        }

        // All other cases mean we don't have an attacker in front of the defender
        return false;
    }
}
