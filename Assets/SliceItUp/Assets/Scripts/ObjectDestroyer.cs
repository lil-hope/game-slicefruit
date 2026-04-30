using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))       //If gameObject collides with anything except for the Player
            Destroy(other.gameObject);      //Then destroys it

        if (other.CompareTag("Obstacle") || other.CompareTag("Destroyable") || other.CompareTag("Token"))       //If gameObject collides with an Obstacle or Destroyable or Token
            FindObjectOfType<Spawner>().Spawn();        //Spawns new obstacles
    }
}
