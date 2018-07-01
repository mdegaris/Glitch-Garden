using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    // ===================================================================
    // Variables
    // ===================================================================

    // Statics

    private static string SPAWNERS = "Spawners";
    private static string PROJECTILES = "Projectiles";
    private static string IS_ATTACKING_NAME = "isAttacking";

    // Instances

    public GameObject projectile;

    private int defenderSnappedYPosition;
    private float defenderXPosition;
    private GameObject projectileParent;
    private Animator animator;
    private AttackerSpawner laneSpawner;
    private Gun gun;
    private GameObject spawnersParent;


    // ===================================================================
    // Methods
    // ===================================================================

    // Use this for initialization
    private void Start()
    {
        // Init the a parent game object for all created projectile objects.
        this.projectileParent = GameObject.Find(Shooter.PROJECTILES);
        if (!this.projectileParent)
        {
            this.projectileParent = new GameObject(Shooter.PROJECTILES);
        }

        // Get the Gun object.
        this.gun = gameObject.GetComponentInChildren<Gun>();

        // Init the Animator.
        this.animator = this.GetComponent<Animator>();
        this.animator.SetBool(Shooter.IS_ATTACKING_NAME, false);

        // Get Spawners parent, containing all the scene's AttackerSpawners..
        this.spawnersParent = GameObject.Find(Shooter.SPAWNERS);

        // Init shooter co-ords
        this.defenderSnappedYPosition = Mathf.RoundToInt(this.transform.position.y);
        this.defenderXPosition = this.transform.position.x;

        // Get this lane's AttackerSpawner, throw error if one can't be found
        this.laneSpawner = this.GetThisLaneSpawner();
    }

    // Update is called once per frame.
    private void Update()
    {
        // Do the attacking animation if there's an attacker in front.
        if (this.IsAttackerInFront())
        {
            this.animator.SetBool(Shooter.IS_ATTACKING_NAME, true);
        }
        else
        {
            this.animator.SetBool(Shooter.IS_ATTACKING_NAME, false);
        }
    }

    // Fire a new projectile from the Gun object.
    private void FireGun()
    {
        GameObject newProjectile = Instantiate(projectile, projectileParent.transform);
        newProjectile.transform.position = gun.transform.position;
    }

    // Finds and returns the lane spawner (AttackerSpawner) object that's currently in this defender's lane.
    private AttackerSpawner GetThisLaneSpawner()
    {
        AttackerSpawner foundAttackerSpawner = null;
        AttackerSpawner[] allSpawners = this.spawnersParent.GetComponentsInChildren<AttackerSpawner>();

        foreach (AttackerSpawner thisSpawner in allSpawners)
        {
            // Check if the spawner's Y position if the same as the shooter's Y position.
            int spawnerYPos = Mathf.RoundToInt(thisSpawner.transform.position.y);
            if ((foundAttackerSpawner == null) && (this.defenderSnappedYPosition == spawnerYPos))
            {
                foundAttackerSpawner = thisSpawner;
                Debug.Log("Found Lane Spawner (" + foundAttackerSpawner + ") at Y pos: " + spawnerYPos);
            }
        }

        if (foundAttackerSpawner == null)
        {
            Debug.LogError("No AttackSpawner could be found for lane with Y position: " + this.defenderSnappedYPosition);
        }

        return foundAttackerSpawner;
    }

    // Checks if an attacker is in from the defender, and returns true/false.
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
