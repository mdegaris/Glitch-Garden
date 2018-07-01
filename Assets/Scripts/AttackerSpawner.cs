using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

    // ===================================================================
    // Variables
    // ===================================================================

    // Statics

    private static int NUMBER_OF_LANES;

    // Instances
    
    public GameObject[] attackerPrefabArray;


    // ===================================================================
    // Methods
    // ===================================================================

    // Use this for initialization
    private void Start()
    {
        // Ascsertain the number of lanes.
        // Note: If there's one spawnser per lane.
        if (AttackerSpawner.NUMBER_OF_LANES == 0)
        {
            GameObject parent = transform.parent.gameObject;
            AttackerSpawner[] spawners = parent.GetComponentsInChildren<AttackerSpawner>();
            AttackerSpawner.NUMBER_OF_LANES = spawners.Length;

            Debug.Log("Set the number of AttackerSpawnser to " + AttackerSpawner.NUMBER_OF_LANES);
        }
    }

    // Update is called once per frame.
    private void Update()
    {
        // Attempt to spawn an attacker from one of the spawners.
        foreach (GameObject thisAttackerPrefab in this.attackerPrefabArray)
        {            
            if (thisAttackerPrefab && this.IsTimeToSpawn(thisAttackerPrefab))
            {
                this.Spawn(thisAttackerPrefab);
            }
        }
    }

    // Ascertain if its time to spawn another Attacker.
    private bool IsTimeToSpawn(GameObject attackerPrefab)
    {
        Attacker attacker = attackerPrefab.GetComponent<Attacker>();

        // Defensive check to prevent infinities.
        if (attacker.meanSpawnFrequency <= 0)
        {
            Debug.LogError("Invalid mean spawn rate (" + attacker.meanSpawnFrequency + "). Attacker's mean spawn rate must be greater than 0.");
        }
        
        // Calculate the average spawns per second.
        float meanSpawnsPerSecond = (1 / attacker.meanSpawnFrequency);

        // Warning in case the frame time is longer than the mean spawns per second.
        if (Time.deltaTime > meanSpawnsPerSecond)
        {
            Debug.LogWarning("Spawn rate capped by frame rate. Spawn rate=" + meanSpawnsPerSecond + ", Frame time=" + Time.deltaTime);
        }

        // Calculate a threshold which represents a spawn probability across all 5 lanes
        float threshold = meanSpawnsPerSecond * Time.deltaTime / AttackerSpawner.NUMBER_OF_LANES;
        // Roll the dice and compare with threshold
        return (Random.value < threshold);
    }

    private void Spawn(GameObject attacker)
    {
        GameObject newAttacker = Instantiate(attacker, transform);
        newAttacker.transform.parent = newAttacker.transform;

        Debug.Log(newAttacker.name + " has been spawned at time " + Time.time + ", at location: " + transform.position);
    }
}