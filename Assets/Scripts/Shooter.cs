using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private static string SPAWNERS = "Spawners";
    private static string PROJECTILES = "Projectiles";
    private static string IS_ATTACKING_NAME = "isAttacking";

    private int snappedYPosition;
    private float xPosition;
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
        this.snappedYPosition = Mathf.RoundToInt(this.transform.position.y);
        this.xPosition = this.transform.position.x;

        // Init Lane Spawner, throw error if one can't be found
        this.laneSpawner = this.GetThisLaneSpawner();
        if (this.laneSpawner == null)
        {
            Debug.LogError("No AttackSpawner could be found for lane with Y position: " + this.snappedYPosition);
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

    private void FireGun()
    {
        GameObject newProjectile = Instantiate(projectile, projectileParent.transform);
        newProjectile.transform.position = gun.transform.position;

        Debug.Log(this.name + " has spawned a " + projectile.name + " from the " + gun.name + "!");
    }

    private AttackerSpawner GetThisLaneSpawner()
    {
        AttackerSpawner foundAttackerSpawner = null;
        AttackerSpawner[] allSpawners = this.spawnersParent.GetComponentsInChildren<AttackerSpawner>();         
        foreach (AttackerSpawner thisSpawner in allSpawners)
        {
            int spawnerYPos = Mathf.RoundToInt(thisSpawner.transform.position.y);
            if ((foundAttackerSpawner == null) && (this.snappedYPosition == spawnerYPos))
            {
                foundAttackerSpawner = thisSpawner;
                Debug.Log("Found Lane Spawner (" + foundAttackerSpawner + ") at Y pos: " + spawnerYPos);
            }
        }

        return foundAttackerSpawner;
    }

    private bool IsAttackerInFront()
    {        
        Attacker[] laneAttackers = this.laneSpawner.GetComponentsInChildren<Attacker>();
        foreach (Attacker laneAttacker in laneAttackers)
        {
            if (this.xPosition < laneAttacker.transform.position.x)
            {
                return true;
            }
        }

        return false;
    }
}
