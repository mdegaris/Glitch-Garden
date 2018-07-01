using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager levelManager;

    // Use this for initialization
    private void Start()
    {
        this.levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidingObj = collision.gameObject;

        if (Attacker.IsObjectAttacker(collidingObj))
        {
            this.levelManager.LoadLevel("03b Lose");
        }                
    }
}
